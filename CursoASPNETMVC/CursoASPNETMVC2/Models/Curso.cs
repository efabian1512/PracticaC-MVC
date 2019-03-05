using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoASPNETMVC2.Models
{

    public class Curso
    {
        public Curso()
        {
            //Personas = new List<Persona>();
            Personas = new List<Persona_Curso>();
        }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        //public virtual List<Persona> Personas { get; set; }
        public virtual List<Persona_Curso> Personas { get; set; }
    }
}