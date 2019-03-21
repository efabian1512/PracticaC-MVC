namespace CSRF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ultimate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cuentas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Monto = c.Int(nullable: false),
                        IdUsuario = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cuentas");
        }
    }
}
