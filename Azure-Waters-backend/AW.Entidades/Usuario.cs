using System;
using System.Collections.Generic;

namespace Azure_Waters_backend.Models;

public partial class Usuario
{
    public int? Id { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Contrasenna { get; set; }
}
