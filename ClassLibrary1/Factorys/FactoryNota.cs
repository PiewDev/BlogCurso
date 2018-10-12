using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDatos;

namespace ModeloDeNegocio
{
    public class FactoryNota : IFactoryDatos<INotas>
    {
        public INotas NuevaInstancia()
        {
            return new Nota(); 
        }
    }
}
