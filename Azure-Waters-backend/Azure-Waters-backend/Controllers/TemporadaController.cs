using AW.AccesoDatos;
using Azure_Waters_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure_Waters_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemporadaController : ControllerBase
    {
        private readonly TemporadaDatos temporadaDatos;

        public TemporadaController()
        {
            temporadaDatos = new TemporadaDatos(); 
        }

        [HttpGet]
        public async Task<IActionResult> GetTemporadas()
        {
            List<Temporada> temporadas = await temporadaDatos.GetTemporadas();

            if (temporadas == null || temporadas.Count == 0)
            {
                return NotFound("No seasons found.");
            }

            return Ok(temporadas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemporada(int id)
        {
            var temporada = await temporadaDatos.GetTemporadaAsync(id);

            if (temporada == null)
            {
                return NotFound($"Season with ID {id} not found.");
            }

            return Ok(temporada);
        }

        [HttpPost]
        public async Task<IActionResult> PostTemporada(Temporada temporada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await temporadaDatos.AddTemporadaAsync(temporada);

            return CreatedAtAction(nameof(GetTemporada), new { id = temporada.IdTemporada }, temporada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTemporada(int id, Temporada temporada)
        {
            if (id != temporada.IdTemporada)
            {
                return BadRequest("ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await temporadaDatos.ActualizarTemporada(id, temporada);

            if (!updated)
            {
                return NotFound($"Season with ID {id} not found.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTemporada(int id)
        {
            var deleted = await temporadaDatos.EliminarTemporada(id);

            if (!deleted)
            {
                return NotFound($"Season with ID {id} not found.");
            }

            return NoContent();
        }
    }
}
