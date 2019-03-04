using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoASPNETMVC2.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    //public class ApplicationUser : IdentityUser
    //{
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //    {
    //        // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Agregar aquí notificaciones personalizadas de usuario
    //        return userIdentity;
    //    }
    //}

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Direccion> Direccion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        //Decimos cual columna es llave primaria (Personas)
        modelBuilder.Entity<Persona>().HasKey(x => x.Cedula);
        //Definimos una llave compuesta (Direcciones)
        modelBuilder.Entity<Direccion>().HasKey(x => new { x.CodigoDireccion, x.Calle
    });
            //El valor de la llave primaria sera asignado por nosotros (Direcciones)
            modelBuilder.Entity<Direccion>().Property(x => x.CodigoDireccion).
            HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    //El campo cedula de la tabla Persona es de longitud fija y tiene longitud maxima de 11
    modelBuilder.Entity<Persona>().Property(x => x.Cedula).IsFixedLength().HasMaxLength(11);
    //Todas las propiedad enteras que empiecen con Codigo son llaves primarias. Ej: CodigoDireccion
    modelBuilder.Properties<int>().Where(x => x.Name.StartsWith("Codigo")).Configure(x => x.IsKey());
            //La longitud maxima del campo Nombre sera de 120 caracteres
            modelBuilder.Entity<Persona>().Property(x => x.Nombre).HasMaxLength(120);
    //La propiedad Nombre sera requerida
    modelBuilder.Entity<Persona>().Property(x => x.Nombre).IsRequired();
    // Esta propiedad no se mapeara en una columna (Resumen)
    modelBuilder.Entity<Persona>().Ignore(x => x.Resumen);
    //Definimos el nombre que tendra la columna (CodigoDireccion)
    modelBuilder.Entity<Direccion>().Property(x => x.CodigoDireccion).HasColumnName("Codigo");
    //Definimos el nombre que tendra la tabla (Direcciones)
    modelBuilder.Entity<Direccion>().ToTable("Direcciones");

    //Convenciones

    //No pluralizar
    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // No mapea los decimales a numeric(18,2)
            modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            //Los decimales seran decimal(16,2)
            modelBuilder.Properties<decimal>().Configure(x => x.HasColumnType("decimal").HasPrecision(16, 2));
            base.OnModelCreating(modelBuilder);
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}