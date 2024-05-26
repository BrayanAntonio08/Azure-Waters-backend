using Azure_Waters_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AW.AccesoDatos
{
    public class FacilidadDatos
    {
        private readonly AzureWatersContext _context;

        public FacilidadDatos()
        {
            _context = new AzureWatersContext();
        }

        public List<Facilidad> GetFacilidades()
        {
            return _context.Facilidad.Include(f => f.Imagen).ToList();
        }

        public Facilidad UpdateFacilidad(Facilidad facilidad)
        {
            _context.Entry(facilidad).State = EntityState.Modified;
            _context.SaveChanges();
            return _context.Facilidad.Include(f => f.Imagen).FirstOrDefault(f => f.FacilidadId == facilidad.FacilidadId);
        }
    }
}