using AW.EntidadesDTO;
using AW.ReglasNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Azure_Waters_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(new AnuncioRN().ListAnuncios());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AnuncioDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            AnuncioDTO result = new AnuncioRN().CreateAnuncio(dto);
            return Ok(result);  
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AnuncioDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            AnuncioDTO result = new AnuncioRN().UpdateAnuncio(dto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] AnuncioDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            bool result = new AnuncioRN().DeleteAnuncio(dto);
            return Ok(result);
        }
    }
}
