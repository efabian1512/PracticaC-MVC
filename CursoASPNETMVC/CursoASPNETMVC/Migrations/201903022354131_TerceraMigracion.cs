namespace CursoASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TerceraMigracion : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Personas", "Nombre");
            CreateIndex("dbo.Personas", new[] { "Nacimiento", "Edad" });
            Sql("CREATE INDEX Ix_Edad_Sexo ON dbo.Personas(Edad asc, Sexo desc)");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Personas", new[] { "Nacimiento", "Edad" });
            DropIndex("dbo.Personas", new[] { "Nombre" });
            Sql("DROP INDEX Ix_Edad_Sexo ON dbo.Personas");
        }
    }
}
