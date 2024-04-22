using System;
using System.Collections.Generic;

namespace Azure_Waters_backend.Models;

public partial class Temporada
{
    public int IdTemporada { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public decimal? Descuento { get; set; }

    public int IdTipo { get; set; }

    public virtual TipoHabitacion IdTipoNavigation { get; set; } = null!;
}
