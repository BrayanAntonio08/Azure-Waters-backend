using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Entidades
{
    [Table("Oferta")]
    public class Oferta
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

        [Column("descuento", TypeName = "NUMERIC(4,2)")]
        [Required]
        public decimal Descuento { get; set; }

        [Column("id_tipo_habitacion")]
        [Required]
        public int IdTipoHabitacion { get; set; }

        [ForeignKey("IdTipoHabitacion")]
        public TipoHabitacion TipoHabitacion { get; set; }
    }
}
