using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDatos;

namespace ModeloDeNegocio
{

    public class ABMNotas : IABM<ICrud<INotas>, INotas>
    {
        public void Alta(ICrud<INotas> Crud, INotas Modelo)
        {
            Crud.Crear(Modelo);
        }

        public void Baja(ICrud<INotas> Crud, INotas Modelo)
        {
            Crud.Eliminar(Modelo.Id);
        }

        public void Modificar(ICrud<INotas> Crud, INotas Modelo)
        {
            Crud.Actualizar(Modelo);
        }
    }
}
