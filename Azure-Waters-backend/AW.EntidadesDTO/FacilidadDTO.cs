using AW.EntidadesDTO;
using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.EntidadDTO
{
    public class FacilidadDTO
    {
        public int Id { get; set; }
        public string Texto { get; set; }

        //public ImagenDTO Imagen { get; set; }

        public static FacilidadDTO mapping(Facilidad facilidad)
        {
            return new FacilidadDTO
            {
                Id = facilidad.FacilidadId,
                Texto = facilidad.Texto
                //Imagen
            };
        }
    }
}
