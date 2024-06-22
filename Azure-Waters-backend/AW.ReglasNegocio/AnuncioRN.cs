using AW.AccesoDatos;
using AW.EntidadesDTO;
using Azure_Waters_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.ReglasNegocio
{
    public class AnuncioRN
    {
        public List<AnuncioDTO> ListAnuncios()
        {
            AnuncioDatos data = new AnuncioDatos();
            return AnuncioDTO.mapping(data.ListAnuncios());
        }

        public AnuncioDTO CreateAnuncio(AnuncioDTO anuncio)
        {
            AnuncioDatos data = new AnuncioDatos();
            Anuncio result = data.CreateAnuncio(AnuncioDTO.mapping(anuncio));
            return AnuncioDTO.mapping(result);  
        }

        public AnuncioDTO UpdateAnuncio(AnuncioDTO anuncio)
        {
            AnuncioDatos data = new AnuncioDatos();
            Anuncio result = data.UpdateAnuncio(AnuncioDTO.mapping(anuncio));
            return AnuncioDTO.mapping(result);
        }

        public bool DeleteAnuncio(AnuncioDTO anuncio)
        {
            AnuncioDatos data = new AnuncioDatos();
            return data.DeleteAnuncio(AnuncioDTO.mapping(anuncio));
        }
    }
}
