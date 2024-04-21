using System;
using System.Collections.Generic;

namespace AW.Entidades;

public partial class Usuario
{
    public int? UsuarioId { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contrasenna { get; set; } = null!;
}
