using AW.AccesoDatos;
using AW.EntidadesDTO;
using AW.ReglasNegocio;
using Azure_Waters_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure_Waters_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemporadaController : ControllerBase
    {
        private readonly TemporadaRN temporadaRN;

        public TemporadaController()
        {
            temporadaRN = new TemporadaRN();
        }

        [HttpGet]
        public async Task<IActionResult> GetTemporadas()
        {
            List<TemporadaDTO> temporadas = await temporadaRN.GetTemporadas();

            if (temporadas == null || temporadas.Count == 0)
            {
                return NotFound("No seasons found.");
            }

            return Ok(temporadas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemporada(int id)
        {
            var temporada = await temporadaRN.GetTemporada(id);

            if (temporada == null)
            {
                return NotFound($"Season with ID {id} not found.");
            }

            return Ok(temporada);
        }

        [HttpPost]
        public async Task<IActionResult> PostTemporada([FromBody]  TemporadaDTO temporadaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TemporadaDTO result = await temporadaRN.AddTemporada(temporadaDTO);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarTemporada([FromBody] TemporadaDTO temporadaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await temporadaRN.ActualizarTemporada(temporadaDTO);

            if (!updated)
            {
                return NotFound("Season not found.");
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTemporada(int id)
        {
            var deleted = await temporadaRN.EliminarTemporada(id);

            if (!deleted)
            {
                return NotFound($"Season with ID {id} not found.");
            }

            return NoContent();
        }

        [HttpPut("all")]
        public async Task<IActionResult> ActualizarGeneral([FromBody] List<TemporadaDTO> temporadas)
        {

            return Ok(await temporadaRN.ActualizarGeneral(temporadas));
        }
    }
}
