using Azure_Waters_backend.Models;

namespace AW.EntidadesDTO
{
    public class ImagenDTO
    {
        public int Id {get; set;}
        public string? Alt {get; set;}
        public string? Url {get; set;}

        public static ImagenDTO mapping(Imagen value){
            return new ImagenDTO{
                Id = value.Id,
                Alt = value.Alt,
                Url = value.Url
            };
        }
    }
}