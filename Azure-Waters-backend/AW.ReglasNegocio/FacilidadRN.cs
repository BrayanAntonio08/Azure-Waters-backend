using AW.AccesoDatos;
using AW.EntidadDTO;
using AW.EntidadesDTO;
using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.ReglasNegocio
{
    public class FacilidadRN
    {
        public FacilidadDTO GetFacilidad()
        {
            FacilidadDatos facilidadDatos = new FacilidadDatos();
            Facilidad facilidad = facilidadDatos.GetFacilidad();

            return facilidad != null ? FacilidadDTO.mapping(facilidad) : null;
        }
    }
}
