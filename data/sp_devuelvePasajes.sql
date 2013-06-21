USE [GD1C2013]
GO

/****** Object:  StoredProcedure [dbo].[devuelvePasajes]    Script Date: 06/21/2013 03:30:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[devuelvePasajes]

@PATENTE varchar (7),
@FECHA_INI datetime,
@FECHA_FIN datetime
AS
BEGIN
	

UPDATE transportados.pasaje
SET pasa_fecha_devolucion = SYSDATETIME(),
	pasa_desc_devolucion = 'Micro cancelado',
	pasa_cod_devolucion = pasa_viaje_id
WHERE PASA_VIAJE_ID = (select distinct V.VIAJ_ID from 
			TRANSPORTADOS.VIAJES V,
			TRANSPORTADOS.MICROS B
			where
			 V.VIAJ_MICRO = B.MICR_ID
			AND B.MICR_PATENTE = @PATENTE
			AND V.VIAJ_FECHA_SALIDA BETWEEN @FECHA_INI AND @FECHA_FIN)
END

GO


