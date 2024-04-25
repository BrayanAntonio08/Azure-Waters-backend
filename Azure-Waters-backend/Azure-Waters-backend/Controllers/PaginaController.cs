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
    }

}