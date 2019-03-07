create procedure sp_Borra_Personas_Menores

as 
begin

SET NOCOUNT ON;

delete Personas where edad < 18;
END