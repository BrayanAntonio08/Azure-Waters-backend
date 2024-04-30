using Azure_Waters_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.AccesoDatos
{
    public class TipoHabitacionDatos
    {
        private readonly AzureWatersContext _context;

        public TipoHabitacionDatos()
        {
            _context = new AzureWatersContext();
        }

        public async Task<List<TipoHabitacion>> ListarTipoHabitaciones()
        {
            var habitaciones = await _context.TipoHabitacion.FromSqlInterpolated($"exec listarTipoHabitacion").ToListAsync();
            return habitaciones;
        }


    }
}
