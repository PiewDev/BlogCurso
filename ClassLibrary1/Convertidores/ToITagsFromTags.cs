using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDatos;

namespace ModeloDeNegocio
{

    public class ToITagsFromTags<T> : ConveridorColecciones<T>
    where T : ITags, new()
    {
        private ConveridorColecciones<Nota> Converter;

        public ToITagsFromTags (ConveridorColecciones<Nota> Converter)
        {
            this.Converter = Converter;

        }

        public override void MapearInstancia(T to, object from)
        {
            Tags ftags = (Tags)from;
            
            to.Estado = ftags.Estado;
            to.Id = ftags.Id;
            to.Nombre = ftags.Nombre;
            to.Notas = this.Converter.Convertir(ftags.Notas.ToList()).Cast<INotas>().ToList();

        }
    }
}
