USE [Kursach_db]
GO

/****** Object:  Table [dbo].[UsersInProjects]    Script Date: 15.04.2019 4:01:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UsersInProjects](
	[ProjectId] [int] NOT NULL,
	[UserId] [int] NOT NULL
) ON [PRIMARY]
GO


