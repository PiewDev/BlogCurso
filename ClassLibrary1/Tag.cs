﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDatos;

namespace ModeloDeNegocio
{
    public class Tag : ITags
    {
       public int Id { get ; set; }
       public string Nombre { get; set; }
       public List<INotas> Notas { get; set; }
       public bool Estado { get; set; }
    }
}
