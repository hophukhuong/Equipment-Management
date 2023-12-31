USE [DoAnCoSo]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/14/2023 4:22:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Credential]    Script Date: 12/14/2023 4:22:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credential](
	[ID] [int] NOT NULL,
	[GroupId] [int] NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_Credential] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 12/14/2023 4:22:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDName] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Avatar] [nchar](100) NULL,
	[Status] [bit] NULL,
	[CategoryID] [int] NULL,
	[Price] [float] NULL,
	[CreatedOnUtc] [datetime] NULL,
	[UpdatedOnUtc] [datetime] NULL,
	[Location] [int] NULL,
	[Amount] [int] NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 12/14/2023 4:22:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 12/14/2023 4:22:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Avatar] [nvarchar](50) NULL,
	[LoginName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [int] NULL,
	[GroupId] [int] NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mission]    Script Date: 12/14/2023 4:22:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Mission] [nvarchar](2000) NULL,
	[MemberId] [int] NULL,
	[CreatedDate] [date] NULL,
	[DoneDate] [date] NULL,
	[Status] [nvarchar](30) NULL,
 CONSTRAINT [PK_Mission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 12/14/2023 4:22:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Member] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[ReportDate] [date] NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/14/2023 4:22:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[GroupName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 12/14/2023 4:22:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Category] ([ID], [Name]) VALUES (1, N'Quạt trần')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (2, N'Máy tính')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (3, N'Máy lạnh')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (4, N'Loa')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (6, N'Kèn')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (7, N'tivi')
GO
INSERT [dbo].[Credential] ([ID], [GroupId], [RoleId]) VALUES (1, 10, 10)
GO
SET IDENTITY_INSERT [dbo].[Equipment] ON 

