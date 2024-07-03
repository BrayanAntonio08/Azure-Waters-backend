using AW.Entidades;
using Azure_Waters_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.AccesoDatos
{
    public class ReservaDatos
    {
        private readonly AzureWatersContext _context;

        public ReservaDatos()
        {
            _context = new AzureWatersContext();
        }

        public Reserva Create(Reserva reserva)
        {
            //save the client if doesn't exist
            if (_context.Cliente.Any(c => c.IdCliente == reserva.IdCliente))
            {
                reserva.IdClienteNavigation = null;
            }
            

            reserva.Guid = Guid.NewGuid().ToString();
            _context.Reserva.Add(reserva);
            _context.SaveChanges();

            // we need to colect some data before returning tha value so the mapping will be correct
            reserva.IdHabitacionNavigation = _context.Habitacion.FirstOrDefault(h => h.IdHabitacion == reserva.IdHabitacion);
            reserva.IdHabitacionNavigation.IdTipoNavigation = _context.TipoHabitacion.FirstOrDefault(t => t.IdTipo == reserva.IdHabitacionNavigation.IdTipo);

            return reserva;
        }

        public decimal CalculateDayCost(DateTime date, int tipoHabitacion)
        {
            decimal dayCost = 0;
            DateTime dateTime = new DateTime(2000, date.Month, date.Day);

            TipoHabitacion room = _context.TipoHabitacion.Find(tipoHabitacion);
            if(room != null) {
                dayCost = (decimal)room.Precio;
                
                decimal incremento = _context.Temporada.Where(t => (t.FechaFin >= dateTime && t.FechaInicio <= dateTime) || (t.FechaInicio > t.FechaFin && (dateTime <= t.FechaFin || t.FechaInicio <= dateTime))).First().Incremento;

                List<Oferta> ofertas = _context.Ofertas.Where(t => t.FechaFin >= dateTime && t.FechaInicio <= dateTime).ToList();
                decimal descuento = 0;
                foreach(Oferta oferta in ofertas)
                {
                    descuento += (decimal)oferta.Descuento;
                }

                dayCost += (decimal)room.Precio * incremento / 100;
                dayCost -= (decimal)room.Precio * descuento / 100;
            }

            return dayCost;
        }

        public List<Reserva> GetReservaciones(int pageNumber, int pageSize)
        {
            return _context.Reserva
                .Include(r => r.IdHabitacionNavigation)
                .ThenInclude(h => h.IdTipoNavigation)
                .Include(r => r.IdClienteNavigation) // Incluir Cliente
                .OrderBy(r => r.FechaInicio)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public bool Delete(int id)
        {
            var reserva = _context.Reserva.Find(id);
            if (reserva == null)
            {
                return false;
            }

            _context.Reserva.Remove(reserva);
            _context.SaveChanges();
            return true;
        }

    }
}
