using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDatos
{
    public interface ITags
    {
        int Id { get; set; }
        string Nombre { get; set; }
        List<INotas> Notas { get; set; }
        bool Estado { get; set; }

    }
}
