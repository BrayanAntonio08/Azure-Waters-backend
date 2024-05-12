using AW.EntidadesDTO.interfaces;
using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.EntidadesDTO
{
    public class HabitacionRevisionDTO : IHabitacionDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int? Type_id { get; set; }
        public string? Image_url { get; set; }
        public string? Description {  get; set; } 
        public decimal? Price { get; set; }

        public static HabitacionRevisionDTO mapping(Habitacion value, TipoHabitacion tipo)
        {
            return new HabitacionRevisionDTO
            {
                Id = value.IdHabitacion,
                Number = value.Numero,
                Type_id = value.IdTipo,
                Image_url = tipo.Imagen != null ? tipo.Imagen.Url: "",
                Description = tipo.Descripcion,
                Price = tipo.Precio
            };
        }
    }
}
