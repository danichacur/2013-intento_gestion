USE [GD1C2013]
GO

/****** Object:  Table [transportados].[pasaje]    Script Date: 06/21/2013 00:53:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [transportados].[pasaje](
	[pasa_id] [int] IDENTITY(1,1) NOT NULL,
	[pasa_cliente_id] [int] NOT NULL,
	[pasa_creado] [datetime] NULL,
	[pasa_modificado] [datetime] NULL,
	[pasa_cantidad] [int] NOT NULL,
	[pasa_KG] [int] NOT NULL,
	[pasa_viaje_id] [int] NULL,
	[pasa_precio_total] [int] NULL,
	[pasa_precio_bonificado] [int] NULL,
	[pasa_cod_devolucion] [int] NULL,
	[pasa_fecha_devolucion] [datetime] NULL,
	[pasa_desc_devolucion] [varchar](100) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


