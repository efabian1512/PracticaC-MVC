using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoASPNETMVC.Models.Validaciones
{
    public class DivisibleEntre2Attribute : ValidationAttribute
    {
        private int _dividendo;
        public DivisibleEntre2Attribute(int dividendo):base ("El campo {0} es invalido")
        {
            _dividendo = dividendo;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                if((int)value % _dividendo != 0)

                {
                    var ErrorMessage = new ValidationResult(validationContext.DisplayName);
                    return ErrorMessage;

                }
                
            }
            return ValidationResult.Success;
        }
    }
}