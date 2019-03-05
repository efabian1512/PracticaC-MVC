namespace CursoASPNETMVC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreaciontablasPersonatarjetacreditocursoDireccion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Cedula = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Nacimiento = c.DateTime(nullable: false),
                        Edad = c.Int(nullable: false),
                        Sexo = c.Int(nullable: false),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Direccion_CodigoDireccion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Cedula)
                .ForeignKey("dbo.Direccion", t => t.Direccion_CodigoDireccion)
                .Index(t => t.Direccion_CodigoDireccion);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        CodigoDireccion = c.Int(nullable: false, identity: true),
                        Calle = c.String(),
                    })
                .PrimaryKey(t => t.CodigoDireccion);
            
            CreateTable(
                "dbo.TarjetaDeCredito",
                c => new
                    {
                        PAN = c.String(nullable: false, maxLength: 128),
                        NombreEnTarjeta = c.String(),
                        Persona_Cedula = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PAN)
                .ForeignKey("dbo.Persona", t => t.Persona_Cedula, cascadeDelete: true)
                .Index(t => t.Persona_Cedula);
            
            CreateTable(
                "dbo.CursoPersona",
                c => new
                    {
                        Curso_Id = c.Int(nullable: false),
                        Persona_Cedula = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Curso_Id, t.Persona_Cedula })
                .ForeignKey("dbo.Curso", t => t.Curso_Id, cascadeDelete: true)
                .ForeignKey("dbo.Persona", t => t.Persona_Cedula, cascadeDelete: true)
                .Index(t => t.Curso_Id)
                .Index(t => t.Persona_Cedula);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CursoPersona", "Persona_Cedula", "dbo.Persona");
            DropForeignKey("dbo.CursoPersona", "Curso_Id", "dbo.Curso");
            DropForeignKey("dbo.TarjetaDeCredito", "Persona_Cedula", "dbo.Persona");
            DropForeignKey("dbo.Persona", "Direccion_CodigoDireccion", "dbo.Direccion");
            DropIndex("dbo.CursoPersona", new[] { "Persona_Cedula" });
            DropIndex("dbo.CursoPersona", new[] { "Curso_Id" });
            DropIndex("dbo.TarjetaDeCredito", new[] { "Persona_Cedula" });
            DropIndex("dbo.Persona", new[] { "Direccion_CodigoDireccion" });
            DropTable("dbo.CursoPersona");
            DropTable("dbo.TarjetaDeCredito");
            DropTable("dbo.Direccion");
            DropTable("dbo.Persona");
            DropTable("dbo.Curso");
        }
    }
}
