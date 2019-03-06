namespace CursoASPNETMVC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseFirst : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Direcciones");
            DropTable("dbo.Personas");

            CreateTable(
                "dbo.Direcciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Calle = c.String(maxLength: 200),
                        Cedula = c.String(nullable: false, maxLength: 11, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.Cedula, cascadeDelete: true)
                .Index(t => t.Cedula);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Cedula = c.String(nullable: false, maxLength: 11, fixedLength: true, unicode: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Edad = c.Int(),
                    })
                .PrimaryKey(t => t.Cedula);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Direcciones", "Cedula", "dbo.Personas");
            DropIndex("dbo.Direcciones", new[] { "Cedula" });
            DropTable("dbo.Personas");
            DropTable("dbo.Direcciones");
        }
    }
}
