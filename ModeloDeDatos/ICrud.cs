using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDatos
{
    interface ICrud<T> where T: class, new()
    {
        int Crear(T Modelo);
        void Eliminar(int Id);
        int Actualizar(T Modelo);
        List<T> Listar(int Max = 10);
    }
}
