using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDatos;

namespace ModeloDeNegocio
{ 

    public class ABMCategorias : IABM<ICrud<ICategorias>, ICategorias>
    {
        public void Alta(ICrud<ICategorias> Crud, ICategorias Modelo)
        {
            Crud.Crear(Modelo);
        }

        public void Baja(ICrud<ICategorias> Crud, ICategorias Modelo)
        {
            Crud.Eliminar(Modelo.Id);
        }

        public void Modificar(ICrud<ICategorias> Crud, ICategorias Modelo)
        {
            Crud.Actualizar(Modelo); 
        }
    }
}
