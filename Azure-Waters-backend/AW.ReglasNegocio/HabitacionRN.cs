using AW.AccesoDatos;
using AW.EntidadesDTO;
using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.ReglasNegocio
{
    public class HabitacionRN
    {

        public List<TipoHabitacionDTO> GetTiposHabitacion()
        {
            HabitacionDatos datos = new HabitacionDatos();
            List<TipoHabitacion> request = datos.GetTiposHabitacion();
            List<TipoHabitacionDTO> response = new List<TipoHabitacionDTO>();
            foreach(TipoHabitacion aux in request)
            {
                response.Add(TipoHabitacionDTO.mapping(aux));
            }
            return response;
        }

        public List<HabitacionDTO> GetHabitaciones()
        {
            HabitacionDatos datos = new HabitacionDatos();
            List<Habitacion> request = datos.GetHabitaciones();
            List<HabitacionDTO> response = new List<HabitacionDTO>();
            foreach (Habitacion aux in request)
            {
                response.Add(HabitacionDTO.mapping(aux));
            }
            return response;
        }


        public async Task<List<Habitacion>> ObtenerHabitacionesDisponibles(DateTime fechaInicio, DateTime fechaFinal, int? idTipoHabitacion)
        {
            HabitacionDatos datos = new HabitacionDatos();

            var habitacionesActivas = datos.GetAllHabitacionesActivas();

            var habitacionesDisponibles = new List<Habitacion>();
            foreach (var habitacion in habitacionesActivas)
            {
                if (habitacion.Activa == true && habitacion.Reservada == false)
                {
                    var reservas = datos.GetReservasHabitacion(habitacion.IdHabitacion, fechaInicio, fechaFinal);
                    if (reservas.Count == 0)
                    {
                        habitacionesDisponibles.Add(habitacion);
                    }
                }
            }
            if (idTipoHabitacion != null)
            {
                habitacionesDisponibles = habitacionesDisponibles.Where(h => h.IdTipo == idTipoHabitacion).ToList();
            }

            return habitacionesDisponibles;
        }

        public void UpdateTipoHabitacion(TipoHabitacionDTO tipoHabitacionDTO)
        {
            HabitacionDatos datos = new HabitacionDatos();
            TipoHabitacion tipoHabitacion = datos.GetTipoHabitacionById(tipoHabitacionDTO.Id);
            if (tipoHabitacion != null)
            {
                tipoHabitacion.Nombre = tipoHabitacionDTO.Name;
                tipoHabitacion.Precio = tipoHabitacionDTO.Price;
                tipoHabitacion.Descripcion = tipoHabitacionDTO.Description;
                tipoHabitacion.ImagenId = tipoHabitacionDTO.ImagenId;
                //tipoHabitacion.Imagen = tipoHabitacionDTO.Image != null ? new Imagen
                //{
                //    Id = tipoHabitacionDTO.Image.Id,
                //    Alt = tipoHabitacionDTO.Image.Alt,
                //    Url = tipoHabitacionDTO.Image.Url
                //} : null;
                datos.UpdateTipoHabitacion(tipoHabitacion);
            }
        }

    }
}
