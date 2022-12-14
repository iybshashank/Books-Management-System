create database [bookManager]
/* Create a database named bookManager */
USE [bookManager]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BooksTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Book] [varchar](30) NULL,
	[Author] [varchar](30) NULL,
	[Year] [int] NULL,
	[Description] [varchar](1000) NULL,
	[ISBN] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lUsers](
	[username] [varchar](20) NULL,
	[passwd] [varchar](20) NULL,
	[isAdmin] [bit] NULL
) ON [PRIMARY]
GO
