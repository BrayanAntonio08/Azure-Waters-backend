using System;
using System.Collections.Generic;

namespace Azure_Waters_backend.Models;

public partial class Habitacion
{
    public int IdHabitacion { get; set; }

    public int Numero { get; set; }

    public int? IdTipo { get; set; }

    public bool? Activa { get; set; }

    public bool? Reservada { get; set; }

    public bool? Revision { get; set; }

    public virtual TipoHabitacion? IdTipoNavigation { get; set; }

    public virtual ICollection<Reserva> Reserva { get; set; } = new List<Reserva>();
}
