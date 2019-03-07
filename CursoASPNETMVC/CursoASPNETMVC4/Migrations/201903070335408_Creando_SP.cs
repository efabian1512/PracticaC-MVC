namespace CursoASPNETMVC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Creando_SP : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("sp_Personas_Por_Edad", x => new { Edad = x.Int() }, @"SELECT nombre,edad from dbo.Personas where Edad=@Edad");
            CreateStoredProcedure("sp_Personas_Mayores_de_Edad", x => new { Edad = x.Int(18) }, @"SELECT nombre, edad from dbo.Personas where Edad>= @Edad");
            Sql(RecursosSQL.Crear_sp_Borra_Personas_Menores);
        }

        public override void Down()
        {
            DropStoredProcedure("sp_Personas_Por_Edad");
            DropStoredProcedure("sp_Personas_Mayores_de_Edad");
            Sql(RecursosSQL.Borrrar_sp_Borra_Personas_Menores);
        }
    }
}
