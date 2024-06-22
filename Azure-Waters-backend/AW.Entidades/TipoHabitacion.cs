using AW.Entidades;
using System;
using System.Collections.Generic;

namespace Azure_Waters_backend.Models;

public partial class TipoHabitacion
{
    public int IdTipo { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }
    
    public int? ImagenId { get; set; }

    public virtual Imagen? Imagen { get; set; }

    public virtual ICollection<Habitacion> Habitacion { get; set; } = new List<Habitacion>();

    public virtual ICollection<Oferta> Ofertas { get; set; } = new List<Oferta>();
}
