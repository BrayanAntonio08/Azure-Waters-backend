using Microsoft.AspNetCore.Mvc;

namespace Azure_Waters_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaginaController : ControllerBase
    {
        [HttpGet]
        [Route("{nombre}")]
        public async Task<IActionResult> GetPagina(string nombre){
            return Ok("Página "+nombre+" obtenida correctamente");
        }
    }

}