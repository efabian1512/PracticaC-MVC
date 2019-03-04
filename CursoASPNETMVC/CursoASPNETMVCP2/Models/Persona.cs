using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoASPNETMVCP2.Models
{
    public class Persona
    {
        //[Key]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime Nacimiento { get; set; }
        public int Edad { get; set; }
        public decimal Salario { get; set; }
        public string Resumen { get { return $"{Nombre}({ Nacimiento.ToString("dd-MM-yyyy")})"; } }
    }
}