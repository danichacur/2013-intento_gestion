USE [GD1C2013]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[bajaRol]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[bajaRol]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[devuelvePasajes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[devuelvePasajes]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[cargarMicro]') AND type in (N'P', N'PC'))
DROP PROCEDURE  [transportados].[cargarMicro]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[buscaViajes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[buscaViajes]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[existe]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[existe]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[microAlterno]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[microAlterno]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[pasajesVendidos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[pasajesVendidos]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[devolucionPersonal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[devolucionPersonal]
GO


/****** Object:  Table [transportados].[puntos_pas_frecuente]    Script Date: 05/21/2013 22:23:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[puntos_pas_frecuente]') AND type in (N'U'))
DROP TABLE [transportados].[puntos_pas_frecuente]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[clientes]') AND type in (N'U'))
DROP TABLE [transportados].[clientes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[tipo_servicio]') AND type in (N'U'))
DROP TABLE [transportados].[tipo_servicio]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[ciudad]') AND type in (N'U'))
DROP TABLE [transportados].[ciudad]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[recorrido]') AND type in (N'U'))
DROP TABLE [transportados].[recorrido]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[butaca]') AND type in (N'U'))
DROP TABLE [transportados].[butaca]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[viajes]') AND type in (N'U'))
DROP TABLE [transportados].[viajes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[voucher_de_compra]') AND type in (N'U'))
DROP TABLE [transportados].[voucher_de_compra]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[pasajes]') AND type in (N'U'))
DROP TABLE [transportados].[pasajes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[funcionalidad]') AND type in (N'U'))
DROP TABLE [transportados].[funcionalidad]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[Rol]') AND type in (N'U'))
DROP TABLE [transportados].[Rol]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[Rol_funcionalidad]') AND type in (N'U'))
DROP TABLE [transportados].[Rol_funcionalidad]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[usuario]') AND type in (N'U'))
DROP TABLE [transportados].[usuario]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[rol_usuario]') AND type in (N'U'))
DROP TABLE [transportados].[rol_usuario]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[facturas]') AND type in (N'U'))
DROP TABLE [transportados].[facturas]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[premios]') AND type in (N'U'))
DROP TABLE [transportados].[premios]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[micros]') AND type in (N'U'))
DROP TABLE [transportados].[micros]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[premios_obtenidos]') AND type in (N'U'))
DROP TABLE [transportados].[premios_obtenidos]
GO

drop schema transportados



Select 'Creo el esquema'

GO

CREATE SCHEMA [transportados] AUTHORIZATION [gd]
GO

/****** Object:  Table [transportados].[clientes]    Script Date: 05/21/2013 22:22:29 ******/

Select 'Creo tabla clientes'

GO

CREATE TABLE [transportados].[clientes](
      [Cli_id] [int] IDENTITY(1,1) NOT NULL,
      [Cli_Nombre] [nvarchar](255) NULL,
      [Cli_Apellido] [nvarchar](255) NULL,
      [Cli_Dni] [numeric](18, 0) NULL,
      [Cli_Dir] [nvarchar](255) NULL,
      [Cli_Telefono] [numeric](18, 0) NULL,
      [Cli_Mail] [nvarchar](255) NULL,
      [Cli_Fecha_Nac] [datetime] NULL
      ,[cli_creado] [datetime] NULL
      ,[cli_modificado][datetime] NULL
      ,[cli_id_pasa_frecuente] [int] NULL
) ON [PRIMARY]

GO

Select 'Migro la tabla clientes'

GO

/* Crear los clientes*/
  INSERT INTO [GD1C2013].[transportados].[clientes] 
  ([Cli_Nombre]
  ,[Cli_Apellido]
  ,[Cli_Dni]
  ,[Cli_Dir]
  ,[Cli_Telefono]
  ,[Cli_Mail]
  ,[Cli_Fecha_Nac]
  ,[cli_creado]
  ,[cli_modificado])
  (SELECT 
  [Cli_Nombre]
  ,[Cli_Apellido]
  ,[Cli_Dni]
  ,[Cli_Dir]
  ,[Cli_Telefono]
  ,[Cli_Mail]
  ,[Cli_Fecha_Nac]
  ,SYSDATETIME()
  ,SYSDATETIME()
  FROM [GD1C2013].[gd_esquema].[Maestra]
  group by 
  [Cli_Nombre]
  ,[Cli_Apellido]
  ,[Cli_Dni]
  ,[Cli_Dir]
  ,[Cli_Telefono]
  ,[Cli_Mail]
  ,[Cli_Fecha_Nac]);
  GO


/****** Object:  Table [transportados].[tipo_servicio]    Script Date: 05/21/2013 22:24:02 ******/

Select 'Creo tabla tipo_servicio'

GO


CREATE TABLE [transportados].[tipo_servicio](
      [tipo_id] [int] IDENTITY(1,1) NOT NULL,
      [tipo_nombre] [nvarchar](255) NULL,
      [tipo_creado] [datetime] NULL,
      [tipo_modificado] [datetime] NULL,
      [tipo_porcentaje] real
) ON [PRIMARY]

GO

/* Crear los tipos de servicio*/
    insert into [GD1C2013].[transportados].[tipo_servicio]
    ([tipo_nombre],
    [tipo_creado],
    [tipo_modificado],
    [tipo_porcentaje])
    (select Tipo_Servicio,SYSDATETIME(),SYSDATETIME(),max(round(Pasaje_Precio/Recorrido_Precio_BasePasaje-1,+2))
    FROM [GD1C2013].[gd_esquema].[Maestra] m
    where Recorrido_Precio_BasePasaje <> 0
    group by Tipo_Servicio
    );
    GO

Select 'Creo tabla Micros'

GO


CREATE TABLE [transportados].[micros](
      [micr_id] [int] IDENTITY(1,1) NOT NULL,
      [micr_tipo_id] [int] NOT NULL,
      [micr_cant_butacas] [int] NULL,
      [micr_kg_encomienda] [int] NULL,
      [micr_marca] [nvarchar](255) NOT NULL,
      [micr_modelo] [nvarchar](255) NOT NULL,
      [micr_baja] [bit] NULL,
      [micr_baja_tecnica] [bit] NULL,
      [micr_fecha_baja] [datetime] NULL,
      [micr_fecha_baja_tecnica] [datetime] NULL,
      [micr_fecha_regreso] [datetime] NULL,
      [micro_creado] [datetime] NULL,
      [micr_patente] [nvarchar](7) NOT NULL,
      [micr_pisos] [int] NOT NULL
) ON [PRIMARY]

GO

/* crear los micros */
  INSERT INTO [GD1C2013].[transportados].[micros](
    [micr_tipo_id]
      ,[micr_cant_butacas]
      ,[micr_kg_encomienda]
      ,[micr_marca]
      ,[micr_modelo]
      ,[micr_baja]
      ,[micr_baja_tecnica]
      ,[micr_fecha_baja]
      ,[micr_fecha_baja_tecnica]
      ,[micr_fecha_regreso]
      ,[micro_creado]
      ,[micr_patente]
      ,[micr_pisos] )
  (SELECT ts.tipo_id
    ,0
    ,[Micro_KG_Disponibles]
      ,[Micro_Marca]
      ,[Micro_Modelo]
      ,0
      ,0
      ,null
      ,null
      ,null
      ,SYSDATETIME()
      ,[Micro_Patente]
      ,0
      FROM [GD1C2013].[gd_esquema].[Maestra] m , [GD1C2013].[transportados].tipo_servicio ts
      where ts.tipo_nombre  = m.Tipo_Servicio
      group by [Micro_Marca],
      [Micro_Modelo],
      [Micro_Patente],
      [Micro_KG_Disponibles],
      ts.tipo_id);
  GO


/****** Object:  Table [transportados].[ciudad]    Script Date: 05/21/2013 22:22:16 ******/

Select 'Creo tabla Ciudad'

GO


CREATE TABLE [transportados].[ciudad](
      [ciud_id] [int] IDENTITY(1,1) NOT NULL,
      [ciud_nombre] [nvarchar](255) NOT NULL,
      [ciud_creado] [datetime] NULL,
      [ciud_modificado] [datetime] NULL,
      [ciud_baja] [bit] NULL
) ON [PRIMARY]

GO

/* crear las ciudades */
  INSERT INTO [transportados].[ciudad](
  [ciud_nombre],
  [ciud_creado],
  [ciud_modificado],
  [ciud_baja])
  (select distinct(a.Recorrido_Ciudad_Origen), SYSDATETIME(), SYSDATETIME(), 0 
  from (
  select Recorrido_Ciudad_Origen from [GD1C2013].[gd_esquema].[Maestra]
  union
  select Recorrido_Ciudad_Destino from [GD1C2013].[gd_esquema].[Maestra] ) a);
  GO


/****** Object:  Table [transportados].[recorrido]    Script Date: 05/21/2013 22:23:22 ******/

Select 'Creo tabla Recorrido'

GO


CREATE TABLE [transportados].[recorrido](
      [reco_id] [nvarchar](255) NOT NULL,
      [reco_id_ciudad_origen] [int] NOT NULL,
      [reco_id_ciudad_destino] [int] NOT NULL,
      [reco_tipo_id] [int] NOT NULL,
      [reco_precio_base] [int] NOT NULL,
      [reco_precio_encomienda] [int] NOT NULL,
      [reco_creado] [datetime] NULL,
      [reco_modificado] [datetime] NULL,
      [reco_baja] [bit] DEFAULT ((0)) NOT NULL, 
) ON [PRIMARY]

GO

/* crear recorridos */
  INSERT INTO [GD1C2013].[transportados].[recorrido](
      [reco_id],
      [reco_id_ciudad_origen],
      [reco_id_ciudad_destino],
      [reco_tipo_id],
      [reco_precio_base],
      [reco_precio_encomienda],
      [reco_creado],
      [reco_modificado])
  (select
      m.[Recorrido_Codigo]
      ,c1.ciud_id
      ,c2.ciud_id
      ,ts.tipo_id
      ,max(m.[Recorrido_Precio_BasePasaje])
      ,max(m.[Recorrido_Precio_BaseKG])
      ,SYSDATETIME()
      ,SYSDATETIME()
  FROM [GD1C2013].[gd_esquema].[Maestra] m
  left outer join  [transportados].[ciudad] c1 on c1.ciud_nombre= m.[Recorrido_Ciudad_Origen]
  left outer join  [transportados].[ciudad] c2 on c2.ciud_nombre= m.[Recorrido_Ciudad_Destino]
  left outer join  [transportados].[tipo_servicio] ts on ts.tipo_nombre=m.Tipo_Servicio
  group by 
      m.[Recorrido_Codigo]
      ,c1.ciud_id
      ,c2.ciud_id
      ,ts.tipo_id);
  GO


/****** Object:  Table [transportados].[butaca]    Script Date: 05/21/2013 22:14:00 ******/

Select 'Creo tabla butaca'

GO

CREATE TABLE [transportados].[butaca](
      [buta_id] [int] IDENTITY(1,1) NOT NULL,
      [buta_numero] [int] NOT NULL,
      [buta_micro_id] [int] NOT NULL,
      [buta_piso][int] NOT NULL,
      [buta_pasillo] [bit] NULL
) ON [PRIMARY]

GO

/* creacion de butaca */
  INSERT INTO [GD1C2013].[transportados].[butaca](
      [buta_numero],
      [buta_micro_id] ,
      [buta_piso],
      [buta_pasillo]
  )
  (select Butaca_Nro
  ,mi.micr_id
  ,Butaca_Piso
  ,case Butaca_Tipo
  when 'Pasillo' then 1
  else 0 end
   FROM [GD1C2013].[gd_esquema].[Maestra] m
  left outer join [transportados].[micros] mi on mi.micr_patente=m.Micro_Patente
  group by Butaca_Nro
    ,Butaca_Piso,mi.micr_id,Butaca_Tipo 
    );
      GO


/*actualiza la cantidad de butacas por micro*/
update transportados.micros 
set [micr_cant_butacas] = (SELECT MAX(b.buta_numero) from transportados.butaca b
  where transportados.micros.micr_id = b.buta_micro_id)
      ,[micr_pisos] = (SELECT MAX(b.buta_piso) from transportados.butaca b
  where transportados.micros.micr_id = b.buta_micro_id)
  

/****** Object:  Table [transportados].[viajes]    Script Date: 05/21/2013 22:24:28 ******/

Select 'Creo tabla viajes'

GO

CREATE TABLE [transportados].[viajes](
      [viaj_id] [int] IDENTITY(1,1) NOT NULL,
      [viaj_fecha_salida] [datetime] NULL,
      [viaj_fecha_llegada] [datetime] NULL,
      [viaj_fecha_llegada_estimada] [datetime] NULL,
      [viaj_micro] [int] NOT NULL,
      [viaj_recorrido] [nvarchar](18) NULL,
      [viaj_creado] [datetime] NULL,
      [viaj_modificado] [datetime] NULL,
      [viaj_butacas_libres] [int] NOT NULL,
      [viaj_KG_disponible] [int]
) ON [PRIMARY]

GO


/* crear los viajes */
  INSERT INTO [GD1C2013].[transportados].[viajes] (
    [viaj_fecha_salida]
    ,[viaj_fecha_llegada]
    ,[viaj_fecha_llegada_estimada]
    ,[viaj_micro]
    ,[viaj_recorrido]
    ,[viaj_creado]
    ,[viaj_modificado]
    ,[viaj_butacas_libres]
    ,[viaj_KG_disponible]
	)
    (SELECT 
    m.[FechaSalida]
    ,m.[FechaLLegada]
    ,m.[Fecha_LLegada_Estimada]
    ,mi.micr_id
    ,m.[Recorrido_Codigo]
    ,SYSDATETIME()
    ,SYSDATETIME()
    ,isnull(mi.micr_cant_butacas,0) - COUNT(distinct m.[Pasaje_Codigo])
    ,isnull(mi.micr_kg_encomienda,0) - SUM(m.Paquete_KG)
    FROM [GD1C2013].[gd_esquema].[Maestra] m
    left outer join  [GD1C2013].[transportados].[micros] mi on mi.micr_patente = m.Micro_Patente
    group by m.[FechaSalida]
    ,m.[FechaLLegada]
    ,m.[Fecha_LLegada_Estimada]
    ,mi.micr_id
    ,m.[Recorrido_Codigo]
    ,mi.micr_cant_butacas
    ,mi.micr_kg_encomienda);
    GO
    

--/****** Object:  Table [transportados].[pasaje]    Script Date: 05/21/2013 22:22:55 ******/
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[pasaje]') AND type in (N'U'))
--DROP TABLE [transportados].[pasaje]
--GO


--CREATE TABLE [transportados].[pasaje](
--      [pasa_id] [int] IDENTITY(1,1) NOT NULL,
--      [pasa_cliente_id][int] NOT NULL,
--      [pasa_creado] [datetime] NULL,
--      [pasa_modificado] [datetime] NULL,
--      [pasa_cantidad] [int] NOT NULL,
--      [pasa_KG] [int] NOT NULL,
--      [pasa_viaje_id] [int],
--      [pasa_precio_total] [int] NULL,
--      [pasa_precio_bonificado] [int] NULL,
--      [pasa_cod_devolucion] [int] NULL,
--	  [pasa_fecha_devolucion] [datetime] NULL,
--	  [pasa_desc_devolucion] [varchar](100) NULL
--) ON [PRIMARY]

--GO

--/* creacion del pasaje */
--  INSERT INTO [GD1C2013].[transportados].[pasaje] (
--      [pasa_cliente_id],
--      [pasa_creado],
--      [pasa_modificado],
--      [pasa_cantidad] ,
--      [pasa_KG],
--      [pasa_viaje_id],
--      [pasa_precio_total],
--      [pasa_precio_bonificado] )
--  (select a.Cli_id
--  ,a.Pasaje_FechaCompra
--  ,SYSDATETIME()
--  ,COUNT(*)
--  ,sum(a.Paquete_KG)
--  ,a.viaj_id
--  ,sum(a.precio)
--  ,0
--  from (
--  select cli.Cli_id,case 
--  when Paquete_Precio =0 then pasaje_precio
--  when Pasaje_Precio = 0 then Paquete_Precio
--  else Pasaje_Precio+Paquete_Precio
--  end precio,Paquete_KG,Pasaje_FechaCompra,vi.viaj_id
--  from [GD1C2013].[gd_esquema].[Maestra] m
--  left outer join transportados.clientes cli on cli.Cli_Dni=m.Cli_Dni,
--  [GD1C2013].[transportados].[viajes] vi
--  where vi.viaj_recorrido=m.Recorrido_Codigo
--  and vi.viaj_fecha_salida=m.FechaSalida
--  ) a
--  group by a.Cli_id,a.Pasaje_FechaCompra,a.viaj_id);
--  GO

--/****** Object:  Table [transportados].[pasaje_coupon]    Script Date: 05/21/2013 22:23:12 ******/
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[pasaje_coupon]') AND type in (N'U'))
--DROP TABLE [transportados].[pasaje_coupon]
--GO


--CREATE TABLE [transportados].[pasaje_coupon](
--      [cupo_id] [int]  NOT NULL,
--      [cupo_viaje_id] [int] NOT NULL,
--      [cupo_pasa_id] [int] NOT NULL,
--      [cupo_butaca_id] [int] NULL,
--      [cupo_kg_encomienda] [int] NULL,
--      [cupo_butaca] [bit] NULL,
--      [cupo_bonificado] [bit] NULL,
--      [cupo_creado] [datetime] NULL,
--      [cupo_modificado] [datetime] NULL,
--      [cupo_precio] [int] NULL
--) ON [PRIMARY]

--GO
--/* creacion de los cupones de los pasajes*/
--  insert into [transportados].[pasaje_coupon](
--      [cupo_id] ,
--      [cupo_viaje_id] ,
--      [cupo_pasa_id] ,
--      [cupo_butaca_id] ,
--      [cupo_kg_encomienda] ,
--      [cupo_butaca] ,
--      [cupo_bonificado] ,
--      [cupo_creado],
--      [cupo_modificado] ,
--      [cupo_precio])
--(    select 
--      Pasaje_Codigo
--      ,vi.viaj_id
--      ,p.pasa_id
--      ,b.buta_id
--      ,m.Paquete_KG
--      ,Butaca_Nro
--      ,0
--      ,Pasaje_FechaCompra
--      ,SYSDATETIME()
--      ,case 
--      when Pasaje_Precio=0 then Paquete_Precio
--      else pasaje_precio end 
--    from [GD1C2013].[gd_esquema].[Maestra] m
--    left outer join transportados.clientes cli on cli.Cli_Dni=m.Cli_Dni,
--  [GD1C2013].[transportados].[viajes] vi
--  left outer join [GD1C2013].[transportados].[micros] mi on vi.viaj_micro=mi.micr_id
--  left outer join [GD1C2013].[transportados].[butaca] b on b.buta_micro_id=mi.micr_id,
--   [GD1C2013].[transportados].[pasaje] p
--  where vi.viaj_recorrido=m.Recorrido_Codigo
--  and vi.viaj_fecha_salida=m.FechaSalida
--  and p.pasa_cliente_id=cli.Cli_id
--  and p.pasa_viaje_id=vi.viaj_id
--  and m.Pasaje_FechaCompra=p.pasa_creado
--  and b.buta_numero=m.Butaca_Nro)



/****** Object:  Table [transportados].[voucher_de_compra]    Script Date: 05/21/2013 22:22:55 ******/

Select 'Creo tabla Voucher de voucher_de_compra'

GO

CREATE TABLE [transportados].[voucher_de_compra](
      [vouc_id] [int] IDENTITY(1,1) NOT NULL,
      [vouc_cliente_id][int] NOT NULL,
      [vouc_creado] [datetime] NULL,
      [vouc_modificado] [datetime] NULL,
      [vouc_cantidad] [int] NOT NULL,
      [vouc_KG] [int] NOT NULL,
      [vouc_viaje_id] [int],
      [vouc_precio_total] [int] NULL
--    [vouc_precio_bonificado] [int] NULL,

) ON [PRIMARY]

GO

/* creacion del voucher */
  INSERT INTO [GD1C2013].[transportados].[voucher_de_compra] (
      [vouc_cliente_id],
      [vouc_creado],
      [vouc_modificado],
      [vouc_cantidad] ,
      [vouc_KG],
      [vouc_viaje_id],
      [vouc_precio_total])
 --     [vouc_precio_bonificado] )
  (select a.Cli_id
  ,a.Pasaje_FechaCompra
  ,SYSDATETIME()
  ,COUNT(*)
  ,sum(a.Paquete_KG)
  ,a.viaj_id
  ,sum(a.precio)
--  ,0
  from (
  select cli.Cli_id,case 
  when Paquete_Precio =0 then pasaje_precio
  when Pasaje_Precio = 0 then Paquete_Precio
  else Pasaje_Precio+Paquete_Precio
  end precio,Paquete_KG,Pasaje_FechaCompra,vi.viaj_id
  from [GD1C2013].[gd_esquema].[Maestra] m
  left outer join transportados.clientes cli on cli.Cli_Dni=m.Cli_Dni,
  [GD1C2013].[transportados].[viajes] vi
  where vi.viaj_recorrido=m.Recorrido_Codigo
  and vi.viaj_fecha_salida=m.FechaSalida
  ) a
  group by a.Cli_id,a.Pasaje_FechaCompra,a.viaj_id);
  GO



/****** Object:  Table [transportados].[pasajes]    Script Date: 05/21/2013 22:23:12 ******/

Select 'Creo tabla pasajes'

GO

CREATE TABLE [transportados].[pasajes](
      [pasa_id] [int] NOT NULL,
      [pasa_viaje_id] [int] NOT NULL,
      [pasa_voucher_id] [int] NOT NULL,
      [pasa_butaca_id] [int] NULL,
      [pasa_kg_encomienda] [int] NULL,
      [pasa_butaca] [int] NULL,
      [pasa_bonificado] [bit] NULL,
      [pasa_creado] [datetime] NULL,
      [pasa_modificado] [datetime] NULL,
      [pasa_precio] [int] DEFAULT ((0)) NOT NULL,
      [pasa_cod_devolucion] [int] NULL,
	  [pasa_fecha_devolucion] [datetime] NULL,
	  [pasa_desc_devolucion] [varchar](100) NULL
) ON [PRIMARY]

GO
/* creacion de los pasajes*/
  insert into [transportados].[pasajes](
	  [pasa_id],
      [pasa_viaje_id] ,
      [pasa_voucher_id] ,
      [pasa_butaca_id] ,
      [pasa_kg_encomienda] ,
      [pasa_butaca] ,
      [pasa_bonificado] ,
      [pasa_creado],
      [pasa_modificado] ,
      [pasa_precio])
(    select 
       case Pasaje_Codigo 
       when 0 then m.Paquete_Codigo
       else Pasaje_Codigo
       end
      ,vi.viaj_id
      ,vc.vouc_id
      ,b.buta_id
      ,m.Paquete_KG
      ,b.buta_numero
      ,0
      ,Pasaje_FechaCompra
      ,SYSDATETIME()
      ,case 
      when Pasaje_Precio=0 then Paquete_Precio
      else pasaje_precio end 
    from [GD1C2013].[gd_esquema].[Maestra] m
    inner join transportados.clientes cli on cli.Cli_Dni=m.Cli_Dni,
  [GD1C2013].[transportados].[viajes] vi
  inner join [GD1C2013].[transportados].[micros] mi on vi.viaj_micro=mi.micr_id
  inner join [GD1C2013].[transportados].[butaca] b on b.buta_micro_id=mi.micr_id,
   [GD1C2013].[transportados].[voucher_de_compra] vc
  where vi.viaj_recorrido=m.Recorrido_Codigo
  and vi.viaj_fecha_salida=m.FechaSalida
  and vc.vouc_cliente_id=cli.Cli_id
  and vc.vouc_viaje_id=vi.viaj_id
  and m.Pasaje_FechaCompra=vc.vouc_creado
  and b.buta_numero=m.Butaca_Nro)

 GO

/****** Object:  Table [transportados].[funcionalidad]    Script Date: 05/21/2013 22:22:38 ******/

Select 'Creo tabla funcionalidad'

GO

CREATE TABLE [transportados].[funcionalidad](
      [func_id] [int] IDENTITY(1,1) NOT NULL,
      [func_name] [nvarchar](255) NULL,
      [func_creado] [datetime] NULL,
      [func_modificado] [datetime] NULL
) ON [PRIMARY]

GO


/****** Object:  Table [transportados].[Rol]    Script Date: 05/21/2013 22:23:31 ******/

Select 'Creo tabla Rol'

GO


CREATE TABLE [transportados].[Rol](
      [rol_id] [int] IDENTITY(1,1) NOT NULL,
      [rol_nombre] [nvarchar](255) NULL,
      [rol_creado] [datetime] NULL,
      [rol_modificado] [datetime] NULL,
      [rol_borrado] [bit] NULL
) ON [PRIMARY]

GO

/****** Object:  Table [transportados].[Rol_funcionalidad]    Script Date: 05/21/2013 22:23:41 ******/

Select 'Creo tabla rol funcionalidad'

GO


CREATE TABLE [transportados].[Rol_funcionalidad](
      [rolf_id] [int] IDENTITY(1,1) NOT NULL,
      [rolf_rol_id] [int] NOT NULL,
      [rolf_func_id] [int] NOT NULL,
      [rolf_creado] [datetime] NULL,
      [rolf_modificado] [datetime] NULL
) ON [PRIMARY]

GO




/****** Object:  Table [transportados].[usuario]    Script Date: 05/21/2013 22:24:19 ******/

Select 'Creo tabla Usuarios'

GO


CREATE TABLE [transportados].[usuario](
  [usua_id] [int] IDENTITY(1,1) NOT NULL,
  [usua_username] [nvarchar](255) NOT NULL,
  [usua_password] [nvarchar](255) NOT NULL,
  [usua_creado] [datetime] NULL,
  [usua_modificado] [datetime] NULL,
  [usua_habilitado] [bit] NULL,
  [usua_logins] [smallint] NULL
) ON [PRIMARY]

GO

ALTER TABLE [transportados].[usuario] ADD  CONSTRAINT [DF_usuario_usua_logins]  DEFAULT ((0)) FOR [usua_logins]
GO

INSERT INTO [GD1C2013].[transportados].[usuario]
           ([usua_username]
           ,[usua_password]
           ,[usua_creado]
           ,[usua_modificado]
           ,[usua_habilitado])
     VALUES
           ('Administrador'
           ,'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
           ,('Admin'
           ,'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
           ,('Vanina'
           ,'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
           ,('Daniel'
           ,'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
           ,('Daniela'
           ,'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
           ,('Diego'
           ,'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
GO


GO
INSERT INTO [GD1C2013].[transportados].[funcionalidad]([func_name],[func_creado],[func_modificado])
  VALUES
('crear_recorrido',SYSDATETIME(),SYSDATETIME()) ,
('listar_recorrido',SYSDATETIME(),SYSDATETIME()) ,
('modificar_recorrido',SYSDATETIME(),SYSDATETIME()), 
('crear_ciudad',SYSDATETIME(),SYSDATETIME()) ,
('listar_ciudad',SYSDATETIME(),SYSDATETIME()) ,
('modificar_ciudad',SYSDATETIME(),SYSDATETIME()), 
('crear_micro',SYSDATETIME(),SYSDATETIME()) ,
('listar_micro',SYSDATETIME(),SYSDATETIME()) ,
('modificar_micro',SYSDATETIME(),SYSDATETIME()), 
('registrar_llegada',SYSDATETIME(),SYSDATETIME()), 
('crear_viaje',SYSDATETIME(),SYSDATETIME()) ,
('modificar_viaje',SYSDATETIME(),SYSDATETIME()), 
('listar_viaje',SYSDATETIME(),SYSDATETIME()) ,
('pasaje_generar',SYSDATETIME(),SYSDATETIME()), 
('pasaje_anular',SYSDATETIME(),SYSDATETIME()) ,
('consulta_puntos',SYSDATETIME(),SYSDATETIME()), 
('listar_roles',SYSDATETIME(),SYSDATETIME()) ,
('listar_funcionalidades',SYSDATETIME(),SYSDATETIME()) ,
('modificar_usuario',SYSDATETIME(),SYSDATETIME()) ,
('Ciudad',SYSDATETIME(),SYSDATETIME()) ,
('Recorrido',SYSDATETIME(),SYSDATETIME()), 
('Micros',SYSDATETIME(),SYSDATETIME()) ,
('Viaje',SYSDATETIME(),SYSDATETIME()), 
('Pasaje',SYSDATETIME(),SYSDATETIME()) ,
('Puntos',SYSDATETIME(),SYSDATETIME()), 
('Usuarios',SYSDATETIME(),SYSDATETIME()) 


GO



GO
insert into [GD1C2013].[transportados].[Rol_funcionalidad]
 ([rolf_rol_id],[rolf_func_id],[rolf_creado],[rolf_modificado])
 values
(1,1,SYSDATETIME(),SYSDATETIME()),
(1,2,SYSDATETIME(),SYSDATETIME()),
(1,3,SYSDATETIME(),SYSDATETIME()),
(1,4,SYSDATETIME(),SYSDATETIME()),
(1,5,SYSDATETIME(),SYSDATETIME()),
(1,6,SYSDATETIME(),SYSDATETIME()),
(1,7,SYSDATETIME(),SYSDATETIME()),
(1,8,SYSDATETIME(),SYSDATETIME()),
(1,9,SYSDATETIME(),SYSDATETIME()),
(1,10,SYSDATETIME(),SYSDATETIME()),
(1,11,SYSDATETIME(),SYSDATETIME()),
(1,12,SYSDATETIME(),SYSDATETIME()),
(1,13,SYSDATETIME(),SYSDATETIME()),
(1,14,SYSDATETIME(),SYSDATETIME()),
(1,15,SYSDATETIME(),SYSDATETIME()),
(1,16,SYSDATETIME(),SYSDATETIME()),
(1,17,SYSDATETIME(),SYSDATETIME()),
(1,18,SYSDATETIME(),SYSDATETIME()),
(1,19,SYSDATETIME(),SYSDATETIME()),
(1,20,SYSDATETIME(),SYSDATETIME()),
(1,21,SYSDATETIME(),SYSDATETIME()),
(1,22,SYSDATETIME(),SYSDATETIME()),
(1,23,SYSDATETIME(),SYSDATETIME()),
(1,24,SYSDATETIME(),SYSDATETIME()),
(1,25,SYSDATETIME(),SYSDATETIME()),
(1,26,SYSDATETIME(),SYSDATETIME())


GO


/****** Object:  Table [transportados].[rol_usuario]    Script Date: 05/21/2013 22:23:54 ******/

Select 'Creo tabla Relacion rol usuario'

GO


CREATE TABLE [transportados].[rol_usuario](
      [rolu_id] [int] IDENTITY(1,1) NOT NULL,
      [rolu_user_id] [int] NOT NULL,
      [rolu_rol_id] [int] NOT NULL,
      [rolu_creado] [datetime] NULL,
      [rolu_modificado] [datetime] NULL
) ON [PRIMARY]

GO


  insert into [GD1C2013].[transportados].[rol_usuario]
  ([rolu_user_id],[rolu_rol_id],[rolu_creado],[rolu_modificado])
  values
  (1,1,SYSDATETIME(),SYSDATETIME()),
  (2,2,SYSDATETIME(),SYSDATETIME())

  GO
  
  
  /****** Object:  Table [transportados].[facturas]    Script Date: 05/21/2013 22:24:19 ******/

Select 'Creo tabla facturas'

GO


CREATE TABLE [transportados].[facturas] (
	[fact_nro_compra] [int] IDENTITY(1,1) NOT NULL,
	[fact_voucher_id] [int] NOT NULL,
	[fact_cliente_id] [int] NOT NULL,
	[fact_fecha_de_compra] [date] NOT NULL,
 CONSTRAINT [PK_transportados.facturas] PRIMARY KEY CLUSTERED 
(
	[fact_nro_compra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [transportados].[premios]    Script Date: 05/21/2013 22:23:12 ******/

Select 'Creo tabla premios'

GO


CREATE TABLE [transportados].[premios](
	[prem_id] [int] IDENTITY(1,1) NOT NULL,
	[prem_descripcion] [nvarchar](255) NULL,
	[prem_puntos] [int] NOT NULL,
	[prem_stock] [int] NOT NULL,
 CONSTRAINT [PK_premios] PRIMARY KEY CLUSTERED 
(
	[prem_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/* creacion de los premios*/
INSERT INTO transportados.premios([prem_descripcion],[prem_puntos],[prem_stock])
VALUES	('Tablet',23000,10)
INSERT INTO transportados.premios([prem_descripcion],[prem_puntos],[prem_stock])
VALUES	('Set de Toallas',6000,30)
INSERT INTO transportados.premios([prem_descripcion],[prem_puntos],[prem_stock])
VALUES	('Perfume',11000,4)
INSERT INTO transportados.premios([prem_descripcion],[prem_puntos],[prem_stock])
VALUES	('Rompecabezas',700,10)
INSERT INTO transportados.premios([prem_descripcion],[prem_puntos],[prem_stock])
VALUES	('Planta',100,10)


/* creacion de las facturas*/
  insert into [transportados].[facturas](
	  [fact_voucher_id],
      [fact_cliente_id] ,
      [fact_fecha_de_compra] 
      )
(    select 
	 vc.vouc_id
	, vc.vouc_cliente_id
      ,Pasaje_FechaCompra

    from [GD1C2013].[gd_esquema].[Maestra] m
    left outer join transportados.clientes cli on cli.Cli_Dni=m.Cli_Dni,
  [GD1C2013].[transportados].[viajes] vi
  left outer join [GD1C2013].[transportados].[micros] mi on vi.viaj_micro=mi.micr_id,
   [GD1C2013].[transportados].[voucher_de_compra] vc
  where vi.viaj_recorrido=m.Recorrido_Codigo
  and vi.viaj_fecha_salida=m.FechaSalida
  and vc.vouc_cliente_id=cli.Cli_id
  and vc.vouc_viaje_id=vi.viaj_id
  and m.Pasaje_FechaCompra=vc.vouc_creado)

 GO
 


Select 'Creo tabla Puntos pasajero frecuente'

GO


CREATE TABLE [transportados].[puntos_pas_frecuente](
	[punt_id] [int] IDENTITY(1,1) NOT NULL,
	[punt_fecha] [date] NULL,
	[punt_puntos] [int] NOT NULL,
	[punt_id_viaje] [int] NOT NULL,
	[punt_valido] [bit] DEFAULT ((0)) NOT NULL
 CONSTRAINT [PK_puntos_pas_frecuente] PRIMARY KEY CLUSTERED 
(
	[punt_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



/****** Object:  Table [transportados].[premios_obtenidos]    Script Date: 05/21/2013 22:23:12 ******/


Select 'Creo tabla Premios Obtenidos'

GO

CREATE TABLE [transportados].[premios_obtenidos](
	[obte_id] [int] IDENTITY(1,1) NOT NULL,
	[obte_fecha] [date] NULL,
	[obte_id_premio] [int] NOT NULL,
	[obte_cantidad] [int] NULL
 CONSTRAINT [PK_premios_obtenidos] PRIMARY KEY CLUSTERED 
(
	[obte_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



Select 'Creo Procedure cargarMicro'

GO


CREATE PROCEDURE [transportados].cargarMicro
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
         
SELECT micr_id FROM micros
WHERE micr_patente = @patenteNueva

END
GO


Select 'Creo Procedure bajaRol'

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



Select 'Creo Procedure buscaViajes'

GO
CREATE PROCEDURE [transportados].[buscaViajes]
  -- Add the parameters for the stored procedure here
  @PATENTE VARCHAR(6),
  @FECHA_INI DATETIME,
  @FECHA_FIN DATETIME
AS
BEGIN

  SET NOCOUNT ON;
  --ESTOS SON LOS PASAJES VENDIDOS DEL MICRO DADO DE BAJA
  SELECT TOP 1 1 
  FROM TRANSPORTADOS.PASAJE Q,
  TRANSPORTADOS.VIAJES V,
  TRANSPORTADOS.MICROS B
  WHERE Q.PASA_VIAJE_ID = V.VIAJ_ID
  AND V.VIAJ_MICRO = B.MICR_ID
  AND B.MICR_PATENTE = @PATENTE
  AND V.VIAJ_FECHA_SALIDA BETWEEN @FECHA_INI AND @FECHA_FIN
  

    
END

GO


Select 'Creo Procedure devolucionPersonal'

GO

CREATE PROCEDURE [transportados].devolucionPersonal

@VOUCHER INT,
@PASAJE int,
@MOTIVO varchar(100)

AS
BEGIN
  

UPDATE transportados.pasaje
SET pasa_fecha_devolucion = SYSDATETIME(),
  pasa_desc_devolucion = @MOTIVO,
  pasa_cod_devolucion = pasa_viaje_id
WHERE PASA_ID = @PASAJE

END
GO


Select 'Creo Procedure devuelvePasajes'

GO

CREATE PROCEDURE [transportados].[devuelvePasajes]

@PATENTE varchar (7),
@FECHA_INI datetime,
@FECHA_FIN datetime,
@BAJA VARCHAR(20)
AS
DECLARE @DEVOLUCION INT

BEGIN

IF(@BAJA = 'Fin vida útil')
	BEGIN
	SET @FECHA_FIN = '99/99/9999'
	END

SET @DEVOLUCION = 1 + (SELECT MAX(pasa_cod_devolucion) 
					FROM transportados.pasajes)

UPDATE transportados.pasajes
SET pasa_fecha_devolucion = SYSDATETIME(),
  pasa_desc_devolucion = 'Micro dado de baja',
  pasa_cod_devolucion = @DEVOLUCION
WHERE PASA_VIAJE_ID in (select distinct V.VIAJ_ID from 
				  TRANSPORTADOS.VIAJES V,
				  TRANSPORTADOS.MICROS B
      where
       V.VIAJ_MICRO = B.MICR_ID
      AND B.MICR_PATENTE = @PATENTE
      AND V.VIAJ_FECHA_SALIDA BETWEEN @FECHA_INI AND @FECHA_FIN)
END

GO


Select 'Creo Procedure existe'

GO

CREATE PROCEDURE [transportados].[existe]
  -- Add the parameters for the stored procedure here
@PATENTE varchar(7)
AS
BEGIN

IF EXISTS (SELECT 1 
FROM TRANSPORTADOS.MICROS 
  WHERE MICR_PATENTE = @PATENTE)
 SELECT 1
  ELSE
  SELECT 0

END

GO

Select 'Creo Procedure microAlterno'

GO

CREATE PROCEDURE [transportados].[microAlterno] 
  -- Add the parameters for the stored procedure here
   @PATENTE VARCHAR(6),
   @FECHA_INI DATETIME,
   @FECHA_FIN DATETIME
AS
	DECLARE @VALOR INT

BEGIN

SET @VALOR =
(SELECT TOP 1 A.MICR_ID
FROM TRANSPORTADOS.MICROS A,
TRANSPORTADOS.MICROS B,
TRANSPORTADOS.VIAJES V

/*BUSCO UN MICRO DE LAS MISMAS CARACTERISTICAS QUE NO ESTE INHABILITADO*/
WHERE B.MICR_PATENTE = @PATENTE
AND A.MICR_PATENTE <> @PATENTE
AND A.MICR_CANT_BUTACAS = B.MICR_CANT_BUTACAS
AND A.MICR_PISOS = B.MICR_PISOS
AND A.MICR_MARCA = B.MICR_MARCA
AND A.MICR_MODELO = B.MICR_MODELO
AND A.MICR_BAJA = 0
AND A.MICR_BAJA_TECNICA = 0
AND A.MICR_TIPO_ID = B.MICR_TIPO_ID

/*BUSCO QUE NO TENGA VIAJES ASIGNADOS*/ 
AND NOT EXISTS (SELECT 1 FROM TRANSPORTADOS.VIAJES C
        WHERE C.VIAJ_MICRO = A.MICR_ID
         AND C.VIAJ_FECHA_SALIDA >= @FECHA_INI
        )
)
IF @VALOR IS NULL
BEGIN
	SET @VALOR = 0
END	

SELECT @VALOR

END

GO

Select 'Creo Procedure pasajesVendidos'

GO

CREATE PROCEDURE [transportados].[pasajesVendidos]
  -- Add the parameters for the stored procedure here
@PATENTE varchar (7),
@FECHA_INI datetime,
@FECHA_FIN datetime
AS
BEGIN
  
  SELECT COUNT(vouc_id) 
    FROM transportados.voucher_de_compra Q,
	TRANSPORTADOS.VIAJES V,
	 TRANSPORTADOS.MICROS B
     WHERE Q.vouc_viaje_id = V.VIAJ_ID
       AND V.VIAJ_MICRO = B.MICR_ID
       AND B.MICR_PATENTE = @PATENTE
     AND V.VIAJ_FECHA_SALIDA BETWEEN @FECHA_INI AND @FECHA_FIN
  
  
END

GO

Select 'Creo Procedure [reemplaza_micro]'

GO

CREATE PROCEDURE [transportados].[reemplaza_micro]
		@id_micro INT,
		@patente VARCHAR(7),
		@inicio DATETIME,
		@fin DATETIME,
		@BAJA VARCHAR(20)

AS
BEGIN

IF(@BAJA = 'Fin vida útil')
	BEGIN
	SET @fin = '99/99/9999'
	END

/*PROCESO TRANSPARENTE QUE CAMBIA EL MICRO ASIGNADO POR OTRO*/
UPDATE TRANSPORTADOS.VIAJES
SET VIAJ_MICRO = @id_micro

WHERE VIAJ_MICRO = (SELECT MICR_ID FROM TRANSPORTADOS.MICROS
			  WHERE MICR_PATENTE = @patente)
AND VIAJ_FECHA_SALIDA BETWEEN @inicio AND @fin

END
GO