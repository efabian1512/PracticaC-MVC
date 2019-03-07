namespace CursoASPNETMVC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;

    public partial class Creando_SP : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("sp_Personas_Por_Edad",(x=> new { Edad =x.Int()}), @"SELECT Nombre, Edad from dbo.Personas where Edad=@Edad");
            CreateStoredProcedure("sp_Personas_Mayores_deEdad", (x => new { Edad = x.Int(18) }), @"SELECT nombre,edad from dbo.Personas where Edad>=@Edad");
            Sql(RecursosSQL.Crear_sp_Borrar_Personas_Menores);

        }
        
        public override void Down()
        {
            DropStoredProcedure("sp_Personas_Por_Edad");
            DropStoredProcedure("sp_Personas_Mayores_deEdad");
            Sql(RecursosSQL.Borrar_sp_Borrar_Personas_Menores);
        }
    }
}
