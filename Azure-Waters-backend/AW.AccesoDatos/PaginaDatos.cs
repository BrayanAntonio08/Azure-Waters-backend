using Azure;
using Azure_Waters_backend.Models;
using Microsoft.EntityFrameworkCore;
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
           return _context.Pagina.Where(x => x.Nombre == titulo).Include(p => p.Imagen).FirstOrDefault();
        }


        public void Update(Pagina pagina) {
            _context.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Imagen_Pagina] WHERE pagina_id = {0}", pagina.PaginaId);

            foreach (Imagen img in pagina.Imagen) {
                if (img.Id == 0) {
                    _context.Imagen.Add(img);
                }
                img.Pagina.Add(pagina);
            }
            _context.Update(pagina);
           // _context.Entry(pagina).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
