USE [GD1C2013]
GO

/****** Object:  StoredProcedure [dbo].[existe]    Script Date: 06/21/2013 01:27:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[existe]
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


