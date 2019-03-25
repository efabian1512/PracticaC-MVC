using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormAjax.Models
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public DetallePersona Detalles { get; set; }
    }
}