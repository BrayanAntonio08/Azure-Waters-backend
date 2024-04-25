using Azure_Waters_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task AddTemporadaAsync(Temporada temporada)
        {
            _context.Temporada.Add(temporada);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ActualizarTemporada(int id, Temporada temporada)
        {
            if (id != temporada.IdTemporada)
            {
                return false;
            }

            _context.Entry(temporada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemporadaExists(id))
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
            return _context.Temporada.Any(e => e.IdTemporada == id);
        }
    }
}
