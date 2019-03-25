using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormAjax.Models
{
    public class DetallePersona
    {
        [Key]
        public int IdDetalle { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public string Sexo { get; set; }
        public Persona Persona { get; set; }
    }
}