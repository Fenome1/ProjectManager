USE [master]
GO
/****** Object:  Database [ProjectManager]    Script Date: 06.11.2023 7:52:51 ******/
CREATE DATABASE [ProjectManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectManager', FILENAME = N'/var/opt/mssql/data/ProjectManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectManager_log', FILENAME = N'/var/opt/mssql/data/ProjectManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ProjectManager] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectManager] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectManager] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjectManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectManager', N'ON'
GO
ALTER DATABASE [ProjectManager] SET QUERY_STORE = ON
GO
ALTER DATABASE [ProjectManager] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ProjectManager]
GO
/****** Object:  Table [dbo].[Agency]    Script Date: 06.11.2023 7:52:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agency](
	[IdAgency] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Agency] PRIMARY KEY CLUSTERED 
(
	[IdAgency] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Board]    Script Date: 06.11.2023 7:52:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Board](
	[IdBoard] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IdProject] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Board] PRIMARY KEY CLUSTERED 
(
	[IdBoard] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 06.11.2023 7:52:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[IdColor] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[HexCode] [nvarchar](9) NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[IdColor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Column]    Script Date: 06.11.2023 7:52:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Column](
	[IdColumn] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IdBoard] [int] NOT NULL,
	[IdColor] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Column] PRIMARY KEY CLUSTERED 
(
	[IdColumn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Objective]    Script Date: 06.11.2023 7:52:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Objective](
	[IdObjective] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IdColumn] [int] NOT NULL,
	[IdPriority] [int] NULL,
	[Deadline] [date] NULL,
	[Status] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Objective] PRIMARY KEY CLUSTERED 
(
	[IdObjective] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ObjectiveUser]    Script Date: 06.11.2023 7:52:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ObjectiveUser](
	[IdObjective] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_ObjectiveUser] PRIMARY KEY CLUSTERED 
(
	[IdObjective] ASC,
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Priority]    Script Date: 06.11.2023 7:52:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Priority](
	[IdPriority] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[HexCode] [nvarchar](9) NOT NULL,
 CONSTRAINT [PK_Priority] PRIMARY KEY CLUSTERED 
(
	[IdPriority] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 06.11.2023 7:52:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[IdProject] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IdAgency] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[IdProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 06.11.2023 7:52:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 06.11.2023 7:52:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[IdRole] [int] NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[FullName] [nvarchar](255) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Agency] ON 

INSERT [dbo].[Agency] ([IdAgency], [Name], [Description], [IsDeleted]) VALUES (7113, N'Агенство 1', NULL, 0)
INSERT [dbo].[Agency] ([IdAgency], [Name], [Description], [IsDeleted]) VALUES (7114, N'Агенство 2', NULL, 0)
INSERT [dbo].[Agency] ([IdAgency], [Name], [Description], [IsDeleted]) VALUES (7115, N'Агетнство 3', NULL, 1)
INSERT [dbo].[Agency] ([IdAgency], [Name], [Description], [IsDeleted]) VALUES (7116, N'Агентсвто 3', NULL, 0)
SET IDENTITY_INSERT [dbo].[Agency] OFF
GO
SET IDENTITY_INSERT [dbo].[Board] ON 

INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (75, N'Новая доска', 3090, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (76, N'Новая доска', 3091, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (77, N'Новая доска', 3092, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (78, N'Новая доска', 3093, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (79, N'Доска 1', 3090, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (80, N'Доска 1', 3092, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (81, N'Доска 1', 3091, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (82, N'Доска 1', 3093, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (83, N'Кому 25?', 3091, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (84, N'Новая доска', 3094, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (85, N'Новая доска', 3095, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (86, N'Не факт кстати?', 3095, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (87, N'Привет)', 3090, 1)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (88, N'Привети', 3090, 1)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (89, N'Привети', 3090, 1)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (90, N'Доска', 3090, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (91, N'Новая доска', 3096, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (92, N'Новая доска', 3097, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (93, N'Новая доска', 3098, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (94, N'Новая доска', 3099, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (95, N'Новая доска', 3100, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (96, N'Новая доска', 3101, 0)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject], [IsDeleted]) VALUES (97, N'Новая доска', 3102, 0)
SET IDENTITY_INSERT [dbo].[Board] OFF
GO
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([IdColor], [Name], [HexCode]) VALUES (1, N'Стандарт', N'#508D83DA')
INSERT [dbo].[Color] ([IdColor], [Name], [HexCode]) VALUES (3, N'Желтый', N'#50FEFF66')
INSERT [dbo].[Color] ([IdColor], [Name], [HexCode]) VALUES (4, N'Зеленый', N'#5069FF18')
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[Column] ON 

INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3224, N'Новая колонка', 75, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3225, N'Новая колонка', 76, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3226, N'Новая колонка', 77, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3227, N'Новая колонка', 78, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3228, N'Новая колонка', 79, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3230, N'Новая колонка', 81, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3231, N'Новая колонка', 82, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3235, N'Пьяный уебан', 76, 1, 1)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3236, N'Новая колонка', 76, 1, 1)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3237, N'Прям', 76, 1, 1)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3238, N'Да', 76, 1, 1)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3239, N'Новая колонка', 83, 1, 1)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3240, N'Да', 83, 1, 1)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3241, N'Да хз', 83, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3242, N'Знают все мои друзья', 83, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3243, N'Новая колонка', 84, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3244, N'Новая колонка', 85, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3245, N'Честно хз', 85, 1, 1)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3246, N'Новая колонка', 86, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3247, N'Да', 86, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3248, N'Новая колонка', 87, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3249, N'Нет(((', 87, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3250, N'Новая колонка', 88, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3251, N'Новая колонка', 89, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3252, N'Новая колонка', 90, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3253, N'Да', 90, 1, 1)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3254, N'Новая колонка', 91, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3255, N'Новая колонка', 92, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3256, N'Новая колонка', 93, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3257, N'Новая колонка', 94, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3258, N'Новая колонка', 95, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3259, N'Новая колонка', 96, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3260, N'12', 96, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3261, N'Новая колонка', 97, 1, 0)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor], [IsDeleted]) VALUES (3262, N'Ну привет)', 97, 1, 0)
SET IDENTITY_INSERT [dbo].[Column] OFF
GO
SET IDENTITY_INSERT [dbo].[Objective] ON 

INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (57, N'Что-то ду', NULL, 3224, NULL, CAST(N'2004-03-12' AS Date), 1, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (58, N'Что-то ду2', NULL, 3228, 1, NULL, 1, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (59, N'Что-то Ду', NULL, 3226, 3, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (60, N'Что-то ду', NULL, 3225, 3, CAST(N'2004-03-12' AS Date), 1, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (61, N'Что-то ду', NULL, 3227, NULL, CAST(N'2004-03-12' AS Date), 1, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (62, N'ей', NULL, 3224, 1, CAST(N'2004-03-12' AS Date), 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (63, N'алблак', NULL, 3226, 3, CAST(N'2004-03-12' AS Date), 1, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (64, N'52', NULL, 3225, 2, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (65, N'Биг бейби тейп', NULL, 3227, NULL, CAST(N'2004-03-12' AS Date), 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (66, N'Кууул', NULL, 3228, 1, CAST(N'2004-03-12' AS Date), 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (68, N'Слейв 1', NULL, 3231, 2, CAST(N'2004-03-12' AS Date), 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (69, N'Ей 25', NULL, 3230, 1, NULL, 1, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (70, N'52 52 52', NULL, 3231, 2, CAST(N'2004-03-12' AS Date), 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (77, N'12', NULL, 3235, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (78, N'цук', NULL, 3235, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (79, N'Ураа', NULL, 3236, NULL, NULL, 0, 1)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (80, N'Она новоя???', NULL, 3236, NULL, NULL, 0, 1)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (81, N'АЖЖАА', NULL, 3236, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (82, N'Да хз', NULL, 3240, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (83, N'ЫЫЫЫ', NULL, 3241, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (84, N'Я люблю бухать', NULL, 3241, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (85, N'Бухают???', NULL, 3244, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (86, N'ДАА)))', NULL, 3244, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (87, N'Конечно', NULL, 3245, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (88, N'ДА))', NULL, 3246, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (89, N'Да', NULL, 3248, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (90, N'Да', NULL, 3251, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (91, N'Нет((((((', NULL, 3251, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (92, N'Да', NULL, 3252, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (93, N'123', NULL, 3254, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (94, N'qwer', NULL, 3255, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (95, N'qwe', NULL, 3259, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (96, N'12232', NULL, 3258, NULL, NULL, 0, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status], [IsDeleted]) VALUES (97, N'Привет', NULL, 3261, NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Objective] OFF
GO
SET IDENTITY_INSERT [dbo].[Priority] ON 

INSERT [dbo].[Priority] ([IdPriority], [Name], [HexCode]) VALUES (1, N'Не важно', N'#FFFFFF')
INSERT [dbo].[Priority] ([IdPriority], [Name], [HexCode]) VALUES (2, N'Нормально', N'#FFF943')
INSERT [dbo].[Priority] ([IdPriority], [Name], [HexCode]) VALUES (3, N'Важно', N'#FF4643')
SET IDENTITY_INSERT [dbo].[Priority] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency], [IsDeleted]) VALUES (3090, N'Проект 1', 7113, 0)
INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency], [IsDeleted]) VALUES (3091, N'Проект 2', 7114, 0)
INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency], [IsDeleted]) VALUES (3092, N'Проект 2', 7113, 0)
INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency], [IsDeleted]) VALUES (3093, N'Проект 2', 7114, 0)
INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency], [IsDeleted]) VALUES (3094, N'Агентство 3', 7113, 1)
INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency], [IsDeleted]) VALUES (3095, N'Бухарики', 7115, 1)
INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency], [IsDeleted]) VALUES (3096, N'Леша', 7113, 1)
INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency], [IsDeleted]) VALUES (3097, N'qwe', 7113, 1)
INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency], [IsDeleted]) VALUES (3098, N'123', 7113, 1)
INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency], [IsDeleted]) VALUES (3099, N'12354', 7113, 1)
INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency], [IsDeleted]) VALUES (3100, N'12', 7113, 1)
INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency], [IsDeleted]) VALUES (3101, N'123', 7113, 1)
INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency], [IsDeleted]) VALUES (3102, N'Проект1', 7116, 0)
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (4, N'Администратор')
INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (2, N'Исполнитель')
INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (3, N'Менеджер проекта')
INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (1, N'Пользователь')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([IdUser], [IdRole], [Login], [Password], [FullName], [IsDeleted]) VALUES (1, 2, N'Frontender', N'Password', N'Front Man', 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Agency]    Script Date: 06.11.2023 7:52:52 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Agency] ON [dbo].[Agency]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Board]    Script Date: 06.11.2023 7:52:52 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Board] ON [dbo].[Board]
(
	[IdBoard] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Column]    Script Date: 06.11.2023 7:52:52 ******/
