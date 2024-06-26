﻿using Microsoft.AspNetCore.Mvc;
using AW.AccesoDatos;
using AW.EntidadDTO;
using AW.ReglasNegocio;

namespace Azure_Waters_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacilidadController : Controller
    {
        private readonly FacilidadRN facilidadRN;

        public FacilidadController()
        {
            facilidadRN = new FacilidadRN();
        }

        [HttpGet]
        public async Task<IActionResult> GetFacilidades()
        {
            FacilidadRN facilidadRN = new FacilidadRN();
            List<FacilidadDTO> facilidades = facilidadRN.GetFacilidades();
            return facilidades != null ? Ok(facilidades) : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFacilidad([FromBody] FacilidadDTO facilidad)
        {
            FacilidadRN facilidadRN = new FacilidadRN();
            FacilidadDTO result = facilidadRN.UpdateFacilidad(facilidad);
            if(result == null)
                return NotFound();
            return Ok(result);
        }
    }
}