using AW.AccesoDatos;
using AW.EntidadesDTO;
using Azure_Waters_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AW.ReglasNegocio
{
    public class TemporadaRN
    {
        private readonly TemporadaDatos temporadaDatos;

        public TemporadaRN()
        {
            temporadaDatos = new TemporadaDatos();
        }

        public async Task<List<TemporadaDTO>> GetTemporadas()
        {
            List<Temporada> temporadas = await temporadaDatos.GetTemporadas();
            List<TemporadaDTO> temporadaDTOs = new List<TemporadaDTO>();

            foreach (var temporada in temporadas)
            {
                temporadaDTOs.Add(TemporadaDTO.mapping(temporada));
            }

            return temporadaDTOs;
        }

        public async Task<TemporadaDTO> GetTemporada(int id)
        {
            Temporada temporada = await temporadaDatos.GetTemporadaAsync(id);
            return temporada != null ? TemporadaDTO.mapping(temporada) : null;
        }

        public async Task AddTemporada(TemporadaDTO temporadaDTO)
        {
            Temporada temporada = new Temporada
            {
                FechaInicio = temporadaDTO.FechaInicio,
                FechaFin = temporadaDTO.FechaFin,
                Descuento = temporadaDTO.Descuento,
                IdTipo = temporadaDTO.IdTipo
            };

            await temporadaDatos.AddTemporadaAsync(temporada);
        }

        public async Task<bool> ActualizarTemporada(int id, TemporadaDTO temporadaDTO)
        {
            Temporada temporada = new Temporada
            {
                IdTemporada = id,
                FechaInicio = temporadaDTO.FechaInicio,
                FechaFin = temporadaDTO.FechaFin,
                Descuento = temporadaDTO.Descuento,
                IdTipo = temporadaDTO.IdTipo
            };

            return await temporadaDatos.ActualizarTemporada(id, temporada);
        }

        public async Task<bool> EliminarTemporada(int id)
        {
            return await temporadaDatos.EliminarTemporada(id);
        }
    }
}
