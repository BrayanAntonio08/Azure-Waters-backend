using AW.AccesoDatos;
using AW.EntidadDTO;
using Azure_Waters_backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace AW.ReglasNegocio
{
    public class FacilidadRN
    {
        public List<FacilidadDTO> GetFacilidades()
        {
            FacilidadDatos facilidadDatos = new FacilidadDatos();
            List<Facilidad> facilidades = facilidadDatos.GetFacilidades();
            return facilidades.Select(f => FacilidadDTO.mapping(f)).ToList();
        }

        public FacilidadDTO UpdateFacilidad(FacilidadDTO facilidad)
        {
            FacilidadDatos facilidadDatos = new FacilidadDatos();
            Facilidad result = facilidadDatos.UpdateFacilidad(FacilidadDTO.mapping(facilidad));
            return result != null? FacilidadDTO.mapping(result): null;
        }
    }
}