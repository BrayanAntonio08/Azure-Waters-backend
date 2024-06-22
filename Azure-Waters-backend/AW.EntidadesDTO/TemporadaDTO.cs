using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.EntidadesDTO
{
    public class TemporadaDTO
    {
        public int Id { get; set; }

        public DateOnly FechaInicio { get; set; }

        public DateOnly FechaFin { get; set; }

        public decimal Incremento { get; set; }
        
        private static DateTime convert(DateOnly date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }
        private static DateOnly convert(DateTime date)
        {
            return new DateOnly(date.Year, date.Month, date.Day);
        }

        public static TemporadaDTO mapping(Temporada temporada)
        {
       
            return new TemporadaDTO
            {
                Id = temporada.Id,
                FechaInicio = convert(temporada.FechaInicio),
                FechaFin = convert(temporada.FechaFin),
                Incremento = temporada.Incremento
            };
        }

        public static Temporada mapping(TemporadaDTO temporada)
        {
            return new Temporada
            {
                Id = temporada.Id,
                FechaInicio = convert(temporada.FechaInicio),
                FechaFin = convert(temporada.FechaFin),
                Incremento = temporada.Incremento
            };
        }

        public static IEnumerable<TemporadaDTO> mapping(IEnumerable<Temporada> data)
        {
            return data.Select(mapping);
        }
        public static IEnumerable<Temporada> mapping(IEnumerable<TemporadaDTO> data)
        {
            return data.Select(mapping);
        }
    }
}
