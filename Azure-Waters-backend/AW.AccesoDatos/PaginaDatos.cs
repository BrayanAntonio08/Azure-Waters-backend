using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.AccesoDatos
{
    public class PaginaDatos
    {
        private AzureWatersContext _context;
        public PaginaDatos() 
        {
            this._context = new AzureWatersContext();
        }
        public Pagina GetPagina(string titulo)
        {
           return _context.Pagina.Where(x => x.Nombre == titulo).FirstOrDefault();
        }
    }
}
