using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AW.EntidadesDTO.interfaces;
using Azure_Waters_backend.Models;

namespace AW.EntidadesDTO
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public string? Guid { get; set; }
        public DateTime? Arriving { get; set; }
        public DateTime? Departing { get; set; }
        public int? Room_type_id { get; set; }
        public HabitacionRevisionDTO? Room { get; set; }

        // client attributes
        public string Client_id { get; set; }
        public string Client_name { get; set; }
        public string Client_lastname { get; set; }
        public string Client_email { get; set; }
        public string Payment_card { get; set; }


        public static ReservaDTO Mapping(Reserva reserva)
        {
            return new ReservaDTO
            {
                Id = reserva.IdReserva,
                Guid = reserva.Guid,
                Arriving = reserva.FechaInicio,
                Departing = reserva.FechaFin,
                Room_type_id = reserva.IdHabitacionNavigation.IdTipo,
                Room = HabitacionRevisionDTO.mapping(reserva.IdHabitacionNavigation, reserva.IdHabitacionNavigation.IdTipoNavigation)
            };
        }

        public static Reserva Mapping(ReservaDTO reservaDTO)
        {
            Reserva res = new Reserva()
            {
                IdReserva = reservaDTO.Id,
                FechaFin = reservaDTO.Departing,
                FechaInicio = reservaDTO.Arriving,
                Guid = reservaDTO.Guid,
                IdCliente = reservaDTO.Client_id,
                IdClienteNavigation = new Cliente
                {
                    IdCliente = reservaDTO.Client_id,
                    Nombre = reservaDTO.Client_name,
                    Apellidos = reservaDTO.Client_lastname,
                    Email = reservaDTO.Client_email,
                    TarjetaCredito = reservaDTO.Payment_card
                },
                IdHabitacion = reservaDTO.Room.Id
            };

            return res;
        }
    }
}
