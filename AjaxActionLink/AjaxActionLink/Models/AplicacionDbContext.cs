using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AjaxActionLink.Models
{
    public class AplicacionDbContext :DbContext
    {
        public AplicacionDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<DetallePersona> DetallesPersonas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetallePersona>().HasRequired(x => x.Persona);

        }
    }
}