CREATE NONCLUSTERED INDEX [UQ_Column] ON [dbo].[Column]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Objective]    Script Date: 06.11.2023 7:52:52 ******/
CREATE NONCLUSTERED INDEX [UQ_Objective] ON [dbo].[Objective]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Objective_User]    Script Date: 06.11.2023 7:52:52 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Objective_User] ON [dbo].[ObjectiveUser]
(
	[IdObjective] ASC,
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Project]    Script Date: 06.11.2023 7:52:52 ******/
CREATE NONCLUSTERED INDEX [UQ_Project] ON [dbo].[Project]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Role]    Script Date: 06.11.2023 7:52:52 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Role] ON [dbo].[Role]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Agency] ADD  CONSTRAINT [DF_Agency_IsDelete]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Board] ADD  CONSTRAINT [DF_Board_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Column] ADD  CONSTRAINT [DF_Column_IdColor]  DEFAULT ((1)) FOR [IdColor]
GO
ALTER TABLE [dbo].[Column] ADD  CONSTRAINT [DF_Column_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Objective] ADD  CONSTRAINT [DF_Task_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Objective] ADD  CONSTRAINT [DF_Objective_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Project] ADD  CONSTRAINT [DF_Project_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IdRole]  DEFAULT ((1)) FOR [IdRole]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Board]  WITH CHECK ADD  CONSTRAINT [FK_Project_Board] FOREIGN KEY([IdProject])
REFERENCES [dbo].[Project] ([IdProject])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Board] CHECK CONSTRAINT [FK_Project_Board]
GO
ALTER TABLE [dbo].[Column]  WITH CHECK ADD  CONSTRAINT [FK_Board_Column] FOREIGN KEY([IdBoard])
REFERENCES [dbo].[Board] ([IdBoard])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Column] CHECK CONSTRAINT [FK_Board_Column]
GO
ALTER TABLE [dbo].[Column]  WITH CHECK ADD  CONSTRAINT [FK_Color_Column] FOREIGN KEY([IdColor])
REFERENCES [dbo].[Color] ([IdColor])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Column] CHECK CONSTRAINT [FK_Color_Column]
GO
ALTER TABLE [dbo].[Objective]  WITH CHECK ADD  CONSTRAINT [FK_Objective_Column] FOREIGN KEY([IdColumn])
REFERENCES [dbo].[Column] ([IdColumn])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Objective] CHECK CONSTRAINT [FK_Objective_Column]
GO
ALTER TABLE [dbo].[Objective]  WITH CHECK ADD  CONSTRAINT [FK_Objective_Priority] FOREIGN KEY([IdPriority])
REFERENCES [dbo].[Priority] ([IdPriority])
GO
ALTER TABLE [dbo].[Objective] CHECK CONSTRAINT [FK_Objective_Priority]
GO
ALTER TABLE [dbo].[ObjectiveUser]  WITH CHECK ADD  CONSTRAINT [FK_ObjectiveUser_Objective] FOREIGN KEY([IdObjective])
REFERENCES [dbo].[Objective] ([IdObjective])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ObjectiveUser] CHECK CONSTRAINT [FK_ObjectiveUser_Objective]
GO
ALTER TABLE [dbo].[ObjectiveUser]  WITH CHECK ADD  CONSTRAINT [FK_ObjectiveUser_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ObjectiveUser] CHECK CONSTRAINT [FK_ObjectiveUser_User]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Agency] FOREIGN KEY([IdAgency])
REFERENCES [dbo].[Agency] ([IdAgency])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Agency]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([IdRole])
ON UPDATE CASCADE
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [ProjectManager] SET  READ_WRITE 
GO
