namespace Sqlinjection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProcedimientoAlmacenado : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("Buscar_PErsonas", x => new { Nombre = x.String() }, @"SELECT * FROM PERSONAS WHERE Nombre=@Nombre");
        }
        
        public override void Down()
        {
            DropStoredProcedure("Buscar_PErsonas");
        }
    }
}
