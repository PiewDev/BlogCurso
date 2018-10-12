using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDatos
{
    public interface INotas
    {
        int Id { get; set; }
        string Titulo { get; set; }
        string Cuerpo { get; set; }
        string Autor { get; set; }
        DateTime FechaCreacion { get; set; }
        DateTime? FechaModificacion { get; set; }
        DateTime? FechaBaja { get; set; }
        bool Estado { get; set; }
        List<ITags> Tags { get; set; }
        List<ICategorias> Categorias { get; set; }

    }
}
