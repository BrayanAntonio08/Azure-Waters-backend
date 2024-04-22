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
        public async Task<Usuario> buscarUsuario(string usuario, string contrasenna)
        {
            Usuario login = new Usuario();
            var buscarLogin = new Usuario();
            using (var _context = new AzureWatersContext())
            {
                buscarLogin = await (from ua in _context.Usuario
                                     where ua.NombreUsuario == usuario && ua.Contrasenna == contrasenna
                                     select new Usuario
                                     {
                                         Id = ua.Id,
                                         NombreUsuario = ua.NombreUsuario,
                                         Contrasenna = ua.Contrasenna
                                     }).FirstOrDefaultAsync();
            }

            if (buscarLogin == null)
            {
                login.Id = null;
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