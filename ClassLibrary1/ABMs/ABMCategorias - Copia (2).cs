using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDatos;

namespace ModeloDeNegocio
{

    public class ABMTags : IABM<ICrud<ITags>, ITags>
    {
        public void Alta(ICrud<ITags> Crud, ITags Modelo)
        {
            Crud.Crear(Modelo);
        }

        public void Baja(ICrud<ITags> Crud, ITags Modelo)
        {
            Crud.Eliminar(Modelo.Id);
        }

        public void Modificar(ICrud<ITags> Crud, ITags Modelo)
        {
            Crud.Actualizar(Modelo);
        }
    }
}
