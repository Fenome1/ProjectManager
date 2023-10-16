USE [master]
GO
/****** Object:  Database [ProjectManager]    Script Date: 17.10.2023 1:54:04 ******/
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
/****** Object:  Table [dbo].[Agency]    Script Date: 17.10.2023 1:54:04 ******/
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
/****** Object:  Table [dbo].[Board]    Script Date: 17.10.2023 1:54:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Board](
	[IdBoard] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IdProject] [int] NOT NULL,
	[IdPriority] [int] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
 CONSTRAINT [PK_Board] PRIMARY KEY CLUSTERED 
(
	[IdBoard] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 17.10.2023 1:54:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[IdColor] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[HexCode] [nvarchar](6) NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[IdColor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Column]    Script Date: 17.10.2023 1:54:04 ******/
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
/****** Object:  Table [dbo].[Objective]    Script Date: 17.10.2023 1:54:04 ******/
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
/****** Object:  Table [dbo].[ObjectiveUser]    Script Date: 17.10.2023 1:54:04 ******/
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
/****** Object:  Table [dbo].[Priority]    Script Date: 17.10.2023 1:54:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Priority](
	[IdPrioriy] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Priority] PRIMARY KEY CLUSTERED 
(
	[IdPrioriy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 17.10.2023 1:54:04 ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 17.10.2023 1:54:04 ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 17.10.2023 1:54:04 ******/
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
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Agency]    Script Date: 17.10.2023 1:54:04 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Agency] ON [dbo].[Agency]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Board]    Script Date: 17.10.2023 1:54:04 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Board] ON [dbo].[Board]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Column]    Script Date: 17.10.2023 1:54:04 ******/
CREATE NONCLUSTERED INDEX [UQ_Column] ON [dbo].[Column]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Objective]    Script Date: 17.10.2023 1:54:04 ******/
CREATE NONCLUSTERED INDEX [UQ_Objective] ON [dbo].[Objective]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Objective_User]    Script Date: 17.10.2023 1:54:04 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Objective_User] ON [dbo].[ObjectiveUser]
(
	[IdObjective] ASC,
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Project]    Script Date: 17.10.2023 1:54:04 ******/
CREATE NONCLUSTERED INDEX [UQ_Project] ON [dbo].[Project]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Role]    Script Date: 17.10.2023 1:54:04 ******/
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
ALTER TABLE [dbo].[Board]  WITH CHECK ADD  CONSTRAINT [FK_Priority_Board] FOREIGN KEY([IdPriority])
REFERENCES [dbo].[Priority] ([IdPrioriy])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Board] CHECK CONSTRAINT [FK_Priority_Board]
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
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Column] CHECK CONSTRAINT [FK_Color_Column]
GO
ALTER TABLE [dbo].[Objective]  WITH CHECK ADD  CONSTRAINT [FK_Objective_Column] FOREIGN KEY([IdColumn])
REFERENCES [dbo].[Column] ([IdColumn])
GO
ALTER TABLE [dbo].[Objective] CHECK CONSTRAINT [FK_Objective_Column]
GO
ALTER TABLE [dbo].[Objective]  WITH CHECK ADD  CONSTRAINT [FK_Objective_Priority] FOREIGN KEY([IdPriority])
REFERENCES [dbo].[Priority] ([IdPrioriy])
ON UPDATE CASCADE
ON DELETE CASCADE
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
