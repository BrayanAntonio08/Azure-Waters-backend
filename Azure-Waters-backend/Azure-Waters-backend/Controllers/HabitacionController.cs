using AW.EntidadesDTO;
using AW.ReglasNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Azure_Waters_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {

        [HttpGet]
        [Route ("tipos")]
        public async Task<IActionResult> GetTiposHabitacion()
        {
            HabitacionRN rn = new HabitacionRN();
            return Ok(rn.GetTiposHabitacion());
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetHabitaciones()
        {
            HabitacionRN rn = new HabitacionRN();
            return Ok(rn.GetHabitaciones());
        }

        [HttpGet]
        [Route("disponibilidad")]
        public async Task<IActionResult> ConsultarDisponibilidad([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFinal, [FromQuery] int? idTipoHabitacion)
        {
            HabitacionRN rn = new HabitacionRN();

            var habitacionesDisponibles = await rn.ObtenerHabitacionesDisponibles(fechaInicio, fechaFinal, idTipoHabitacion);

            // No se calcula la tarifa total por ahora

            return Ok(habitacionesDisponibles);
        }

        [HttpPost]
        [Route("revisar")]
        public async Task<IActionResult> RevisarHabitacion([FromBody] ReservaDTO reserva)
        {
            if (reserva == null)
            {
                return BadRequest("No se han enviado los datos solicitados");
            }
            HabitacionRevisionDTO? resultado = new HabitacionRN().RevisarHabitacion(reserva);
            if(resultado == null)
            {
                //Acá se deben analizar las opciones
                return Ok(new { success = false, message = "No se han encontrado habitaciones" });
            }
            reserva.Room = resultado;
            return Ok(new { success = true, data = reserva });
        }

        [HttpDelete]
        [Route("liberar/{roomId}")]
        public async Task<IActionResult> LiberarRevisionHabitacion(int roomId)
        {
            HabitacionRN rn = new HabitacionRN();
            rn.LiberarHabitacion(roomId);

            return Ok();
        }

        [HttpPut]
        [Route("tipos/{id}")]
        public async Task<IActionResult> UpdateTipoHabitacion(int id, [FromBody] TipoHabitacionDTO tipoHabitacionDTO)
        {
            if (id != tipoHabitacionDTO.Id)
            {
                return BadRequest();
            }

            HabitacionRN rn = new HabitacionRN();
            rn.UpdateTipoHabitacion(tipoHabitacionDTO);

            return NoContent();
        }

    }
}
