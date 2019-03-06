namespace CursoASPNETMVC4
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationDbContext1 : DbContext
    {
        public ApplicationDbContext1()
            : base("name=ApplicationDbContext1")
        {
        }

        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personas>()
                .Property(e => e.Cedula)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Direcciones>()
                .Property(e => e.Cedula)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Direcciones>().HasKey(x => x.Id);
            modelBuilder.Entity<Direcciones>().HasRequired(x => x.Personas);
        }
    }
}
