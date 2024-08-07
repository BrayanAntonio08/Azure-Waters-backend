﻿using AW.AccesoDatos;
using AW.EntidadesDTO;
using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.ReglasNegocio
{
    public class HabitacionRN
    {

        public List<TipoHabitacionDTO> GetTiposHabitacion()
        {
            HabitacionDatos datos = new HabitacionDatos();
            List<TipoHabitacion> request = datos.GetTiposHabitacion();
            List<TipoHabitacionDTO> response = new List<TipoHabitacionDTO>();
            foreach(TipoHabitacion aux in request)
            {
                response.Add(TipoHabitacionDTO.mapping(aux));
            }
            return response;
        }

        public List<HabitacionDTO> GetHabitaciones()
        {
            HabitacionDatos datos = new HabitacionDatos();
            List<Habitacion> request = datos.GetHabitaciones();
            List<HabitacionDTO> response = new List<HabitacionDTO>();
            foreach (Habitacion aux in request)
            {
                response.Add(HabitacionDTO.mapping(aux));
            }
            return response;
        }


        public async Task<List<Habitacion>> ObtenerHabitacionesDisponibles(DateTime fechaInicio, DateTime fechaFinal, int? idTipoHabitacion)
        {
            HabitacionDatos datos = new HabitacionDatos();

            var habitacionesActivas = datos.GetAllHabitacionesActivas();

            var habitacionesDisponibles = new List<Habitacion>();
            foreach (var habitacion in habitacionesActivas)
            {
                if (habitacion.Activa == true && habitacion.Reservada == false)
                {
                    var reservas = datos.GetReservasHabitacion(habitacion.IdHabitacion, fechaInicio, fechaFinal);
                    if (reservas.Count == 0)
                    {
                        habitacionesDisponibles.Add(habitacion);
                    }
                }
            }
            if (idTipoHabitacion != null)
            {
                habitacionesDisponibles = habitacionesDisponibles.Where(h => h.IdTipo == idTipoHabitacion).ToList();
            }

            return habitacionesDisponibles;
        }

        public void UpdateTipoHabitacion(TipoHabitacionDTO tipoHabitacionDTO)
        {
            HabitacionDatos datos = new HabitacionDatos();
            TipoHabitacion request = TipoHabitacionDTO.mapping(tipoHabitacionDTO);
            datos.UpdateTipoHabitacion(request);
            TipoHabitacion tipoHabitacion = datos.GetTipoHabitacionById(tipoHabitacionDTO.Id);
            if (tipoHabitacion != null)
            {
                tipoHabitacion.Nombre = tipoHabitacionDTO.Name;
                tipoHabitacion.Precio = tipoHabitacionDTO.Price;
                tipoHabitacion.Descripcion = tipoHabitacionDTO.Description;
                tipoHabitacion.ImagenId = tipoHabitacionDTO.ImagenId;
                //tipoHabitacion.Imagen = tipoHabitacionDTO.Image != null ? new Imagen
                //{
                //    Id = tipoHabitacionDTO.Image.Id,
                //    Alt = tipoHabitacionDTO.Image.Alt,
                //    Url = tipoHabitacionDTO.Image.Url
                //} : null;
                datos.UpdateTipoHabitacion(tipoHabitacion);
            }
        }

        public HabitacionRevisionDTO? RevisarHabitacion(ReservaDTO consulta)
        {
            HabitacionDatos habitacionDatos = new HabitacionDatos();
            Habitacion? resultado = habitacionDatos.RevisarHabitacion(consulta.Arriving, consulta.Departing, consulta.Room_type_id);
            if(resultado != null)
            {
                TipoHabitacion tipo = habitacionDatos.GetTiposHabitacion().FirstOrDefault(t => t.IdTipo == resultado.IdTipo);
                HabitacionRevisionDTO habitacionLibre = HabitacionRevisionDTO.mapping(resultado, tipo);

                // calcular precio final
                ReservaDatos reservaDatos = new ReservaDatos();
                decimal finalPrice = 0;
                for (DateTime fecha = (DateTime)consulta.Arriving; fecha <= consulta.Departing; fecha = fecha.AddDays(1))
                {
                    finalPrice += reservaDatos.CalculateDayCost(fecha, (int)consulta.Room_type_id);
                }
                habitacionLibre.Price = finalPrice;
                return habitacionLibre;
            }
            return null;
        }

        public void LiberarHabitacion(int idRoom)
        {
            HabitacionDatos data = new HabitacionDatos();
            data.LiberarHabitacion(idRoom);
        }

        public Habitacion? GetHabitacionById(int id)
        {
            HabitacionDatos datos = new HabitacionDatos();
            return datos.GetHabitacionById(id);
        }

        public void DeleteHabitacion(int id)
        {
            HabitacionDatos datos = new HabitacionDatos();
            Habitacion? room = datos.GetHabitacionById(id);
            if (room != null)
            {
                datos.DeleteHabitacion(room);
            }
        }

        public void CreateHabitacion(HabitacionDTO habitacionDTO)
        {
            HabitacionDatos datos = new HabitacionDatos();

            Habitacion habitacion = new Habitacion
            {
                Numero = habitacionDTO.Number,
                IdTipo = habitacionDTO.Type_id,
                Activa = habitacionDTO.Active,
                Reservada = habitacionDTO.Reserved,
                Revision = habitacionDTO.Checking
            };

            datos.CreateHabitacion(habitacion);
        }

        public void UpdateHabitacion(int id, HabitacionDTO habitacionDTO)
        {
            HabitacionDatos datos = new HabitacionDatos();

            Habitacion habitacionExistente = datos.GetHabitacionById(id);
            if (habitacionExistente == null)
            {
                throw new Exception("La habitación no existe");
            }

            habitacionExistente.Numero = habitacionDTO.Number;
            habitacionExistente.IdTipo = habitacionDTO.Type_id;
            habitacionExistente.Activa = habitacionDTO.Active;
            habitacionExistente.Reservada = habitacionDTO.Reserved;
            habitacionExistente.Revision = habitacionDTO.Checking;

            datos.UpdateHabitacion(habitacionExistente);
        }

        public HabitacionDTO? MarcarHabitacionActiva(HabitacionDTO dto)
        {
            HabitacionDatos data = new HabitacionDatos();
            bool activa = dto.Active != null? (bool)dto.Active: false;
            Habitacion? result = data.MarcarHabitacionActiva(dto.Id, activa);
            if(result != null)
            {
                return HabitacionDTO.mapping(result);
            }
            return null;
        }
    }
}
