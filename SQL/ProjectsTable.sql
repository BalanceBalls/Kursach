USE [Kursach_db]
GO

/****** Object:  Table [dbo].[Projects]    Script Date: 15.04.2019 4:00:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Projects](
	[Project] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](50) NULL,
	[Cost] [money] NOT NULL,
	[Deadline] [date] NOT NULL,
	[IsDone] [bit] NOT NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Project] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Users] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Users] ([id])
GO

ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Users]
GO


