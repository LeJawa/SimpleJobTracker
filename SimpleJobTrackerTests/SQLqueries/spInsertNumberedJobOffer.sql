USE [TestOffersDB]
GO
/****** Object:  StoredProcedure [dbo].[spInsertNumberedJobOffer]    Script Date: 09/05/2023 13:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Escobar
-- Create date: 09/05/2023
-- Description:	Inserts a Job Offer identified by its number
-- =============================================
Create PROCEDURE [dbo].[spInsertNumberedJobOffer] 
	@JobOfferNumber int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE	@CompanyId int

	SET @CompanyId = ( SELECT TOP (1) [Id]
	  FROM [dbo].[Company]
	  where Name = 'Company ' + CAST(@JobOfferNumber as varchar(12)) )

    -- Insert statements for procedure here
	INSERT INTO [dbo].[JobOffers]
           ([Position]
           ,[CompanyId]
           ,[Location]
           ,[Url]
           ,[JobType]
           ,[Status]
           ,[SalaryRangeTop]
           ,[SalaryRangeBottom]
           ,[Comments]
           ,[CreationDate]
           ,[LastChange]
           ,[IsDeleted])
     VALUES
           ('Position ' + CAST(@JobOfferNumber as varchar(12)),
           @CompanyId,
           'Location ' + CAST(@JobOfferNumber as varchar(12)),
           'Url ' + CAST(@JobOfferNumber as varchar(12)),
           1,
           1,
           0,
           0,
           '',
           CURRENT_TIMESTAMP,
           CURRENT_TIMESTAMP,
           0)
END
