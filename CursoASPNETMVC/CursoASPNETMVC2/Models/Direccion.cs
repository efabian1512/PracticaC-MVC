using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoASPNETMVC2.Models
{
    public class Direccion
    {
        [Key]
        public int CodigoDireccion { get; set; }
        public string Calle { get; set; }
        public Persona Persona { get; set; }
    }
}