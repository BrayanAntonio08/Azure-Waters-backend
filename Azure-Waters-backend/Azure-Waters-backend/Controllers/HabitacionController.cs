using Microsoft.AspNetCore.Mvc;
using AW.EntidadesDTO;
using AW.ReglasNegocio;
using AW.AccesoDatos;
using Azure_Waters_backend.Models;

namespace Azure_Waters_backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class HabitacionController: ControllerBase
    {
        private readonly HabitacionDatos habitacionDatos;

        public HabitacionController()
        {
            habitacionDatos = new HabitacionDatos();
        }

        [HttpGet]
        public async Task<IActionResult> ListarHabitaciones()
        {
            List<Habitacion> habitaciones = await habitacionDatos.ListarHabitaciones();

            if (habitaciones == null || habitaciones.Count == 0)
            {
                return NotFound("No seasons found.");
            }

            return Ok(habitaciones);
        }
    }
}
