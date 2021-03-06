USE [StoreManagement]
GO
/****** Object:  StoredProcedure [dbo].[INSERTINTOUSERSTABLE]    Script Date: 8/14/2021 9:55:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Stella Njoroge
-- Create date: 13/8/2021
-- Description:	Create procedure to help execute insert statements into users table
-- =============================================
ALTER PROCEDURE INSERTINTOUSERSTABLE
	-- Add the parameters for the stored procedure here
	@firstName VARCHAR(120), @lastName VARCHAR(120), @email VARCHAR(120), @userPassword VARCHAR(20)
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO Users VALUES(@firstName, @lastName, @email, @userPassword);
END
GO
