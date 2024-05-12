using AW.EntidadesDTO;
using AW.ReglasNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Azure_Waters_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateReserva([FromBody] ReservaDTO reservaDTO)
        {
            ReservaRN rn = new ReservaRN();
            ReservaDTO result = rn.Create(reservaDTO);

            return Ok(result);
        }
    }
}
