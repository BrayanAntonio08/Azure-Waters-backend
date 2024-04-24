namespace AW.EntidadesDTO
{
    public class PaginaDTO
    {

        public int Id {get; set;}
        public string Titulo {get; set;}
        public string Texto {get; set;}
        public List<ImagenDTO> Imagenes {get; set;}
    }
}