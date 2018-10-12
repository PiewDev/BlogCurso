using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDatos
{
    public interface ICategorias
    {
        string Nombre { get; set; }
        string Descripcion { get; set; }
        int Id { get; set; }
        bool Estado { get; set; }
        List<INotas> Notas { get; set; }

    }
}
