-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE devolucionPersonal

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
