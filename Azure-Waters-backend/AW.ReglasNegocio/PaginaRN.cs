using AW.AccesoDatos;
using AW.EntidadesDTO;
using Azure_Waters_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.ReglasNegocio
{
    public class PaginaRN
    {
        public PaginaDTO? GetPagina(string titulo)
        {
            PaginaDatos paginaDatos = new PaginaDatos();
            Pagina pagina = paginaDatos.GetPagina(titulo);

            return pagina != null ? PaginaDTO.mapping(pagina) : null;
        }

        public void UpdatePagina(PaginaDTO dto)
        {
            PaginaDatos datos = new PaginaDatos();
            Pagina pagina = PaginaDTO.mapping(dto);  

            datos.Update(pagina);
        }
    }
}
