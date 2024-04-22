using System;
using System.Collections.Generic;

namespace Azure_Waters_backend.Models;

public partial class Pagina
{
    public int PaginaId { get; set; }

    public string? Nombre { get; set; }

    public string? Texto { get; set; }

    public virtual ICollection<Imagen> Imagen { get; set; } = new List<Imagen>();
}
