using AW.EntidadesDTO;
using AW.ReglasNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Azure_Waters_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new OfertaRN().GetAll());
        }

        [HttpGet("date")]
        public async Task<IActionResult> GetByDate(DateTime date)
        {
            return Ok(new OfertaRN().GetByDate(date));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OfertaDTO ofertaDTO)
        {
            OfertaRN ofertaRN = new OfertaRN();
            OfertaDTO result = ofertaRN.Create(ofertaDTO);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] OfertaDTO ofertaDTO)
        {
            OfertaRN ofertaRN = new OfertaRN();
            OfertaDTO result = ofertaRN.Update(ofertaDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            OfertaRN ofertaRN = new OfertaRN();
            return Ok(new {success = ofertaRN.Delete(id)});
        }
    }
}
