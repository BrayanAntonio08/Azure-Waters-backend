using AW.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.EntidadesDTO
{
    public class OfertaDTO
    {
        public int Id { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public decimal Discount { get; set; }
        public int Room_type_id { get; set; }
        public string? Room_type_name { get; set; }

        public static OfertaDTO Map(Oferta oferta) => new OfertaDTO
        {
            Id = oferta.Id,
            Start = new DateOnly(oferta.FechaInicio.Year, oferta.FechaInicio.Month, oferta.FechaInicio.Day),
            End = new DateOnly(oferta.FechaFin.Year, oferta.FechaFin.Month, oferta.FechaFin.Day),
            Discount = oferta.Descuento,
            Room_type_id = oferta.IdTipoHabitacion,
            Room_type_name = oferta.TipoHabitacion.Nombre
        };

        public static Oferta Map(OfertaDTO dto)
        {
            return new Oferta()
            {
                Id = dto.Id,
                FechaFin = new DateTime(dto.End.Year, dto.End.Month, dto.End.Day),
                FechaInicio = new DateTime(dto.Start.Year, dto.Start.Month, dto.Start.Day),
                Descuento = dto.Discount,
                IdTipoHabitacion = dto.Room_type_id
            };
        }

        public static IEnumerable<OfertaDTO> Map(IEnumerable<Oferta> map)
        {
            return map.Select(x => Map(x));
        }
        public static IEnumerable<Oferta> Map(IEnumerable<OfertaDTO> map)
        {
            return map.Select(x => Map(x));
        }
    }
}
