USE [Kursach_db]
GO


/****** Object:  Table [dbo].[Projects]    Script Date: 10.03.2019 20:53:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Projects](
	[Project] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](50) NOT NULL,
	[Cost] [money] NOT NULL,
	[Deadline] [date] NOT NULL,
	[IsDone] [bit] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Project] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([id])
GO

ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Users]
GO


USE [Kursach_db]
GO

/****** Object:  Table [dbo].[StepsOfDevelopment]    Script Date: 10.03.2019 20:54:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StepsOfDevelopment](
	[StepOfDevelopment] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[EndDate] [date] NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_StepsOfDevelopment] PRIMARY KEY CLUSTERED 
(
	[StepOfDevelopment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StepsOfDevelopment]  WITH CHECK ADD  CONSTRAINT [FK_StepsOfDevelopment_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Project])
GO

ALTER TABLE [dbo].[StepsOfDevelopment] CHECK CONSTRAINT [FK_StepsOfDevelopment_Projects]
GO


USE [Kursach_db]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 10.03.2019 20:54:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Password] [varchar](32) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


