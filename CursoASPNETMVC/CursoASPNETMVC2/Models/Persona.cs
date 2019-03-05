using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CursoASPNETMVC2.Models
{
    public class Persona
    {
       // List<Curso> Cursos;
        public Persona()
        {
            //Cursos = new List<Curso>();
            Cursos = new List<Persona_Curso>();
        }

        [Key]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime Nacimiento { get; set; }
        public int Edad { get; set; }
        public Sexo Sexo { get; set; }
        public decimal Salario { get; set; }
        [NotMapped]
        public string Resumen { get { return $"{Nombre}({Nacimiento.ToString("dd/MM/yyyy")})"; } }
        public Direccion Direccion { get; set; }
        public virtual List<TarjetaDeCredito> Tarjetas { get; set; }
        //public virtual List<Curso> Cursos { get; set; }
        public virtual List<Persona_Curso> Cursos{get;set;}


    }
}