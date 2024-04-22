using System;
using System.Collections.Generic;

namespace Azure_Waters_backend.Models;

public partial class Anuncio
{
    public int AnuncioId { get; set; }

    public int? ImagenId { get; set; }

    public string? Url { get; set; }

    public virtual Imagen? Imagen { get; set; }
}
