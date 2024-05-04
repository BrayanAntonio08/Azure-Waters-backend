using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
