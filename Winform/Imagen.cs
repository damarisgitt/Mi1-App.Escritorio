﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform
{
     class Imagen
    {
        public int id { get; set; }
        public int idArticulo { get; set; }
        public string ImagenUrl { get; set; }

        public override string ToString()
        {
            return ImagenUrl;
        }
    }
}
