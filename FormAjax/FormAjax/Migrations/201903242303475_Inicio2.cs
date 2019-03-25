namespace FormAjax.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio2 : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            CreateTable(
               "dbo.DetallePersonas",
               c => new
               {
                   IdDetalle = c.Int(nullable: false, identity: true),
                   Peso = c.Double(nullable: false),
                   Altura = c.Double(nullable: false),
                   Sexo = c.String(),
               })
               .PrimaryKey(t => t.IdDetalle)
                .ForeignKey("dbo.Personas", t => t.IdDetalle)
                .Index(t => t.IdDetalle);
        }
    }
}
