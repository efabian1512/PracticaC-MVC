namespace CSRF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ultimita : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Cuentas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Cuentas",
                c => new
                    {
                        IdCuenta = c.Int(nullable: false, identity: true),
                        Monto = c.Int(nullable: false),
                        IdUsuario = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdCuenta);
            
        }
    }
}
