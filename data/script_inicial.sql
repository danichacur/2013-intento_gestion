USE [GD1C2013]

GO

CREATE SCHEMA [transportados] AUTHORIZATION [gd]
GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[clientes]    Script Date: 05/21/2013 22:22:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[clientes]') AND type in (N'U'))
DROP TABLE [transportados].[clientes]
GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[clientes]    Script Date: 05/21/2013 22:22:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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
) ON [PRIMARY]

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

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[tipo_servicio]    Script Date: 05/21/2013 22:24:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[tipo_servicio]') AND type in (N'U'))
DROP TABLE [transportados].[tipo_servicio]
GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[tipo_servicio]    Script Date: 05/21/2013 22:24:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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


USE [GD1C2013]
GO

/****** Object:  Table [transportados].[micros]    Script Date: 05/21/2013 22:22:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[micros]') AND type in (N'U'))
DROP TABLE [transportados].[micros]
GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[micros]    Script Date: 05/21/2013 22:22:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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
    ,null
    ,null
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
      ts.tipo_id);
  GO

  USE [GD1C2013]
GO

/****** Object:  Table [transportados].[ciudad]    Script Date: 05/21/2013 22:22:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[ciudad]') AND type in (N'U'))
DROP TABLE [transportados].[ciudad]
GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[ciudad]    Script Date: 05/21/2013 22:22:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[recorrido]    Script Date: 05/21/2013 22:23:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[recorrido]') AND type in (N'U'))
DROP TABLE [transportados].[recorrido]
GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[recorrido]    Script Date: 05/21/2013 22:23:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [transportados].[recorrido](
      [reco_id] [nvarchar](255) NOT NULL,
      [reco_id_ciudad_origen] [int] NOT NULL,
      [reco_id_ciudad_destino] [int] NOT NULL,
      [reco_tipo_id] [int] NOT NULL,
      [reco_precio_base] [int] NOT NULL,
      [reco_precio_encomienda] [int] NOT NULL,
      [reco_creado] [datetime] NULL,
      [reco_modificado] [datetime] NULL
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

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[viajes]    Script Date: 05/21/2013 22:24:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[viajes]') AND type in (N'U'))
DROP TABLE [transportados].[viajes]
GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[viajes]    Script Date: 05/21/2013 22:24:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [transportados].[viajes](
      [viaj_id] [int] IDENTITY(1,1) NOT NULL,
      [viaj_fecha_salida] [datetime] NULL,
      [viaj_fecha_llegada] [datetime] NULL,
      [viaj_fecha_llegada_estimada] [datetime] NULL,
      [viaj_micro] [int] NOT NULL,
      [viaj_recorrido] [nvarchar](18) NULL,
      [viaj_creado] [datetime] NULL,
      [viaj_modificado] [datetime] NULL
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
    ,[viaj_modificado])
    (SELECT 
    m.[FechaSalida]
    ,m.[FechaLLegada]
    ,m.[Fecha_LLegada_Estimada]
    ,mi.micr_id
    ,m.[Recorrido_Codigo]
    ,SYSDATETIME()
    ,SYSDATETIME()
    FROM [GD1C2013].[gd_esquema].[Maestra] m
    left outer join  [GD1C2013].[transportados].[micros] mi on mi.micr_patente = m.Micro_Patente
    group by m.[FechaSalida]
    ,m.[FechaLLegada]
    ,m.[Fecha_LLegada_Estimada]
    ,mi.micr_id
    ,m.[Recorrido_Codigo]);
    GO


USE [GD1C2013]
GO

/****** Object:  Table [transportados].[butaca]    Script Date: 05/21/2013 22:14:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[butaca]') AND type in (N'U'))
DROP TABLE [transportados].[butaca]
GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[butaca]    Script Date: 05/21/2013 22:14:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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
  ,Butaca_Piso
  ,mi.micr_id
  ,case Butaca_Tipo
  when 'Pasillo' then 1
  else 0 end
   FROM [GD1C2013].[gd_esquema].[Maestra] m
  left outer join [transportados].[micros] mi on mi.micr_patente=m.Micro_Patente
  group by Butaca_Nro
    ,Butaca_Tipo,Butaca_Piso,mi.micr_id 
    );
      GO
USE [GD1C2013]
GO

/****** Object:  Table [transportados].[pasaje]    Script Date: 05/21/2013 22:22:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[pasaje]') AND type in (N'U'))
DROP TABLE [transportados].[pasaje]
GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[pasaje]    Script Date: 05/21/2013 22:22:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [transportados].[pasaje](
      [pasa_id] [int] IDENTITY(1,1) NOT NULL,
      [pasa_cliente_id][int] NOT NULL,
      [pasa_creado] [datetime] NULL,
      [pasa_modificado] [datetime] NULL,
      [pasa_cantidad] [int] NOT NULL,
      [pasa_KG] [int] NOT NULL,
      [pasa_viaje_id] [int],
      [pasa_precio_total] [int] NULL,
      [pasa_precio_bonificado] [int] NULL
) ON [PRIMARY]

GO

/* creacion del pasaje */
  INSERT INTO [GD1C2013].[transportados].[pasaje] (
      [pasa_cliente_id],
      [pasa_creado],
      [pasa_modificado],
      [pasa_cantidad] ,
      [pasa_KG],
      [pasa_viaje_id],
      [pasa_precio_total],
      [pasa_precio_bonificado] )
  (select a.Cli_id
  ,a.Pasaje_FechaCompra
  ,SYSDATETIME()
  ,COUNT(*)
  ,sum(a.Paquete_KG)
  ,a.viaj_id
  ,sum(a.precio)
  ,0
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



USE [GD1C2013]
GO

/****** Object:  Table [transportados].[pasaje_coupon]    Script Date: 05/21/2013 22:23:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[pasaje_coupon]') AND type in (N'U'))
DROP TABLE [transportados].[pasaje_coupon]
GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[pasaje_coupon]    Script Date: 05/21/2013 22:23:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [transportados].[pasaje_coupon](
      [cupo_id] [int]  NOT NULL,
      [cupo_viaje_id] [int] NOT NULL,
      [cupo_pasa_id] [int] NOT NULL,
      [cupo_butaca_id] [int] NULL,
      [cupo_kg_encomienda] [int] NULL,
      [cupo_butaca] [bit] NULL,
      [cupo_bonificado] [bit] NULL,
      [cupo_creado] [datetime] NULL,
      [cupo_modificado] [datetime] NULL,
      [cupo_precio] [int] NULL
) ON [PRIMARY]

GO
/* creacion de los cupones de los pasajes*/
  insert into [transportados].[pasaje_coupon](
      [cupo_id] ,
      [cupo_viaje_id] ,
      [cupo_pasa_id] ,
      [cupo_butaca_id] ,
      [cupo_kg_encomienda] ,
      [cupo_butaca] ,
      [cupo_bonificado] ,
      [cupo_creado],
      [cupo_modificado] ,
      [cupo_precio])
(    select 
      Pasaje_Codigo
      ,vi.viaj_id
      ,p.pasa_id
      ,b.buta_id
      ,m.Paquete_KG
      ,Butaca_Nro
      ,0
      ,Pasaje_FechaCompra
      ,SYSDATETIME()
      ,case 
      when Pasaje_Precio=0 then Paquete_Precio
      else pasaje_precio end 
    from [GD1C2013].[gd_esquema].[Maestra] m
    left outer join transportados.clientes cli on cli.Cli_Dni=m.Cli_Dni,
  [GD1C2013].[transportados].[viajes] vi
  left outer join [GD1C2013].[transportados].[micros] mi on vi.viaj_micro=mi.micr_id
  left outer join [GD1C2013].[transportados].[butaca] b on b.buta_micro_id=mi.micr_id,
   [GD1C2013].[transportados].[pasaje] p
  where vi.viaj_recorrido=m.Recorrido_Codigo
  and vi.viaj_fecha_salida=m.FechaSalida
  and p.pasa_cliente_id=cli.Cli_id
  and p.pasa_viaje_id=vi.viaj_id
  and m.Pasaje_FechaCompra=p.pasa_creado
  and b.buta_numero=m.Butaca_Nro)


USE [GD1C2013]
GO

/****** Object:  Table [transportados].[funcionalidad]    Script Date: 05/21/2013 22:22:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[funcionalidad]') AND type in (N'U'))
DROP TABLE [transportados].[funcionalidad]
GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[funcionalidad]    Script Date: 05/21/2013 22:22:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [transportados].[funcionalidad](
      [func_id] [int] IDENTITY(1,1) NOT NULL,
      [func_name] [nvarchar](255) NULL,
      [func_creado] [datetime] NULL,
      [func_modificado] [datetime] NULL
) ON [PRIMARY]

GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[Rol]    Script Date: 05/21/2013 22:23:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[Rol]') AND type in (N'U'))
DROP TABLE [transportados].[Rol]
GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[Rol]    Script Date: 05/21/2013 22:23:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [transportados].[Rol](
      [rol_id] [int] IDENTITY(1,1) NOT NULL,
      [rol_nombre] [nvarchar](255) NULL,
      [rol_creado] [datetime] NULL,
      [rol_modificado] [datetime] NULL,
      [rol_borrado] [bit] NULL
) ON [PRIMARY]

GO
USE [GD1C2013]
GO

/****** Object:  Table [transportados].[Rol_funcionalidad]    Script Date: 05/21/2013 22:23:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[Rol_funcionalidad]') AND type in (N'U'))
DROP TABLE [transportados].[Rol_funcionalidad]
GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[Rol_funcionalidad]    Script Date: 05/21/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [transportados].[Rol_funcionalidad](
      [rolf_id] [int] IDENTITY(1,1) NOT NULL,
      [rolf_rol_id] [int] NOT NULL,
      [rolf_func_id] [int] NOT NULL,
      [rolf_creado] [datetime] NULL,
      [rolf_modificado] [datetime] NULL
) ON [PRIMARY]

GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[rol_usuario]    Script Date: 05/21/2013 22:23:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[rol_usuario]') AND type in (N'U'))
DROP TABLE [transportados].[rol_usuario]
GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[rol_usuario]    Script Date: 05/21/2013 22:23:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [transportados].[rol_usuario](
      [rolu_id] [int] IDENTITY(1,1) NOT NULL,
      [rolu_user_id] [int] NOT NULL,
      [rolu_rol_id] [int] NOT NULL,
      [rolu_creado] [datetime] NULL,
      [rolu_modificado] [datetime] NULL
) ON [PRIMARY]

GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[usuario]    Script Date: 05/21/2013 22:24:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[usuario]') AND type in (N'U'))
DROP TABLE [transportados].[usuario]
GO

USE [GD1C2013]
GO

/****** Object:  Table [transportados].[usuario]    Script Date: 05/21/2013 22:24:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [transportados].[usuario](
      [usua_id] [int] IDENTITY(1,1) NOT NULL,
      [usua_username] [nvarchar](255) NOT NULL,
      [usua_password] [nvarchar](255) NOT NULL,
      [usua_creado] [datetime] NULL,
      [usua_modificado] [datetime] NULL,
      [usua_habilitado] [bit] NULL
) ON [PRIMARY]

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


