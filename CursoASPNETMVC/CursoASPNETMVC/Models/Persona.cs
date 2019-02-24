using CursoASPNETMVC.Models.Validaciones;
using Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoASPNETMVC.Models
{
    public class Persona : IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType =typeof(Recurso),ErrorMessageResourceName ="Mensaje_error_required")]
        [StringLength(100)]
        [Display(ResourceType =(typeof(Recurso)),Name = "Persona_Nombre_Texto_Mostrar")]
        public string Nombre { get; set; }
        [Range(18, 60, ErrorMessage = "La edad minima es {1} y la maxima {2}")]
        public int? Edad { get; set; }
        [Required]
        [StringLength(200)]

        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "Los Emails no coinciden.")]
        [Display(Name = "Confirmar Email")]
        public string ConfirmarEmail { get; set; }
        [Remote("DivisibleEntre2", "Personas", ErrorMessage = "El numero no es divisible entre 2.")]
        [DivisibleEntre2(2, ErrorMessage = "No es divisible entre 2")]
        [Display(Name = "Disvible entre dos")]
        public int DivisibleEntreDos { get; set; }
        public int Salario { get; set; }
        [Display(Name = "Monto Solicitud Prestamo")]
        public int MontoSolicitudPrestamo { get; set; }
        [NotMapped]
        [ScaffoldColumn(false)]
        public string camposecreto { get; set; }
        [DataType(DataType.Password)]
        public string Resumen { get; set; }
        [Display(Name ="Fecha de Nacimiento")]
        public DateTime FechaDeNacimiento { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errores = new List<ValidationResult>();
            if (Salario * 4 < MontoSolicitudPrestamo)
            {
                errores.Add(new ValidationResult("El monto solicitud prestamo excede 4 veces el salario", new string[] { "MontoSolicitudPrestamo" }));
            }
            return errores;

        }
    }
}