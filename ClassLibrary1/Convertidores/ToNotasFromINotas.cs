using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDatos;

namespace ModeloDeNegocio
{
    public class ToNotasFromINotas : ConveridorColecciones<Notas>
    {
        private ConveridorColecciones<Categorias> CategoriaConverter;
        private ConveridorColecciones<Tags> TagConverter;

        public ToNotasFromINotas(ConveridorColecciones<Categorias> CategoriaConverter, ConveridorColecciones<Tags> TagConverter)
        {
            this.CategoriaConverter = CategoriaConverter;
            this.TagConverter = TagConverter;
        }

        public override void MapearInstancia(Notas to, object from)
        {

            INotas fnota = from as INotas;

            to.Autor = fnota.Autor;
            to.Cuerpo = fnota.Cuerpo;
            to.Estado = fnota.Estado;
            to.FechaBaja = fnota.FechaBaja;
            to.FechaCreacion = fnota.FechaCreacion;
            to.FechaModificacion = fnota.FechaModificacion;
            to.Id = fnota.Id;
            to.Titulo = fnota.Titulo;
            to.Categorias = this.CategoriaConverter.Convertir(fnota.Categorias);
            to.Tags = this.TagConverter.Convertir(fnota.Tags);
        }
    }
}
