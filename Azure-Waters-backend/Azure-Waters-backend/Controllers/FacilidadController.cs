using Microsoft.AspNetCore.Mvc;
using AW.AccesoDatos;
using Azure_Waters_backend.Models;
using AW.EntidadesDTO;
using AW.ReglasNegocio;
using AW.EntidadDTO;

namespace Azure_Waters_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacilidadController : Controller
    {
        private readonly FacilidadDatos facilidadDatos;
        public FacilidadController()
        {
            facilidadDatos = new FacilidadDatos();
        }

        [HttpGet]
        public async Task<IActionResult> GetFacilidades()
        {
            FacilidadRN facilidadRN = new FacilidadRN();
            FacilidadDTO facilidad = facilidadRN.GetFacilidad();
            return facilidad != null ? Ok(facilidad) : NotFound();
        }
    }
}
