using Azure_Waters_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.AccesoDatos
{
    public class AnuncioDatos
    {
        private AzureWatersContext _context;

        public AnuncioDatos()
        {
            _context = new AzureWatersContext();
        }
        
        public List<Anuncio> ListAnuncios()
        {
            return _context.Anuncio.Include(a => a.Imagen).ToList();
        }

        public Anuncio CreateAnuncio(Anuncio anuncio)
        {
            _context.Anuncio.Add(anuncio);
            _context.SaveChanges();
            return anuncio;
        }

        public Anuncio UpdateAnuncio(Anuncio anuncio)
        {
            if(anuncio.ImagenId == 0 && anuncio.Imagen != null)
            {
                _context.Imagen.Add(anuncio.Imagen);
            }
            _context.Entry(anuncio).State = EntityState.Modified;
            _context.SaveChanges();
            return anuncio;
        }

        public bool DeleteAnuncio(Anuncio anuncio)
        {
            try
            {
                _context.Anuncio.Remove(anuncio);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

    }
}
