create procedure sp_Borrar_Personas_Menores
as
begin
delete from Personas where Edad <18;
end