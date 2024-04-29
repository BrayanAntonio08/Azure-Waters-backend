﻿using AW.EntidadesDTO;
using AW.ReglasNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Azure_Waters_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        [HttpGet]
        [Route ("tipos")]
        public async Task<IActionResult> GetTiposHabitacion()
        {
            HabitacionRN rn = new HabitacionRN();
            return Ok(rn.GetTiposHabitacion());
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetHabitaciones()
        {
            HabitacionRN rn = new HabitacionRN();
            return Ok(rn.GetHabitaciones());
        }

        [HttpPut]
        [Route("tipos/{id}")]
        public async Task<IActionResult> UpdateTipoHabitacion(int id, [FromBody] TipoHabitacionDTO tipoHabitacionDTO)
        {
            if (id != tipoHabitacionDTO.Id)
            {
                return BadRequest();
            }

            HabitacionRN rn = new HabitacionRN();
            rn.UpdateTipoHabitacion(tipoHabitacionDTO);

            return NoContent();
        }

    }
}
