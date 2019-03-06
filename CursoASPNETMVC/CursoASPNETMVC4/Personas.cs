namespace CursoASPNETMVC4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Personas
    {
        [Key]
        [StringLength(11)]
        public string Cedula { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        public int? Edad { get; set; }
    }
}
