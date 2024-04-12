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

        [HttpPost]
        [Route(nameof(buscarUsuario))]
        public async Task<Usuario> buscarUsuario(string usuario, string contrasenna)
        {
            Usuario login = new Usuario();
            var buscarLogin = new Usuario();
            using (var _context = new AzureWatersContext())
            {
                buscarLogin = await (from ua in _context.Usuarios
                                     where ua.NombreUsuario == usuario && ua.Contrasenna == contrasenna
                                     select new Usuario
                                     {
                                         UsuarioId = ua.UsuarioId,
                                         NombreUsuario = ua.NombreUsuario,
                                         Contrasenna = ua.Contrasenna
                                     }).FirstOrDefaultAsync();
            }

            if (buscarLogin == null)
            {
                login.UsuarioId = null;
                login.NombreUsuario = null;
            }
            else
            {
                login = buscarLogin;
            }
            return login;
        }
    }

}