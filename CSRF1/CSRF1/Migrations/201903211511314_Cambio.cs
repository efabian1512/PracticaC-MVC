namespace CSRF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cambio : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Cuentas");
            AlterColumn("dbo.Cuentas", "IdCuenta", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Cuentas", "IdCuenta");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Cuentas");
            AlterColumn("dbo.Cuentas", "IdCuenta", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Cuentas", "IdCuenta");
        }
    }
}
