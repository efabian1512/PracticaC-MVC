using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OverPosting.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public bool Aprobado { get; set; }
        public DateTime Creado { get; set; }
        public string Usuario { get; set; }
    }
}