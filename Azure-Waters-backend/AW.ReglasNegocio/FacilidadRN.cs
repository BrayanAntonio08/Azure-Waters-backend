using AW.AccesoDatos;
using AW.EntidadDTO;
using Azure_Waters_backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace AW.ReglasNegocio
{
    public class FacilidadRN
    {
        private readonly FacilidadDatos facilidadDatos;

        public FacilidadRN()
        {
            facilidadDatos = new FacilidadDatos();
        }

        public List<FacilidadDTO> GetFacilidades()
        {
            FacilidadDatos facilidadDatos = new FacilidadDatos();
            List<Facilidad> facilidades = facilidadDatos.GetFacilidades();
            return facilidades.Select(f => FacilidadDTO.mapping(f)).ToList();
        }
    }
}