using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDatos;

namespace ModeloDeNegocio
{
    public class FactoryTag : IFactoryDatos<ITags>
    {
        public ITags NuevaInstancia()
        {
            return new Tag();
        }
    }
}
