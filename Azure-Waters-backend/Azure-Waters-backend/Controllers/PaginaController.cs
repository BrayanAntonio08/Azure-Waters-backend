using Microsoft.AspNetCore.Mvc;
using AW.EntidadesDTO;

namespace Azure_Waters_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaginaController : ControllerBase
    {
        [HttpGet]
        [Route("{nombre}")]
        public async Task<IActionResult> GetPagina(string nombre){
            PaginaDTO pagina = new PaginaDTO(){
                Id = 1,
                Titulo = nombre,
                Texto = "Esta es una prueba de <i>pagina</i> desde el <br> api para <b>"+nombre+"</b>"
            };
            return Ok(pagina);
        }
    }

}