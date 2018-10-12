using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDatos
{
    public interface IFactoryDatos<T>
    {
        T NuevaInstancia();
    }

}
