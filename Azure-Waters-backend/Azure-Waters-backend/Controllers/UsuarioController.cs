using AW.AccesoDatos;
using AW.Entidades;
using Azure_Waters_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Azure_Waters_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        //private readonly AzureWatersContext _context = new AzureWatersContext();
        private UsuarioDatos usuarioDatos = new UsuarioDatos();

        [HttpGet]
        public async Task<IActionResult> GetUsuario()
        {
            List<Usuario> usuario = usuarioDatos.GetUsuario();

            if (usuario == null || usuario.Count == 0)
            {
                return NotFound("No users found.");
            }

            return Ok(usuario);
        }

        [HttpPost]
        [Route(nameof(buscarUsuario))]
        public IActionResult buscarUsuario(string usuario, string contrasenna)
        {
            UsuarioDatos usuarioDatos = new UsuarioDatos();
            var usuarioEncontrado = usuarioDatos.BuscarUsuario(usuario, contrasenna);

            if (usuarioEncontrado == null)
            {
                return Ok(new { error = "Usuario no encontrado o contraseña incorrecta." });
            }

            return Ok(usuarioEncontrado);
        }
    }

}