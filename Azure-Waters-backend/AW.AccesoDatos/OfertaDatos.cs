using AW.Entidades;
using Azure_Waters_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.AccesoDatos
{
    public class OfertaDatos
    {
        private AzureWatersContext _context;

        public OfertaDatos()
        {
            _context = new AzureWatersContext();
        }

        public Oferta Create(Oferta oferta)
        {
            _context.Ofertas.Add(oferta);
            _context.SaveChanges();
            oferta.TipoHabitacion = _context.TipoHabitacion.Find(oferta.IdTipoHabitacion);
            return oferta;
        }

        public IEnumerable<Oferta> GetAll() {
            return _context.Ofertas.Include(o => o.TipoHabitacion).ToList();  
        }

        public List<Oferta> GetByDate(DateTime date)
        {
            return _context.Ofertas.Include(o => o.TipoHabitacion).Where(o => o.FechaInicio <= date && o.FechaFin >= date).ToList();
        }

        public Oferta Update(Oferta oferta) {
            _context.Entry(oferta).State = EntityState.Modified;
            _context.SaveChanges();
            oferta.TipoHabitacion = _context.TipoHabitacion.Find(oferta.IdTipoHabitacion);
            return oferta;
        }

        public bool Delete(int id)
        {
            Oferta temp = _context.Ofertas.FirstOrDefault(o => o.Id == id);
            if (temp != null)
            {
                _context.Ofertas.Remove(temp);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
