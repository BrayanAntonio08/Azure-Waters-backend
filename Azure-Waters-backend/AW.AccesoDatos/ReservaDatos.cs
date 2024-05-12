using Azure_Waters_backend.Models;
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

    }
}
