using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.AccesoDatos
{
    public class ImagenDatos
    {
        private AzureWatersContext _context;
        public ImagenDatos() 
        {
            this._context = new AzureWatersContext();
        }
        public List<Imagen> GetImagenes(string nombrePagina)
        {
           return _context.Imagen.Where(
                x => x.Pagina.Where(
                    p => p.Nombre == nombrePagina
                ).FirstOrDefault() != null
                ).ToList();
        }

        public string GetImagenHabitacion(int? roomType)
        {
            TipoHabitacion? temp = _context.TipoHabitacion.FirstOrDefault(rt => rt.IdTipo ==  roomType);
            if (temp != null)
            {
                
                return _context.Imagen.FirstOrDefault(i => i.Id == temp.ImagenId).Url;
            }
            return "";
        }
    }
}
