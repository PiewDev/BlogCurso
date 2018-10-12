using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDatos;

namespace ModeloDeNegocio
{
    
    public class ToTagsFromITags : ConveridorColecciones<Tags>
    {
        private ConveridorColecciones<Notas> Converter;

        public ToTagsFromITags(ConveridorColecciones<Notas> Converter)
        {
            this.Converter = Converter;

        }

        public override void MapearInstancia(Tags to, object from)
        {
            ITags ftags = from as ITags;

            
            to.Estado = ftags.Estado;
            to.Id = ftags.Id;
            to.Nombre = ftags.Nombre;
            to.Notas = this.Converter.Convertir(ftags.Notas);
        }
    }
}
