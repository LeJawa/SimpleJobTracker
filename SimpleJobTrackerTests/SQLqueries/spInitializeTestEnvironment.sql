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
-- Author:		Luis Escobar
-- Create date: 09/05/2023
-- Description:	Initializes the Testing environment with 10 total offers (4 deleted) from 8 different companies.
-- =============================================
Create PROCEDURE [dbo].[spInitializeTestEnvironment] 
AS
BEGIN
	-- Clean slate
	EXEC [dbo].[spDropAndCreateTables]

	-- Add Companies
	-- Added in disorder to dissociate id from number
	EXEC [dbo].[spInsertNumberedCompany] @CompanyNumber=8
	EXEC [dbo].[spInsertNumberedCompany] @CompanyNumber=1
	EXEC [dbo].[spInsertNumberedCompany] @CompanyNumber=3
	EXEC [dbo].[spInsertNumberedCompany] @CompanyNumber=6
	EXEC [dbo].[spInsertNumberedCompany] @CompanyNumber=4
	EXEC [dbo].[spInsertNumberedCompany] @CompanyNumber=5
	EXEC [dbo].[spInsertNumberedCompany] @CompanyNumber=7
	EXEC [dbo].[spInsertNumberedCompany] @CompanyNumber=2

	-- Add Offers
	EXEC [dbo].[spInsertNumberedJobOfferByNumberedCompanyWithDeleteStatus] @JobOfferNumber=1, @CompanyNumber=1, @IsDeleted=0
	EXEC [dbo].[spInsertNumberedJobOfferByNumberedCompanyWithDeleteStatus] @JobOfferNumber=2, @CompanyNumber=1, @IsDeleted=0
	EXEC [dbo].[spInsertNumberedJobOfferByNumberedCompanyWithDeleteStatus] @JobOfferNumber=3, @CompanyNumber=2, @IsDeleted=1
	EXEC [dbo].[spInsertNumberedJobOfferByNumberedCompanyWithDeleteStatus] @JobOfferNumber=4, @CompanyNumber=3, @IsDeleted=1
	EXEC [dbo].[spInsertNumberedJobOfferByNumberedCompanyWithDeleteStatus] @JobOfferNumber=5, @CompanyNumber=4, @IsDeleted=0
	EXEC [dbo].[spInsertNumberedJobOfferByNumberedCompanyWithDeleteStatus] @JobOfferNumber=6, @CompanyNumber=5, @IsDeleted=1	
	EXEC [dbo].[spInsertNumberedJobOfferByNumberedCompanyWithDeleteStatus] @JobOfferNumber=7, @CompanyNumber=5, @IsDeleted=0
	EXEC [dbo].[spInsertNumberedJobOfferByNumberedCompanyWithDeleteStatus] @JobOfferNumber=8, @CompanyNumber=6, @IsDeleted=0
	EXEC [dbo].[spInsertNumberedJobOfferByNumberedCompanyWithDeleteStatus] @JobOfferNumber=9, @CompanyNumber=7, @IsDeleted=1
	EXEC [dbo].[spInsertNumberedJobOfferByNumberedCompanyWithDeleteStatus] @JobOfferNumber=10, @CompanyNumber=8, @IsDeleted=0
END
GO