INSERT [dbo].[Equipment] ([ID], [IDName], [Name], [Avatar], [Status], [CategoryID], [Price], [CreatedOnUtc], [UpdatedOnUtc], [Location], [Amount]) VALUES (9, N'ML-1', N'Máy lạnh', N'image_2023-09-08_133338076.png                                                                      ', 1, 3, 7000000, CAST(N'2023-02-03T00:00:00.000' AS DateTime), CAST(N'2024-02-02T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Equipment] ([ID], [IDName], [Name], [Avatar], [Status], [CategoryID], [Price], [CreatedOnUtc], [UpdatedOnUtc], [Location], [Amount]) VALUES (10, N'ML-2', N'Máy lạnh', N'image_2023-09-08_133338076.png                                                                      ', 1, 3, 7000000, CAST(N'2023-02-03T00:00:00.000' AS DateTime), CAST(N'2024-02-02T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Equipment] ([ID], [IDName], [Name], [Avatar], [Status], [CategoryID], [Price], [CreatedOnUtc], [UpdatedOnUtc], [Location], [Amount]) VALUES (11, N'ML-3', N'Máy lạnh', N'image_2023-09-08_133338076.png                                                                      ', 1, 3, 7000000, CAST(N'2023-02-03T00:00:00.000' AS DateTime), CAST(N'2024-02-02T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Equipment] ([ID], [IDName], [Name], [Avatar], [Status], [CategoryID], [Price], [CreatedOnUtc], [UpdatedOnUtc], [Location], [Amount]) VALUES (12, N'ML-4', N'Máy lạnh', N'image_2023-09-08_133338076.png                                                                      ', 1, 3, 7000000, CAST(N'2023-02-03T00:00:00.000' AS DateTime), CAST(N'2024-02-02T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Equipment] ([ID], [IDName], [Name], [Avatar], [Status], [CategoryID], [Price], [CreatedOnUtc], [UpdatedOnUtc], [Location], [Amount]) VALUES (14, N'ML-5', N'Máy lạnh', N'image_2023-09-08_133338076.png                                                                      ', 1, 3, 7000000, CAST(N'2023-02-03T00:00:00.000' AS DateTime), CAST(N'2024-02-02T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Equipment] ([ID], [IDName], [Name], [Avatar], [Status], [CategoryID], [Price], [CreatedOnUtc], [UpdatedOnUtc], [Location], [Amount]) VALUES (15, N'ML-6', N'Máy lạnh', N'image_2023-09-08_133338076.png                                                                      ', 1, 3, 7000000, CAST(N'2023-02-03T00:00:00.000' AS DateTime), CAST(N'2024-02-02T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Equipment] ([ID], [IDName], [Name], [Avatar], [Status], [CategoryID], [Price], [CreatedOnUtc], [UpdatedOnUtc], [Location], [Amount]) VALUES (16, N'ML-7', N'Máy lạnh', N'image_2023-09-08_133338076.png                                                                      ', 1, 3, 7000000, CAST(N'2023-02-03T00:00:00.000' AS DateTime), CAST(N'2024-02-02T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Equipment] ([ID], [IDName], [Name], [Avatar], [Status], [CategoryID], [Price], [CreatedOnUtc], [UpdatedOnUtc], [Location], [Amount]) VALUES (17, N'QT-1', N'Quạt trần', N'image_2023-09-05_194359479.png                                                                      ', 1, 1, 7000000, CAST(N'2023-02-03T00:00:00.000' AS DateTime), CAST(N'2024-02-02T00:00:00.000' AS DateTime), 2, 1)
SET IDENTITY_INSERT [dbo].[Equipment] OFF
GO
INSERT [dbo].[Group] ([ID], [Name]) VALUES (10, N'Quản trị viên')
INSERT [dbo].[Group] ([ID], [Name]) VALUES (20, N'Thành viên')
GO
INSERT [dbo].[Member] ([ID], [Name], [Avatar], [LoginName], [Password], [CreatedDate], [Status], [GroupId]) VALUES (0, N'Vinh Hiển', NULL, N'vinhhien@gmail.com', N'0bf1aa00e9f75572741f02de8c641d75', CAST(N'2023-02-02T00:00:00.000' AS DateTime), NULL, 20)
INSERT [dbo].[Member] ([ID], [Name], [Avatar], [LoginName], [Password], [CreatedDate], [Status], [GroupId]) VALUES (1, N'Hồ Phú Khương', N'khuong.jpg', N'phukhuong@gmail.com', N'202cb962ac59075b964b07152d234b70', CAST(N'2023-02-03T00:00:00.000' AS DateTime), NULL, 10)
INSERT [dbo].[Member] ([ID], [Name], [Avatar], [LoginName], [Password], [CreatedDate], [Status], [GroupId]) VALUES (2, N'Huỳnh Phúc Lợi', N'loi.jpg', N'huynhphucloi@gmail.com', N'202cb962ac59075b964b07152d234b70', CAST(N'2023-02-02T00:00:00.000' AS DateTime), NULL, 20)
INSERT [dbo].[Member] ([ID], [Name], [Avatar], [LoginName], [Password], [CreatedDate], [Status], [GroupId]) VALUES (3, N'Lê Thị Thu Ngân', N'ngan.jpg', N'thungan@gmail.com', N'202cb962ac59075b964b07152d234b70', CAST(N'2023-02-04T00:00:00.000' AS DateTime), NULL, 20)
INSERT [dbo].[Member] ([ID], [Name], [Avatar], [LoginName], [Password], [CreatedDate], [Status], [GroupId]) VALUES (4, N'Nguyễn Quỳnh Như', NULL, N'quynhnhu@gmail.com', N'd9b1d7db4cd6e70935368a1efb10e377', CAST(N'2023-02-02T00:00:00.000' AS DateTime), NULL, 10)
GO
SET IDENTITY_INSERT [dbo].[Mission] ON 

INSERT [dbo].[Mission] ([ID], [Mission], [MemberId], [CreatedDate], [DoneDate], [Status]) VALUES (1, N'đi bảo trì ML-1', 1, CAST(N'2023-12-13' AS Date), CAST(N'2023-12-14' AS Date), N'Đã hoàn thành')
SET IDENTITY_INSERT [dbo].[Mission] OFF
GO
SET IDENTITY_INSERT [dbo].[Report] ON 

INSERT [dbo].[Report] ([ID], [Member], [Description], [ReportDate], [Status]) VALUES (1, 1, N'dv', CAST(N'2023-12-13' AS Date), N'Đã xử lý')
INSERT [dbo].[Report] ([ID], [Member], [Description], [ReportDate], [Status]) VALUES (2, 1, N'bảo tri máy ML-1', CAST(N'2023-12-13' AS Date), N'Đã xử lý')
INSERT [dbo].[Report] ([ID], [Member], [Description], [ReportDate], [Status]) VALUES (3, 1, N'bảo trì QT-1 hoàn tất', CAST(N'2023-12-13' AS Date), N'Đã xử lý')
INSERT [dbo].[Report] ([ID], [Member], [Description], [ReportDate], [Status]) VALUES (4, 1, N'Bảo trì MT-1', CAST(N'2023-12-13' AS Date), N'Đã xử lý')
INSERT [dbo].[Report] ([ID], [Member], [Description], [ReportDate], [Status]) VALUES (5, 1, N'bảo trì MT-2', CAST(N'2023-12-13' AS Date), N'Đã xử lý')
INSERT [dbo].[Report] ([ID], [Member], [Description], [ReportDate], [Status]) VALUES (6, 1, N'bảo trì QT-1', CAST(N'2023-12-14' AS Date), N'Đã xử lý')
INSERT [dbo].[Report] ([ID], [Member], [Description], [ReportDate], [Status]) VALUES (7, 1, N'bảo trì ML-2', CAST(N'2023-12-14' AS Date), N'Chưa xử lý')
SET IDENTITY_INSERT [dbo].[Report] OFF
GO
INSERT [dbo].[Role] ([Id], [Code], [Name], [GroupName]) VALUES (10, N'view-add-edit-delete', N'xem/thêm/sửa/xóa', N'Thiết bị')
INSERT [dbo].[Role] ([Id], [Code], [Name], [GroupName]) VALUES (20, N'view', N'xem', N'Sản phẩm')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (1, N'PM4')
INSERT [dbo].[Room] ([ID], [Name]) VALUES (2, N'PM5')
INSERT [dbo].[Room] ([ID], [Name]) VALUES (3, N'B104')
INSERT [dbo].[Room] ([ID], [Name]) VALUES (4, N'B105')
GO
