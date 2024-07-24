﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities.Models
{
    public class Autor
    {
        [Key]
        public int id { get; set; }

        public required string Nombre { get; set; }

        public required string Apellido { get; set; }
    }
}
