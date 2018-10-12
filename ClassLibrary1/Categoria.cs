using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDatos;

namespace ModeloDeNegocio
{
    public class Categoria : ICategorias
    {
        public string Nombre {get; set ;}
        public string Descripcion { get; set; }
        public int Id { get; set; }
        public bool Estado { get; set; }
        public List<INotas> Notas { get; set; }
    }
}
