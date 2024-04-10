using Azure_Waters_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Azure_Waters_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AzureWatersContext _context = new AzureWatersContext();


        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.FromSqlRaw("EXEC ObtenerUsuarios").ToListAsync();

            if (usuarios == null || usuarios.Count == 0)
            {
                return NotFound("No users found.");
            }

            return Ok(usuarios);
        }
    }

}