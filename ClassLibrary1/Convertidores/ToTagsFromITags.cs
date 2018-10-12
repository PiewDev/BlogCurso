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
        

        public override void MapearInstancia(Tags to, object from)
        {
            ITags ftags = from as ITags;

            
            to.Estado = ftags.Estado;
            to.Id = ftags.Id;
            to.Nombre = ftags.Nombre;
            
        }
    }
}
