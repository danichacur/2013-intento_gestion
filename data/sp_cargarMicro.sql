SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE cargarMicro
@patenteNueva varchar(7),
@patenteVieja varchar(7)

AS
BEGIN 

INSERT INTO [GD1C2013].[transportados].[micros]
			([micr_tipo_id],
        [micr_cant_butacas],[micr_kg_encomienda],[micr_marca],[micr_modelo],
        [micr_baja],[micr_baja_tecnica],[micro_creado],[micr_patente],[micr_pisos])
        
        (select distinct t.tipo_id,  m.micr_cant_butacas, m.micr_kg_encomienda, m.micr_marca,
         m.micr_modelo, 0, 0, SYSDATETIME(), @patenteNueva , m.micr_pisos
         from transportados.tipo_servicio t,
         transportados.micros m
         where m.micr_patente = @patenteVieja);

END
GO
create procedure transportados.bajaRol @rol varchar(15)
as
begin 
update transportados.Rol
set rol_borrado=1
where rol_nombre=@rol;
delete transportados.rol_usuario
where rolu_rol_id  in ( select rol_id from transportados.rol where rol_nombre=@rol)
end
GO