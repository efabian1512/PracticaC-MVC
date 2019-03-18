using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sqlinjection.Models
{
    public class Persona
    {
        [Key]
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(150)]
        public string Direccion { get; set; }

    }
}