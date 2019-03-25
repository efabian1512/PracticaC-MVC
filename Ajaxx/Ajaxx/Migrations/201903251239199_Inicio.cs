namespace Ajaxx.Migrations
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
                        Id = c.Int(nullable: false),
                        Peso = c.Double(nullable: false),
                        Altura = c.Double(nullable: false),
                        Sexo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetallePersonas", "Id", "dbo.Personas");
            DropIndex("dbo.DetallePersonas", new[] { "Id" });
            DropTable("dbo.Personas");
            DropTable("dbo.DetallePersonas");
        }
    }
}
