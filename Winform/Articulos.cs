﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform
{
    // esta la clase base que me va a dar el formato del objeto que yo voy a manipular.
    class Articulos
    {
        //Propiedades:
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set;}
    }
}