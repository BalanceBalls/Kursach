USE [Kursach_db]
GO

/****** Object:  Table [dbo].[StepsOfDevelopment]    Script Date: 15.04.2019 4:01:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StepsOfDevelopment](
	[StepOfDevelopment] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
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


