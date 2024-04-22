using System;
using System.Collections.Generic;

namespace Azure_Waters_backend.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public int? IdHabitacion { get; set; }

    public string? IdCliente { get; set; }

    public string? Guid { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Habitacion? IdHabitacionNavigation { get; set; }
}
