USE [master]
GO
/****** Object:  Database [ProjectManager]    Script Date: 29.10.2023 19:53:31 ******/
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
/****** Object:  Table [dbo].[Agency]    Script Date: 29.10.2023 19:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agency](
	[IdAgency] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Agency] PRIMARY KEY CLUSTERED 
(
	[IdAgency] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Board]    Script Date: 29.10.2023 19:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Board](
	[IdBoard] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IdProject] [int] NOT NULL,
 CONSTRAINT [PK_Board] PRIMARY KEY CLUSTERED 
(
	[IdBoard] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 29.10.2023 19:53:31 ******/
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
/****** Object:  Table [dbo].[Column]    Script Date: 29.10.2023 19:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Column](
	[IdColumn] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IdBoard] [int] NOT NULL,
	[IdColor] [int] NOT NULL,
 CONSTRAINT [PK_Column] PRIMARY KEY CLUSTERED 
(
	[IdColumn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Objective]    Script Date: 29.10.2023 19:53:31 ******/
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
 CONSTRAINT [PK_Objective] PRIMARY KEY CLUSTERED 
(
	[IdObjective] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ObjectiveUser]    Script Date: 29.10.2023 19:53:31 ******/
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
/****** Object:  Table [dbo].[Priority]    Script Date: 29.10.2023 19:53:31 ******/
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
/****** Object:  Table [dbo].[Project]    Script Date: 29.10.2023 19:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[IdProject] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IdAgency] [int] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[IdProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 29.10.2023 19:53:31 ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 29.10.2023 19:53:31 ******/
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
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Agency] ON 

INSERT [dbo].[Agency] ([IdAgency], [Name], [Description]) VALUES (4017, N'Агентство 1', N'Какое-то агентство')
INSERT [dbo].[Agency] ([IdAgency], [Name], [Description]) VALUES (4055, N'Агентство тестов', N'Тут что-то тестируют')
SET IDENTITY_INSERT [dbo].[Agency] OFF
GO
SET IDENTITY_INSERT [dbo].[Board] ON 

INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject]) VALUES (2016, N'Создание верстки', 1013)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject]) VALUES (2017, N'Тестирование', 1013)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject]) VALUES (2018, N'Сдача проекта', 1013)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject]) VALUES (3058, N'Новая доска', 2054)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject]) VALUES (3059, N'Новая доска', 2055)
INSERT [dbo].[Board] ([IdBoard], [Name], [IdProject]) VALUES (3060, N'Новая доска', 2056)
SET IDENTITY_INSERT [dbo].[Board] OFF
GO
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([IdColor], [Name], [HexCode]) VALUES (1, N'Стандарт', N'#508D83DA')
INSERT [dbo].[Color] ([IdColor], [Name], [HexCode]) VALUES (3, N'Желтый', N'#50FEFF66')
INSERT [dbo].[Color] ([IdColor], [Name], [HexCode]) VALUES (4, N'Зеленый', N'#5069FF18')
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[Column] ON 

INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor]) VALUES (2007, N'Создание макета', 2016, 3)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor]) VALUES (2008, N'Верстка по макету', 2016, 3)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor]) VALUES (2009, N'Проверка все ли по макету', 2016, 4)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor]) VALUES (2010, N'Тестирование функций с бека', 2017, 1)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor]) VALUES (2011, N'Тесты корутин', 2017, 3)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor]) VALUES (2012, N'Автотесты', 2017, 4)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor]) VALUES (2013, N'Сдать этот странно большой проект как и курсовой проект', 2018, 3)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor]) VALUES (2015, N'Сдать этот странно большой проект как и курсовой проект вместе с тем еще', 2018, 4)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor]) VALUES (2041, N'Новая колонка', 3058, 1)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor]) VALUES (2042, N'Новая колонка', 3059, 1)
INSERT [dbo].[Column] ([IdColumn], [Name], [IdBoard], [IdColor]) VALUES (2043, N'Новая колонка', 3060, 1)
SET IDENTITY_INSERT [dbo].[Column] OFF
GO
SET IDENTITY_INSERT [dbo].[Objective] ON 

INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1003, N'Все дизайнер', NULL, 2007, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1004, N'Все дизайнер', NULL, 2007, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1005, N'Все дизайнер', NULL, 2007, 2, CAST(N'2024-03-12' AS Date), 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1011, N'Все дизайнер 1', NULL, 2007, NULL, NULL, 1)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1012, N'Все дизайнер 2', NULL, 2007, 2, CAST(N'2024-03-12' AS Date), 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1013, N'Все дизайнер 3', NULL, 2007, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1014, N'Все дизайнер 4', NULL, 2007, 3, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1106, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1107, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1108, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1109, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1110, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1111, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1112, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1113, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1114, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1115, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1116, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1117, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1118, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1119, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1120, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1121, N'Тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1122, N'Все дизайнер 5', NULL, 2007, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1123, N'Ураа', NULL, 2007, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1124, N'Реальное тестирование', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1125, N'уехало', NULL, 2008, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1126, N'Все ли норм?', NULL, 2009, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1128, N'Чисто ради теста', NULL, 2009, NULL, NULL, 0)
INSERT [dbo].[Objective] ([IdObjective], [Name], [Description], [IdColumn], [IdPriority], [Deadline], [Status]) VALUES (1129, N'Создание', NULL, 2010, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Objective] OFF
GO
SET IDENTITY_INSERT [dbo].[Priority] ON 

INSERT [dbo].[Priority] ([IdPriority], [Name], [HexCode]) VALUES (1, N'Не важно', N'#FFFFFF')
INSERT [dbo].[Priority] ([IdPriority], [Name], [HexCode]) VALUES (2, N'Нормально', N'#FFF943')
INSERT [dbo].[Priority] ([IdPriority], [Name], [HexCode]) VALUES (3, N'Важно', N'#FF4643')
SET IDENTITY_INSERT [dbo].[Priority] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency]) VALUES (1013, N'Фронт-энд', 4017)
INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency]) VALUES (2054, N'Тестирование', 4055)
INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency]) VALUES (2055, N'Отладка', 4055)
INSERT [dbo].[Project] ([IdProject], [Name], [IdAgency]) VALUES (2056, N'Исправление ошибок', 4055)
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

INSERT [dbo].[User] ([IdUser], [IdRole], [Login], [Password], [FullName]) VALUES (1, 2, N'Frontender', N'Password', N'Front Man')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Agency]    Script Date: 29.10.2023 19:53:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Agency] ON [dbo].[Agency]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Board]    Script Date: 29.10.2023 19:53:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Board] ON [dbo].[Board]
(
	[IdBoard] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Column]    Script Date: 29.10.2023 19:53:32 ******/
CREATE NONCLUSTERED INDEX [UQ_Column] ON [dbo].[Column]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Objective]    Script Date: 29.10.2023 19:53:32 ******/
CREATE NONCLUSTERED INDEX [UQ_Objective] ON [dbo].[Objective]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Objective_User]    Script Date: 29.10.2023 19:53:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Objective_User] ON [dbo].[ObjectiveUser]
(
	[IdObjective] ASC,
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Project]    Script Date: 29.10.2023 19:53:32 ******/
CREATE NONCLUSTERED INDEX [UQ_Project] ON [dbo].[Project]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Role]    Script Date: 29.10.2023 19:53:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Role] ON [dbo].[Role]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Column] ADD  CONSTRAINT [DF_Column_IdColor]  DEFAULT ((1)) FOR [IdColor]
GO
ALTER TABLE [dbo].[Objective] ADD  CONSTRAINT [DF_Task_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IdRole]  DEFAULT ((1)) FOR [IdRole]
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
