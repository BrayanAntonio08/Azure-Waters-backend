using AW.AccesoDatos;
using AW.EntidadesDTO;
using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.ReglasNegocio
{
    public class ReservaRN
    {
        private readonly ReservaDatos reservaDatos;

        public ReservaRN()
        {
            reservaDatos = new ReservaDatos();
        }

        public ReservaDTO Create(ReservaDTO reservaDTO)
        {
            ReservaDatos data = new ReservaDatos();

            //create the mapping of th object to a regular entity
            Reserva reserva = ReservaDTO.mapping(reservaDTO);
            Reserva saved = data.Create(reserva);

            return ReservaDTO.mapping(saved);
        }


        public List<ReservaDTO> GetReservaciones(int pageNumber, int pageSize)
        {
            var reservas = reservaDatos.GetReservaciones(pageNumber, pageSize);
            List<ReservaDTO> result = new List<ReservaDTO>();

            foreach (var reserva in reservas)
            {
                var reservaDTO = ReservaDTO.mapping(reserva);

                if (reserva.IdClienteNavigation != null)
                {
                    reservaDTO.Client_id = reserva.IdClienteNavigation.IdCliente;
                    reservaDTO.Client_name = reserva.IdClienteNavigation.Nombre;
                    reservaDTO.Client_lastname = reserva.IdClienteNavigation.Apellidos;
                    reservaDTO.Client_email = reserva.IdClienteNavigation.Email;
                    reservaDTO.Payment_card = reserva.IdClienteNavigation.TarjetaCredito;
                }

                result.Add(reservaDTO);
            }

            return result;
        }
    }
}
