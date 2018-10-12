using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDatos;

namespace ModeloDeNegocio
{
    public class ToINotasFromNotas<T> : ConveridorColecciones<T>
      where T : INotas, new()
    {
        private ConveridorColecciones<Categoria> CategoriaConverter;
        private ConveridorColecciones<Tag> TagConverter;

        public ToINotasFromNotas(ConveridorColecciones<Categoria> CategoriaConverter, ConveridorColecciones<Tag> TagConverter)
        {
            this.CategoriaConverter = CategoriaConverter;
            this.TagConverter = TagConverter;
        }
        public override void MapearInstancia(T to, object from)
        {
            Notas fnota = (Notas)from;
            
            to.Autor = fnota.Autor;
            to.Cuerpo = fnota.Cuerpo;
            to.Estado = fnota.Estado;
            to.FechaBaja = fnota.FechaBaja;
            to.FechaCreacion = fnota.FechaCreacion;
            to.FechaModificacion = fnota.FechaModificacion;
            to.Id = fnota.Id;
            to.Titulo = fnota.Titulo;
            to.Categorias = this.CategoriaConverter.Convertir(fnota.Categorias.ToList()).Cast<ICategorias>().ToList();
            to.Tags = this.TagConverter.Convertir(fnota.Tags.ToList()).Cast<ITags>().ToList();
        }
    }
}
