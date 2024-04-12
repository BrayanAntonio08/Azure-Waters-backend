using System;
using System.Collections.Generic;

namespace Azure_Waters_backend.Models;

public partial class Usuario
{
    public int? UsuarioId { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contrasenna { get; set; } = null!;
}
