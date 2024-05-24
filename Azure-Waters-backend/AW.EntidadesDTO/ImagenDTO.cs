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
        public static Imagen mapping(ImagenDTO value) {
            return new Imagen()
            {
                Id = value.Id,
                Alt = value.Alt,
                Url = value.Url
            };
        }

        public static ICollection<Imagen> mapping (IEnumerable<ImagenDTO> value)
        {
            return value.Select(mapping).ToList();
        }

        public static ICollection<ImagenDTO> mapping(IEnumerable<Imagen> value)
        {
            return value.Select(mapping).ToList();
        }
    }
}