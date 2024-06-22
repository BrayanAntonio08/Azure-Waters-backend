using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Azure_Waters_backend.Models;

[Table("Temporada")]
public class Temporada
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("fecha_inicio")]
    [Required]
    public DateTime FechaInicio { get; set; }

    [Column("fecha_fin")]
    [Required]
    public DateTime FechaFin { get; set; }

    [Column("incremento")]
    [Required]
    [Range(0, 99.99)]
    public decimal Incremento { get; set; }
}
