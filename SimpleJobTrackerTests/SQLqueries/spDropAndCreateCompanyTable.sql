USE [TestOffersDB]
GO
/****** Object:  StoredProcedure [dbo].[spDropAndCreateCompanyTable]    Script Date: 09/05/2023 12:23:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Escobar
-- Create date: 09/05/2023
-- Description:	Drops and recreates the Company table
-- =============================================
CREATE PROCEDURE [dbo].[spDropAndCreateCompanyTable] 
AS
BEGIN
	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Company]') AND type in (N'U'))
	DROP TABLE [dbo].[Company]

	/****** Object:  Table [dbo].[Company]    Script Date: 09/05/2023 12:21:15 ******/
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

END
