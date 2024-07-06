                                                                                                                                 using System;
using System.Collections.Generic;

namespace Azure_Waters_backend.Models;

public partial class Cliente
{
    public string IdCliente { get; set; } = null!;

    public string? Nombre { get; set; }
                
    public string? Apellidos { get; set; }

    public string? Email { get; set; }

    public string? TarjetaCredito { get; set; }

    public virtual ICollection<Reserva> Reserva { get; set; } = new List<Reserva>();
}
