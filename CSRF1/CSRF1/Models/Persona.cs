using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSRF1.Models
{
    public class Cuenta
    {
        [Key]
        [Display(Name = "Id Cuenta")]

        public string IdCuenta { get; set; }
        [Required]
        public int Monto { get; set; }
        [Required]
        public string IdUsuario { get; set; }
    }
}