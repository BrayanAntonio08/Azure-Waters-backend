using Azure_Waters_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AW.Entidades;

namespace AW.AccesoDatos
{
    public class HabitacionDatos
    {
        private AzureWatersContext _context;
        public HabitacionDatos()
        {
            this._context = new AzureWatersContext();
        }

        public List<TipoHabitacion> GetTiposHabitacion()
        {
            List<TipoHabitacion> data = _context.TipoHabitacion.ToList();

            foreach(TipoHabitacion aux in data){
                aux.Imagen = _context.Imagen.Where(x => x.Id == aux.ImagenId).FirstOrDefault();
            }
            return data;
        }

        public List<Habitacion> GetHabitaciones()
        {
            return _context.Habitacion.ToList();
        }


        public List<Habitacion> GetAllHabitacionesActivas()
        {
            return _context.Habitacion.Where(h => h.Activa == true).ToList();
        }

        public List<Reserva> GetReservasHabitacion(int idHabitacion, DateTime fechaInicio, DateTime fechaFinal)
        {
            return _context.Reserva
                .Where(r => r.IdHabitacion == idHabitacion && r.FechaInicio >= fechaInicio && r.FechaFin <= fechaFinal)
                .ToList();
        }

        public void UpdateTipoHabitacion(TipoHabitacion tipoHabitacion)
        {
            _context.TipoHabitacion.Update(tipoHabitacion);
            _context.SaveChanges();
        }

        public TipoHabitacion GetTipoHabitacionById(int id)
        {
            return _context.TipoHabitacion.FirstOrDefault(th => th.IdTipo == id);
        }

        public Habitacion? RevisarHabitacion(DateTime? llegada, DateTime? salida, int? tipoHabitacion)
        {
            ICollection<Habitacion> habitacionesTipo = _context.Habitacion.Where(h => h.IdTipo == tipoHabitacion && h.Activa == true && h.Revision == false).ToList();
            Habitacion? resultado = habitacionesTipo.Where(
                h => h.Reserva.Where(
                    r =>
                    (r.FechaInicio < salida && r.FechaInicio >= llegada) ||
                    (r.FechaFin > llegada && r.FechaFin <= salida)).IsNullOrEmpty()).FirstOrDefault();
            if(resultado != null)
            {
                resultado.Revision = true;
                _context.SaveChanges();
            }
            return resultado;
        }

        
        public void LiberarHabitacion(int id)
        {
            _context.Database.ExecuteSqlRaw(@"
                UPDATE [dbo].[Habitacion]  
                SET [revision] = 0
                WHERE [id_habitacion] = {0}", id);
            _context.SaveChanges();
        }

        public Habitacion? MarcarHabitacionActiva(int idHabitacion, bool activa)
        {
            _context.Database.ExecuteSqlRaw(@"
                UPDATE [dbo].[Habitacion]  
                SET [activa] = {1}
                WHERE [id_habitacion] = {0}",  idHabitacion, activa);
            _context.SaveChanges();

            return _context.Habitacion.Find(idHabitacion);
        }

        public Habitacion GetHabitacionById(int id)
        {
            return _context.Habitacion.FirstOrDefault(h => h.IdHabitacion == id);
        }

        public void DeleteHabitacion(Habitacion room)
        {
            _context.Habitacion.Remove(room);
            _context.SaveChanges();
        }

        public void CreateHabitacion(Habitacion habitacion)
        {
            _context.Habitacion.Add(habitacion);
            _context.SaveChanges();
        }

        public void UpdateHabitacion(Habitacion habitacion)
        {
            _context.Habitacion.Update(habitacion);
            _context.SaveChanges();
        }


        //NEW DISPONIBILIDAD HABITACION ERICKA 04/07
        public List<HabitacionDto> ConsultarDisponibilidad(DateTime fechaInicio, DateTime fechaFin, int? idTipoHabitacion)
        {
            var habitacionesDisponibles = _context.Habitacion
                .Include(h => h.IdTipoNavigation)
                .Where(h => h.Activa == true && h.Reservada == false)
                .Where(h => idTipoHabitacion == null || h.IdTipo == idTipoHabitacion)
                .Where(h => !_context.Reserva.Any(r =>
                    r.IdHabitacion == h.IdHabitacion &&
                    ((r.FechaInicio >= fechaInicio && r.FechaInicio <= fechaFin) ||
                    (r.FechaFin >= fechaInicio && r.FechaFin <= fechaFin) ||
                    (r.FechaInicio <= fechaInicio && r.FechaFin >= fechaFin))))
                .ToList();

            return habitacionesDisponibles.Select(h => new HabitacionDto
            {
                Numero = h.Numero,
                TipoHabitacion = h.IdTipoNavigation.Nombre,
                CostoEstadia = (fechaFin - fechaInicio).Days * (h.IdTipoNavigation.Precio ?? 0)
            }).ToList();
        }
    }
}
