namespace CursoASPNETMVC4
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Direcciones>()
                .Property(e => e.Cedula)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Personas>()
                .Property(e => e.Cedula)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
