using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDatos;

namespace ModeloDeNegocio
{
    public class FactoryCategoria : IFactoryDatos<ICategorias>
    {
        public ICategorias NuevaInstancia()
        {
            return new Categoria();
        }
    }
}
