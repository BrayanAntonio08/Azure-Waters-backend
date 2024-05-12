using AW.EntidadesDTO.interfaces;
using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.EntidadesDTO
{
    public class HabitacionDTO : IHabitacionDTO
    {
        public int Id { get; set; }
        public int Number {  get; set; }
        public int? Type_id { get; set; }
        public bool? Active { get; set; }
        public bool? Reserved { get; set; }
        public bool? Checking { get; set; }


        public static HabitacionDTO mapping(Habitacion value)
        {
            return new HabitacionDTO
            {
                Id = value.IdHabitacion,
                Number = value.Numero,
                Type_id = value.IdTipo,
                Active = value.Activa,
                Reserved = value.Reservada,
                Checking = value.Revision,
            };
        }
    }
}
