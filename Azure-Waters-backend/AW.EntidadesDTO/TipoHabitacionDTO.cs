using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.EntidadesDTO
{
    public class TipoHabitacionDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public ImagenDTO? Image {get; set;}
        public static TipoHabitacionDTO mapping(TipoHabitacion value)
        {
            return new TipoHabitacionDTO
            {
                Id = value.IdTipo,
                Name = value.Nombre,
                Price = value.Precio,
                Description = value.Descripcion,
                Image = value.Imagen != null? ImagenDTO.mapping(value.Imagen): null
            };
        }
    }
}
