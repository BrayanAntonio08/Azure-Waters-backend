using AW.AccesoDatos;
using AW.EntidadesDTO;
using AW.ReglasNegocio;
using Azure_Waters_backend.Models;
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

        //[HttpGet]
        //[Route("disponibilidad")]
        //public async Task<IActionResult> ConsultarDisponibilidad([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFinal, [FromQuery] int? idTipoHabitacion)
        //{
        //    HabitacionRN rn = new HabitacionRN();

        //    var habitacionesDisponibles = await rn.ObtenerHabitacionesDisponibles(fechaInicio, fechaFinal, idTipoHabitacion);

        //    // No se calcula la tarifa total por ahora

        //    return Ok(habitacionesDisponibles);
        //}






        //04/07 COMENTADO
        /*
        [HttpGet]
        [Route("disponibilidad")]
        public async Task<IActionResult> ConsultarDisponibilidad([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFinal, [FromQuery] int? idTipoHabitacion)
        {
            try
            {
                HabitacionRN rn = new HabitacionRN();
                var habitacionesDisponibles = await rn.ObtenerHabitacionesDisponibles(fechaInicio, fechaFinal, idTipoHabitacion);

                // Devolver las habitaciones disponibles como JSON
                return Ok(habitacionesDisponibles);
            }
            catch (Exception ex)
            {
                // Manejo de errores: Devolver un mensaje de error adecuado en caso de excepción
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al consultar habitaciones disponibles: {ex.Message}");
            }
        }*/

        [HttpGet("disponibilidades")]
        public IActionResult ConsultarDisponibilidad(DateTime fechaInicio, DateTime fechaFin, int? idTipoHabitacion)
        {
            HabitacionDatos habitacionDatos = new HabitacionDatos();
            if (fechaInicio >= fechaFin)
            {
                return BadRequest("La fecha inicial debe ser menor a la fecha final");
            }

            var disponibilidad = habitacionDatos.ConsultarDisponibilidad(fechaInicio, fechaFin, idTipoHabitacion);
            return Ok(disponibilidad);
        }
        //AQUI TERMINA NEW 04/07

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

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetHabitacionById(int id)
        {
            HabitacionRN rn = new HabitacionRN();
            Habitacion? habitacion = rn.GetHabitacionById(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            return Ok(habitacion);
        }

        [HttpDelete]
        [Route("delete/{roomId}")]
        public async Task<IActionResult> DeleteHabitacion(int roomId)
        {
            HabitacionRN rn = new HabitacionRN();
            rn.DeleteHabitacion(roomId);
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateHabitacion([FromBody] HabitacionDTO habitacionDTO)
        {
            HabitacionRN rn = new HabitacionRN();
            rn.CreateHabitacion(habitacionDTO);

            return Ok(new { success = true, message = "Habitación creada exitosamente" });
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateHabitacion(int id, [FromBody] HabitacionDTO habitacionDTO)
        {
            if (id != habitacionDTO.Id)
            {
                return BadRequest();
            }

            HabitacionRN rn = new HabitacionRN();
            try
            {
                rn.UpdateHabitacion(id, habitacionDTO);
                return Ok(new { success = true, message = "Habitación actualizada exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPut]
        [Route("activa")]
        public async Task<IActionResult> MarcarHabitacionActiva([FromBody] HabitacionDTO habitacionDTO)
        {
            HabitacionRN rn = new HabitacionRN();
            HabitacionDTO result = rn.MarcarHabitacionActiva(habitacionDTO);
            return Ok(result);
        }

    }
}
