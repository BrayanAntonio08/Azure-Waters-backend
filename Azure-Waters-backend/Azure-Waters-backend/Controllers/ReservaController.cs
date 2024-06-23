using AW.EntidadesDTO;
using AW.ReglasNegocio;
using Azure_Waters_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Azure_Waters_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaRN reservaRN;
        public ReservaController()
        {
            reservaRN = new ReservaRN();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReserva([FromBody] ReservaDTO reservaDTO)
        {
            ReservaRN rn = new ReservaRN();
            ReservaDTO result = rn.Create(reservaDTO);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetReservaciones(int pageNumber = 1, int pageSize = 20)
        {
            var result = reservaRN.GetReservaciones(pageNumber, pageSize);
            return Ok(result);
        }

    }
}
