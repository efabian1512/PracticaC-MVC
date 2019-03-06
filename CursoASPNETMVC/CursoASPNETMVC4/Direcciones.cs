namespace CursoASPNETMVC4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Direcciones
    {
        [Key]
        public int CodigoDireccion { get; set; }

        [StringLength(200)]
        public string Calle { get; set; }

        [StringLength(11)]
        public string Cedula { get; set; }
    }
}
