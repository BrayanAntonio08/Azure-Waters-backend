using Microsoft.AspNetCore.Mvc;
using AW.EntidadesDTO;
using AW.ReglasNegocio;

namespace Azure_Waters_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaginaController : ControllerBase
    {
        [HttpGet]
        [Route("{nombre}")]
        public async Task<IActionResult> GetPagina(string nombre){
            PaginaRN paginaRN = new PaginaRN();
            PaginaDTO pagina = paginaRN.GetPagina(nombre);
            return pagina!=null? Ok(pagina) : NotFound();
        }

        [HttpGet]
        [Route("images/{nombrePagina}")]
        public async Task<IActionResult> GetImagenes(string nombrePagina){
            return Ok(new ImagenRN().GetImagenesPagina(nombrePagina));
        }

        [HttpPut]
        public async Task<IActionResult> ModificarPagina([FromBody] PaginaDTO pagina)
        {
            PaginaRN rn = new PaginaRN();
            rn.UpdatePagina(pagina);    
            return Ok(pagina);
        }
    }

}