using AW.AccesoDatos;
using AW.Entidades;
using AW.EntidadesDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.ReglasNegocio
{
    public class OfertaRN
    {
        public OfertaDTO Create(OfertaDTO oferta)
        {
            OfertaDatos ofertaDatos = new OfertaDatos();
            Oferta result = ofertaDatos.Create(OfertaDTO.Map(oferta));
            return OfertaDTO.Map(result);
        }

        public List<OfertaDTO> GetAll()
        {
            OfertaDatos ofertaDatos = new OfertaDatos();
            return OfertaDTO.Map(ofertaDatos.GetAll()).ToList();

        }

        public List<OfertaDTO> GetByDate(DateTime date)
        {
            OfertaDatos ofertaDatos = new OfertaDatos();
            return OfertaDTO.Map(ofertaDatos.GetByDate(date)).ToList();
        }

        public OfertaDTO Update(OfertaDTO oferta)
        {
            OfertaDatos ofertaDatos = new OfertaDatos();
            return OfertaDTO.Map(ofertaDatos.Update(OfertaDTO.Map(oferta)));
        }

        public bool Delete(int id)
        {
            OfertaDatos ofertaDatos = new OfertaDatos();
            return ofertaDatos.Delete(id);
        }
    }
}
