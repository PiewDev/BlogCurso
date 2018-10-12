using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDatos;

namespace ModeloDeNegocio
{

    public class ToCategoriasFromICategorias : ConveridorColecciones<Categorias>
    {
                        
        public override void MapearInstancia(Categorias to, object from)
        {
            ICategorias fcategoria = from as ICategorias;
           
            to.Descripcion = fcategoria.Descripcion;
            to.Estado = fcategoria.Estado;
            to.Id = fcategoria.Id;
            to.Nombre = fcategoria.Nombre;
           
        }
    }
}
