namespace CSRF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ultima : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cuentas", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Cuentas", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Cuentas", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cuentas", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cuentas", "ApplicationUser_Id");
            AddForeignKey("dbo.Cuentas", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
