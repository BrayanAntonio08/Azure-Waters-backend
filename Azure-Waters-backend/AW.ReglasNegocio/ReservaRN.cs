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
        public ReservaDTO Create(ReservaDTO reservaDTO)
        {
            ReservaDatos data = new ReservaDatos();
            
            //create the mapping of th object to a regular entity
            Reserva reserva = ReservaDTO.Mapping(reservaDTO);
            Reserva saved = data.Create(reserva);

            return ReservaDTO.Mapping(saved);
        }
    }
}
