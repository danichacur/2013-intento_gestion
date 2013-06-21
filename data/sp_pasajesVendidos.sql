USE [GD1C2013]
GO

/****** Object:  StoredProcedure [dbo].[pasajesVendidos]    Script Date: 06/21/2013 01:28:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[pasajesVendidos]
	-- Add the parameters for the stored procedure here
@PATENTE varchar (7),
@FECHA_INI datetime,
@FECHA_FIN datetime
AS
BEGIN
	
	SELECT SUM(PASA_CANTIDAD) 
                                        FROM TRANSPORTADOS.PASAJE Q,
                                        TRANSPORTADOS.VIAJES V,
                                        TRANSPORTADOS.MICROS B
                                        WHERE Q.PASA_VIAJE_ID = V.VIAJ_ID
	                                        AND V.VIAJ_MICRO = B.MICR_ID
	                                        AND B.MICR_PATENTE = @PATENTE
	                                        AND V.VIAJ_FECHA_SALIDA BETWEEN @FECHA_INI AND @FECHA_FIN
	
	
END

GO


