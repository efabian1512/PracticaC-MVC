namespace CursoASPNETMVC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creaciondelastablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Cedula = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        Nombre = c.String(nullable: false, maxLength: 120),
                        Nacimiento = c.DateTime(nullable: false),
                        Edad = c.Int(nullable: false),
                        Salario = c.Decimal(nullable: false, precision: 16, scale: 2),
                    })
                .PrimaryKey(t => t.Cedula);
            
            CreateTable(
                "dbo.Direcciones",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        Calle = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Codigo, t.Calle });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Direcciones");
            DropTable("dbo.Persona");
        }
    }
}
