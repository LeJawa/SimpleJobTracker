USE [TestOffersDB]
GO
/****** Object:  StoredProcedure [dbo].[spInsertNumberedCompany]    Script Date: 09/05/2023 13:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Escobar
-- Create date: 09/05/2023
-- Description:	Inserts a company identified by its number
-- =============================================
Create PROCEDURE [dbo].[spInsertNumberedCompany] 
	@CompanyNumber int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Company]
           ([Name])
     VALUES
           ('Company ' + CAST(@CompanyNumber as varchar(12)))
END
