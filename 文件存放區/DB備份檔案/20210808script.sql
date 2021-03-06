USE [MovieReviewDB]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 2021/8/8 下午 12:54:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[Account] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[NickName] [nvarchar](20) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Members_1] PRIMARY KEY CLUSTERED 
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieComments]    Script Date: 2021/8/8 下午 12:54:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieComments](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MovieId] [uniqueidentifier] NOT NULL,
	[Account] [nvarchar](50) NULL,
	[ReviewMessage] [nvarchar](50) NOT NULL,
	[ReviewScore] [float] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_MovieComments_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieImageFile]    Script Date: 2021/8/8 下午 12:54:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieImageFile](
	[MovieId] [uniqueidentifier] NOT NULL,
	[FileId] [uniqueidentifier] NULL,
	[ImageFile] [varbinary](max) NULL,
	[ImageFileName] [nvarchar](50) NULL,
	[FileType] [varchar](50) NULL,
 CONSTRAINT [PK_MovieImageFile] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 2021/8/8 下午 12:54:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [uniqueidentifier] NOT NULL,
	[MovieName] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](200) NULL,
	[ReleaseDate] [date] NULL,
	[MovieDescription] [ntext] NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMembers]    Script Date: 2021/8/8 下午 12:54:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMembers](
	[RoleId] [bigint] NOT NULL,
	[Account] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RoleMembers] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2021/8/8 下午 12:54:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Movies] ([Id], [MovieName], [Category], [ReleaseDate], [MovieDescription]) VALUES (N'6c8eb6c7-dd0f-485f-a5f9-2de55017fcb4', N'string', N'string', CAST(N'2021-08-04' AS Date), N'string')
INSERT [dbo].[Movies] ([Id], [MovieName], [Category], [ReleaseDate], [MovieDescription]) VALUES (N'e7985650-3923-4827-81ab-75ed5d75e5b8', N'string', N'string', CAST(N'2021-08-04' AS Date), N'string')
INSERT [dbo].[Movies] ([Id], [MovieName], [Category], [ReleaseDate], [MovieDescription]) VALUES (N'71c058db-ad37-4de1-8450-f872ad7b5e51', N'string', N'string', CAST(N'2021-08-04' AS Date), N'string')
GO
ALTER TABLE [dbo].[Members] ADD  CONSTRAINT [DF_Members_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[MovieComments]  WITH CHECK ADD  CONSTRAINT [FK_MovieComments_MovieComments] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[MovieComments] CHECK CONSTRAINT [FK_MovieComments_MovieComments]
GO
ALTER TABLE [dbo].[MovieImageFile]  WITH CHECK ADD  CONSTRAINT [FK_MovieImageFile_Movies] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[MovieImageFile] CHECK CONSTRAINT [FK_MovieImageFile_Movies]
GO
ALTER TABLE [dbo].[RoleMembers]  WITH CHECK ADD  CONSTRAINT [FK_RoleMembers_Members] FOREIGN KEY([Account])
REFERENCES [dbo].[Members] ([Account])
GO
ALTER TABLE [dbo].[RoleMembers] CHECK CONSTRAINT [FK_RoleMembers_Members]
GO
ALTER TABLE [dbo].[RoleMembers]  WITH CHECK ADD  CONSTRAINT [FK_RoleMembers_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[RoleMembers] CHECK CONSTRAINT [FK_RoleMembers_Roles]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members', @level2type=N'COLUMN',@level2name=N'Account'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加密密碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'暱稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members', @level2type=N'COLUMN',@level2name=N'NickName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否刪除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovieComments', @level2type=N'COLUMN',@level2name=N'Account'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'副檔名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovieImageFile', @level2type=N'COLUMN',@level2name=N'FileType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電影名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Movies', @level2type=N'COLUMN',@level2name=N'MovieName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分類' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Movies', @level2type=N'COLUMN',@level2name=N'Category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上映日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Movies', @level2type=N'COLUMN',@level2name=N'ReleaseDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電影描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Movies', @level2type=N'COLUMN',@level2name=N'MovieDescription'
GO
