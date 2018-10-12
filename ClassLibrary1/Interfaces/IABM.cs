using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeNegocio
{
    public interface IABM<T, T2>
    {
        void Alta(T Crud, T2 Modelo);
        void Baja(T Crud, T2 Modelo);
        void Modificar(T Crud, T2 Modelo);
    }
}
