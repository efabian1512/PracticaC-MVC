using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoASPNETMVC2.Models
{
    public class Persona_Curso
    {
        public string Id_Persona { get; set; }
        public int Id_Curso { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual Curso Curso { get; set; }
        public bool Abandonado { get; set; }
    }
}