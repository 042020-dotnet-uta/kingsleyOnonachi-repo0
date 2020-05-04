USE [demo]
GO

/****** Object:  Table [dbo].[Country]    Script Date: 4/29/2020 15:57:13 ******/
SET ANSI_NULLS ON
GO
Drop table Country;
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Country](
	[countryId] [int] IDENTITY(1,1) NOT NULL,
	[country] [nvarchar](30) NULl,
	Primary Key(countryId)
);
GO


