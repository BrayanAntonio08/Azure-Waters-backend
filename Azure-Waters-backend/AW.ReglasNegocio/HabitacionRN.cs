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
    }
}
