using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajaxx.Models
{
    public class DetallePersona
    {
        public int Id { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public string Sexo { get; set; }

        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
    }
}