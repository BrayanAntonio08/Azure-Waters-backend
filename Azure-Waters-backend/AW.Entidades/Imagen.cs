using System;
using System.Collections.Generic;

namespace Azure_Waters_backend.Models;

public partial class Imagen
{
    public int Id { get; set; }

    public string? Alt { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<Anuncio> Anuncio { get; set; } = new List<Anuncio>();

    public virtual ICollection<Facilidad> Facilidad { get; set; } = new List<Facilidad>();
    
    public virtual ICollection<TipoHabitacion> TipoHabitacion { get; set; } = new List<TipoHabitacion>();

    public virtual ICollection<Pagina> Pagina { get; set; } = new List<Pagina>();
}
