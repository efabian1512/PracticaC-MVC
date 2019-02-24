using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Collections.Generic;
using System.Linq;

namespace CursoASPNETMVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Persona> Personas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime2"));

            modelBuilder.Properties<int>().Where(p => p.Name.StartsWith("Codigo")).Configure(p => p.IsKey());

            base.OnModelCreating(modelBuilder); 
        }

        protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)
        {
            if(entityEntry.State == EntityState.Deleted)
            {
                return true;
            }
            return base.ShouldValidateEntity(entityEntry);
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if(entityEntry.Entity is Persona && entityEntry.State == EntityState.Deleted)
            {
            var entidad = entityEntry.Entity as Persona;
            if(entidad.Edad < 18)
            {
                return new DbEntityValidationResult(entityEntry, new DbValidationError[] {
                    new DbValidationError("Edad","No se puede borrar a un menor de edad.") });

            }
            }
            return base.ValidateEntity(entityEntry, items);
        }
        //public override int SaveChanges()
        //{
        //    var entidades = ChangeTracker.Entries();
        //    if(entidades != null)
        //    {
        //        foreach(var entidad in entidades.Where(c => c.State != EntityState.Unchanged))
        //        {
        //            Auditar(entidad);
        //        }
        //    }
        //    return base.SaveChanges();
        //}

        //private void Auditar(object entidad)
        //{
        //    throw new NotImplementedException();
        //}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}