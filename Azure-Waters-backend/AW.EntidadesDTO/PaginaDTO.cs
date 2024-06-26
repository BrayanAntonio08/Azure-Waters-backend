using Azure_Waters_backend.Models;

namespace AW.EntidadesDTO
{
    public class PaginaDTO
    {

        public int Id {get; set;}
        public string Titulo {get; set;}
        public string Texto {get; set;}
        public List<ImagenDTO> Imagenes {get; set;}


        public static PaginaDTO mapping(Pagina pagina)
        {
            return new PaginaDTO
            {
                Id = pagina.PaginaId,
                Titulo = pagina.Nombre,
                Texto = pagina.Texto,
            };
        }

        public static Pagina mapping(PaginaDTO pagina)
        {
            return new Pagina
            {
                PaginaId = pagina.Id,
                Nombre = pagina.Titulo,
                Texto = pagina.Texto,
                Imagen = ImagenDTO.mapping(pagina.Imagenes).ToList()
            };
        }
    }
}