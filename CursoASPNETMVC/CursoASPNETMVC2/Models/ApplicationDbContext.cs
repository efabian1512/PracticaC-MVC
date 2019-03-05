using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CursoASPNETMVC2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<TarjetaDeCredito> TarjetaDeCredito { get; set; }
        public DbSet<Persona_Curso> Persona_Curso { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Toda direccion se relaciona con una persona pero no toda persona se relaciona con una direccion
            //modelBuilder.Entity<Direccion>().HasRequired(x => x.Persona).WithOptional(y => y.Direccion);
            //Toda direccion se relaciona con una persona y toda persona con una direccion
            modelBuilder.Entity<Direccion>().HasRequired(x => x.Persona).WithRequiredPrincipal(y => y.Direccion);
            //Toda tarjeta se relaciona con una persona, no siempre una persona tiene tarjeta
            modelBuilder.Entity<TarjetaDeCredito>().HasRequired(x => x.Persona);
            base.OnModelCreating(modelBuilder);
            //Relacion muchos a muchos
            //modelBuilder.Entity<Curso>().HasMany(x => x.Personas).WithMany(y => y.Cursos);
            //Relacion muchos a muchos personalizada
           /* modelBuilder.Entity<Curso>().HasMany(x => x.Personas).WithMany(y => y.Cursos).Map(
                m =>
                {
                    m.ToTable("Persona_Curso");
                    m.MapLeftKey("IdCurso");
                    m.MapRightKey("IdPersona");
                });*/


            modelBuilder.Entity<Persona_Curso>().HasKey(x => new { x.Id_Curso, x.Id_Persona });
        }
    }
}