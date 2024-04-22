using System;
using System.Collections.Generic;

namespace Azure_Waters_backend.Models;

public partial class Facilidad
{
    public int FacilidadId { get; set; }

    public string? Texto { get; set; }

    public int? ImagenId { get; set; }

    public virtual Imagen? Imagen { get; set; }
}
