namespace Ajaxx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetallePersonas", "PersonaId", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetallePersonas", "PersonaId");
        }
    }
}
