using Azure_Waters_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.AccesoDatos
{
    public class HabitacionDatos
    {
        private readonly AzureWatersContext _context;

        public HabitacionDatos()
        {
            _context = new AzureWatersContext();
        }

        public async Task<List<Habitacion>> ListarHabitaciones()
        {
            var habitaciones = await _context.Habitacion.FromSqlInterpolated($"exec listarHabitacion").ToListAsync();
            return habitaciones;
        }
    }
}
