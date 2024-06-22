using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.EntidadesDTO
{
    public class AnuncioDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public ImagenDTO Image { get; set; }

        public static AnuncioDTO mapping(Anuncio anuncio)
        {
            return new AnuncioDTO()
            {
                Id = anuncio.AnuncioId,
                Url = anuncio.Url,
                Image = ImagenDTO.mapping(anuncio.Imagen)
            };
        }

        public static Anuncio mapping(AnuncioDTO anuncio)
        {
            return new Anuncio()
            {
                AnuncioId = anuncio.Id,
                Url = anuncio.Url,
                ImagenId = anuncio.Image.Id,
                Imagen = ImagenDTO.mapping(anuncio.Image)
            };
        }

        public static List<AnuncioDTO> mapping(IEnumerable<Anuncio> anuncio)
        {
            return anuncio.Select(a => mapping(a)).ToList();
        }

        public static List<Anuncio> mapping(IEnumerable<AnuncioDTO> anuncio)
        {
            return anuncio.Select(a => mapping(a)).ToList();
        }
    }
}
