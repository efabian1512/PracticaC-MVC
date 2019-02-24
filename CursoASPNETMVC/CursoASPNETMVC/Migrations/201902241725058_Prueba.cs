namespace CursoASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prueba : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personas", "Edad", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personas", "Edad", c => c.Int());
        }
    }
}
