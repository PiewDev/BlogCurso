using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDatos
{
    public abstract class ConveridorColecciones<T1>
          where T1 : new()
    {
        public IList<T1> Convertir(IList objetos)
        {
            IList<T1> resultado = new List<T1>();

            foreach (var obj in objetos)
            {
                T1 nuevoobj = new T1();
                this.MapearInstancia(nuevoobj, obj);
                resultado.Add(nuevoobj);
            }

            return resultado;
        }

        public abstract void MapearInstancia(T1 to, object from);
    }
}
