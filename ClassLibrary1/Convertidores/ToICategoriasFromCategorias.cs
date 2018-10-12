using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDatos;

namespace ModeloDeNegocio
{
 
    public class ToICategoriasFromCategorias<T> : ConveridorColecciones<T>
    where T : ICategorias, new()
    {
      
        public override void MapearInstancia(T to, object from)
        {
            Categorias fcategoria = (Categorias)from;
            to.Descripcion = fcategoria.Descripcion;
            to.Estado = fcategoria.Estado;
            to.Id = fcategoria.Id;
            to.Nombre = fcategoria.Nombre;
            

        }
       
    }
}

