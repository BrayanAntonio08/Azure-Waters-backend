using Azure_Waters_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.AccesoDatos
{
    public class FacilidadDatos
    {
        private readonly AzureWatersContext _context;

        public FacilidadDatos()
        {
            _context = new AzureWatersContext();
        }

        public Facilidad GetFacilidad()
        {
            return _context.Facilidad.FirstOrDefault();
        }
    }
}
