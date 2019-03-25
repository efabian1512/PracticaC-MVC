namespace FormAjax.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetallePersonas",
                c => new
                    {
                        IdDetalle = c.Int(nullable: false,identity:true),
                        Peso = c.Double(nullable: false),
                        Altura = c.Double(nullable: false),
                        Sexo = c.String(),
                    })
                .PrimaryKey(t => t.IdDetalle)
                .ForeignKey("dbo.Personas", t => t.IdDetalle)
                .Index(t => t.IdDetalle);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        IdPersona = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPersona);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetallePersonas", "IdDetalle", "dbo.Personas");
            DropIndex("dbo.DetallePersonas", new[] { "IdDetalle" });
            DropTable("dbo.Personas");
            DropTable("dbo.DetallePersonas");
        }
    }
}
