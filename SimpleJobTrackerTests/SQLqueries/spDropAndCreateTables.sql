USE [TestOffersDB]
GO
/****** Object:  StoredProcedure [dbo].[spDropAndCreateJobOffersTable]    Script Date: 09/05/2023 12:35:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Escobar
-- Create date: 09/05/2023
-- Description:	Drops and recreates the JobOffers and Company table
-- =============================================
Create PROCEDURE [dbo].[spDropAndCreateTables] 
AS
BEGIN
	ALTER TABLE [dbo].[JobOffers] DROP CONSTRAINT [FK_JobOffers_Company_CompanyId]

	/****** Object:  Table [dbo].[JobOffers]    Script Date: 09/05/2023 12:17:35 ******/
	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobOffers]') AND type in (N'U'))
	DROP TABLE [dbo].[JobOffers]

	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Company]') AND type in (N'U'))
	DROP TABLE [dbo].[Company]

	/****** Object:  Table [dbo].[JobOffers]    Script Date: 09/05/2023 12:17:35 ******/
	SET ANSI_NULLS ON

	SET QUOTED_IDENTIFIER ON

	CREATE TABLE [dbo].[Company](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](max) NOT NULL,
	 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	CREATE TABLE [dbo].[JobOffers](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Position] [nvarchar](max) NOT NULL,
		[CompanyId] [int] NOT NULL,
		[Location] [nvarchar](max) NOT NULL,
		[Url] [nvarchar](max) NOT NULL,
		[JobType] [int] NOT NULL,
		[Status] [int] NOT NULL,
		[SalaryRangeTop] [decimal](18, 2) NOT NULL,
		[SalaryRangeBottom] [decimal](18, 2) NOT NULL,
		[Comments] [nvarchar](max) NOT NULL,
		[CreationDate] [datetime2](7) NOT NULL,
		[LastChange] [datetime2](7) NOT NULL,
		[IsDeleted] [bit] NOT NULL,
	 CONSTRAINT [PK_JobOffers] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	ALTER TABLE [dbo].[JobOffers]  WITH CHECK ADD  CONSTRAINT [FK_JobOffers_Company_CompanyId] FOREIGN KEY([CompanyId])
	REFERENCES [dbo].[Company] ([Id])
	ON DELETE CASCADE

	ALTER TABLE [dbo].[JobOffers] CHECK CONSTRAINT [FK_JobOffers_Company_CompanyId]

END
