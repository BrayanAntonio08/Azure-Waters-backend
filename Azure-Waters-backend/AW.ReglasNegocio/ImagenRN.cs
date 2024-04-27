using AW.AccesoDatos;
using AW.EntidadesDTO;
using Azure_Waters_backend.Models;

namespace AW.ReglasNegocio{
    public class ImagenRN{
        public List<ImagenDTO> GetImagenesPagina(string nombrePagina){
            List<Imagen> datos = new ImagenDatos().GetImagenes(nombrePagina);
            List<ImagenDTO> resultado = new List<ImagenDTO>();
            foreach(Imagen img in datos){
                resultado.Add(ImagenDTO.mapping(img));
            }
            return resultado;
        }

    }
}