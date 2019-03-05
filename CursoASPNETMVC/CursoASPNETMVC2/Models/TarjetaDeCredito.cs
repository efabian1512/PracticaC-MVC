using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoASPNETMVC2.Models
{
    public class TarjetaDeCredito
    {
        [Key]
        public string PAN { get; set; }
        public string NombreEnTarjeta { get; set; }
        public Persona Persona { get; set; }
    }
}