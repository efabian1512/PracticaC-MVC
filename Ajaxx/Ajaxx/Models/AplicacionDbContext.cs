using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ajaxx.Models
{
    public class AplicacionDbContext:DbContext
    {
        public AplicacionDbContext():base("DefaultConnection")
        {

        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<DetallePersona> DetallePersonas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetallePersona>().HasRequired(x => x.Persona);
            base.OnModelCreating(modelBuilder);
        }
    }
}