USE [dacodesdb]
GO
/****** Object:  Table [dbo].[course]    Script Date: 12/02/2019 12:25:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[course](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](150) NOT NULL,
	[idCorrelative] [int] NULL,
 CONSTRAINT [PK_course] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clave del curso' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del curso' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Curso correlativo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'course', @level2type=N'COLUMN',@level2name=N'idCorrelative'
GO
/****** Object:  Table [dbo].[lesson]    Script Date: 12/02/2019 12:25:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[lesson](
	[id] [int] NOT NULL,
	[name] [varchar](150) NOT NULL,
	[idCourse] [int] NOT NULL,
	[idCorrelative] [int] NULL,
	[aprovatory] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_lesson] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[question]    Script Date: 12/02/2019 12:25:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[question](
	[id] [int] NOT NULL,
	[question] [varchar](250) NOT NULL,
	[idlesson] [int] NOT NULL,
	[value] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_question] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[answer]    Script Date: 12/02/2019 12:25:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[answer](
	[id] [int] NOT NULL,
	[idquestion] [int] NOT NULL,
	[answer] [varchar](250) NOT NULL,
	[isCorrect] [bit] NOT NULL,
 CONSTRAINT [PK_answer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_answer_question]    Script Date: 12/02/2019 12:25:07 ******/
ALTER TABLE [dbo].[answer]  WITH CHECK ADD  CONSTRAINT [FK_answer_question] FOREIGN KEY([idquestion])
REFERENCES [dbo].[question] ([id])
GO
ALTER TABLE [dbo].[answer] CHECK CONSTRAINT [FK_answer_question]
GO
/****** Object:  ForeignKey [FK_lesson_course]    Script Date: 12/02/2019 12:25:07 ******/
ALTER TABLE [dbo].[lesson]  WITH CHECK ADD  CONSTRAINT [FK_lesson_course] FOREIGN KEY([idCourse])
REFERENCES [dbo].[course] ([id])
GO
ALTER TABLE [dbo].[lesson] CHECK CONSTRAINT [FK_lesson_course]
GO
/****** Object:  ForeignKey [FK_question_lesson]    Script Date: 12/02/2019 12:25:07 ******/
ALTER TABLE [dbo].[question]  WITH CHECK ADD  CONSTRAINT [FK_question_lesson] FOREIGN KEY([idlesson])
REFERENCES [dbo].[lesson] ([id])
GO
ALTER TABLE [dbo].[question] CHECK CONSTRAINT [FK_question_lesson]
GO
