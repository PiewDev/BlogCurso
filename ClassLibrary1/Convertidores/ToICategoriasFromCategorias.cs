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
        private ConveridorColecciones<Nota> Converter;

        public ToICategoriasFromCategorias(ConveridorColecciones<Nota> Converter)
        {
            this.Converter = Converter;

        }

        public override void MapearInstancia(T to, object from)
        {
            Categorias fcategoria = (Categorias)from;
            to.Descripcion = fcategoria.Descripcion;
            to.Estado = fcategoria.Estado;
            to.Id = fcategoria.Id;
            to.Nombre = fcategoria.Nombre;
            to.Notas = this.Converter.Convertir(fcategoria.Notas.ToList()).Cast<INotas>().ToList();

        }
       
    }
}

