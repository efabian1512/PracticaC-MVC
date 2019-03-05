namespace CursoASPNETMVC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdiciontablaPersona_Curso : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CursoPersona", "Curso_Id", "dbo.Curso");
            DropForeignKey("dbo.CursoPersona", "Persona_Cedula", "dbo.Persona");
            DropIndex("dbo.CursoPersona", new[] { "Curso_Id" });
            DropIndex("dbo.CursoPersona", new[] { "Persona_Cedula" });
            CreateTable(
                "dbo.Persona_Curso",
                c => new
                    {
                        Id_Curso = c.Int(nullable: false),
                        Id_Persona = c.String(nullable: false, maxLength: 128),
                        Abandonado = c.Boolean(nullable: false),
                        Curso_Id = c.Int(),
                        Persona_Cedula = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Id_Curso, t.Id_Persona })
                .ForeignKey("dbo.Curso", t => t.Curso_Id)
                .ForeignKey("dbo.Persona", t => t.Persona_Cedula)
                .Index(t => t.Curso_Id)
                .Index(t => t.Persona_Cedula);
            
            DropTable("dbo.CursoPersona");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CursoPersona",
                c => new
                    {
                        Curso_Id = c.Int(nullable: false),
                        Persona_Cedula = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Curso_Id, t.Persona_Cedula });
            
            DropForeignKey("dbo.Persona_Curso", "Persona_Cedula", "dbo.Persona");
            DropForeignKey("dbo.Persona_Curso", "Curso_Id", "dbo.Curso");
            DropIndex("dbo.Persona_Curso", new[] { "Persona_Cedula" });
            DropIndex("dbo.Persona_Curso", new[] { "Curso_Id" });
            DropTable("dbo.Persona_Curso");
            CreateIndex("dbo.CursoPersona", "Persona_Cedula");
            CreateIndex("dbo.CursoPersona", "Curso_Id");
            AddForeignKey("dbo.CursoPersona", "Persona_Cedula", "dbo.Persona", "Cedula", cascadeDelete: true);
            AddForeignKey("dbo.CursoPersona", "Curso_Id", "dbo.Curso", "Id", cascadeDelete: true);
        }
    }
}
