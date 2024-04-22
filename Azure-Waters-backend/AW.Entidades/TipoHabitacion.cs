using System;
using System.Collections.Generic;

namespace Azure_Waters_backend.Models;

public partial class TipoHabitacion
{
    public int IdTipo { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public virtual ICollection<Habitacion> Habitacion { get; set; } = new List<Habitacion>();

    public virtual ICollection<Temporada> Temporada { get; set; } = new List<Temporada>();
}
