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
            return _context.TipoHabitacion.ToList();
        }

        public List<Habitacion> GetHabitaciones()
        {
            return _context.Habitacion.ToList();
        }
    }
}
