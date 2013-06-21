USE [GD1C2013]
GO

/****** Object:  StoredProcedure [dbo].[buscaViajes]    Script Date: 06/21/2013 01:26:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[buscaViajes]
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


