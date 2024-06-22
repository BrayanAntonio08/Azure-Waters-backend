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

        public async Task<TemporadaDTO> AddTemporada(TemporadaDTO temporadaDTO)
        {
            Temporada temporada = TemporadaDTO.mapping(temporadaDTO);

            Temporada result = await temporadaDatos.AddTemporadaAsync(temporada);
            return TemporadaDTO.mapping(result);
        }

        public async Task<bool> ActualizarTemporada(TemporadaDTO temporadaDTO)
        {
            Temporada temporada = TemporadaDTO.mapping(temporadaDTO);

            return await temporadaDatos.ActualizarTemporada(temporada);
        }

        public async Task<List<TemporadaDTO>> ActualizarGeneral(List<TemporadaDTO> temporadaDTO)
        {
            List<Temporada> temporada = TemporadaDTO.mapping(temporadaDTO).ToList();

            return TemporadaDTO.mapping(await temporadaDatos.ActualizarGeneral(temporada)).ToList();
        }

        public async Task<bool> EliminarTemporada(int id)
        {
            return await temporadaDatos.EliminarTemporada(id);
        }
    }
}
