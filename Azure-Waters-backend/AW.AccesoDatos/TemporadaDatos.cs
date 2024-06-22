using Azure_Waters_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AW.AccesoDatos
{
    public class TemporadaDatos
    {
        private readonly AzureWatersContext _context;

        public TemporadaDatos()
        {
            _context = new AzureWatersContext();
        }

        public async Task<List<Temporada>> GetTemporadas()
        {
            return await _context.Temporada.ToListAsync();
        }

        public async Task<Temporada> GetTemporadaAsync(int id)
        {
            return await _context.Temporada.FindAsync(id);
        }

        public async Task<Temporada> AddTemporadaAsync(Temporada temporada)
        {
            _context.Temporada.Add(temporada);
            await _context.SaveChangesAsync();
            return temporada;
        }
        public async Task<List<Temporada>> ActualizarGeneral (List<Temporada> temporadas)
        {
            foreach(var temporada in temporadas)
            {
                if(temporada.Id == 0)
                {
                    _context.Temporada.Add(temporada);
                }
                else
                {
                    _context.Entry(temporada).State = EntityState.Modified;
                }
            }
            await _context.SaveChangesAsync();
            return temporadas;
        }

        public async Task<bool> ActualizarTemporada(Temporada temporada)
        {
            
            _context.Entry(temporada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemporadaExists(temporada.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> EliminarTemporada(int id)
        {
            var temporada = await _context.Temporada.FindAsync(id);
            if (temporada == null)
            {
                return false;
            }

            _context.Temporada.Remove(temporada);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool TemporadaExists(int id)
        {
            return _context.Temporada.Any(e => e.Id == id);
        }
    }
}
