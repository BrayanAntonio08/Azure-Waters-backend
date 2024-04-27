using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.EntidadesDTO
{
    public class TemporadaDTO
    {
        public int IdTemporada { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public decimal? Descuento { get; set; }

        public int IdTipo { get; set; }

        public static TemporadaDTO mapping(Temporada temporada)
        {
            return new TemporadaDTO
            {
                IdTemporada = temporada.IdTemporada,
                FechaInicio = temporada.FechaInicio,
                FechaFin = temporada.FechaFin,
                Descuento = temporada.Descuento,
                IdTipo = temporada.IdTipo
            };
        }
    }
}
