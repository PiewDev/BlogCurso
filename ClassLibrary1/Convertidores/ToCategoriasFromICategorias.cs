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
        private ConveridorColecciones<Notas> Converter;

        public ToCategoriasFromICategorias(ConveridorColecciones<Notas> Converter)
        {
            this.Converter = Converter;

        }
        public override void MapearInstancia(Categorias to, object from)
        {
            ICategorias fcategoria = from as ICategorias;
           
            to.Descripcion = fcategoria.Descripcion;
            to.Estado = fcategoria.Estado;
            to.Id = fcategoria.Id;
            to.Nombre = fcategoria.Nombre;
            to.Notas = this.Converter.Convertir(fcategoria.Notas);
        }
    }
}
