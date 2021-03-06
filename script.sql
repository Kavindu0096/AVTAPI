USE [master]
GO
/****** Object:  Database [AVT]    Script Date: 6/4/2021 9:04:28 PM ******/
CREATE DATABASE [AVT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AVT', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\AVT.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AVT_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\AVT_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AVT] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AVT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AVT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AVT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AVT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AVT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AVT] SET ARITHABORT OFF 
GO
ALTER DATABASE [AVT] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AVT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AVT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AVT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AVT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AVT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AVT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AVT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AVT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AVT] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AVT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AVT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AVT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AVT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AVT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AVT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AVT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AVT] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AVT] SET  MULTI_USER 
GO
ALTER DATABASE [AVT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AVT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AVT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AVT] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AVT] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AVT]
GO
/****** Object:  Table [dbo].[TBL_Aircraft]    Script Date: 6/4/2021 9:04:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Aircraft](
	[Aircraft_ID] [int] IDENTITY(1,1) NOT NULL,
	[Make] [nvarchar](128) NULL,
	[Model] [nvarchar](128) NULL,
	[Registration] [nvarchar](8) NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_TBL_Aircraft] PRIMARY KEY CLUSTERED 
(
	[Aircraft_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBL_Aircraft_Sighting]    Script Date: 6/4/2021 9:04:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Aircraft_Sighting](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Make] [nvarchar](128) NULL,
	[Model] [nvarchar](128) NULL,
	[Registration] [nvarchar](8) NULL,
	[Aircraft_ID] [int] NULL,
	[Location] [nvarchar](225) NULL,
	[SightingAt] [datetime] NULL,
	[UImage] [nvarchar](max) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_TBL_Aircraft_Sighting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBL_User]    Script Date: 6/4/2021 9:04:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_User](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_Code] [nchar](10) NULL,
	[User_Name] [nchar](20) NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_TBL_User] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[TBL_Aircraft] ON 

INSERT [dbo].[TBL_Aircraft] ([Aircraft_ID], [Make], [Model], [Registration], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [DeletedAt]) VALUES (1, N'Boeing', N'747', N'G-RNAC', 0, CAST(N'2021-06-04 15:21:43.733' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TBL_Aircraft] OFF
SET IDENTITY_INSERT [dbo].[TBL_Aircraft_Sighting] ON 

INSERT [dbo].[TBL_Aircraft_Sighting] ([ID], [Make], [Model], [Registration], [Aircraft_ID], [Location], [SightingAt], [UImage], [CreatedBy], [ModifiedBy], [ModifiedAt], [DeletedAt]) VALUES (1, N'Boeing', N'747', N'G-RNAC', 1, N'Colombo', CAST(N'2021-06-04 00:00:00.000' AS DateTime), N'Resources\b1afd691-ce0f-4da1-8e95-002ca70b41be_download.jfif', 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TBL_Aircraft_Sighting] OFF
ALTER TABLE [dbo].[TBL_Aircraft] ADD  CONSTRAINT [DF_TBL_Aircraft_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[TBL_Aircraft_Sighting] ADD  CONSTRAINT [DF_TBL_Aircraft_Sighting_SightingAt]  DEFAULT (getdate()) FOR [SightingAt]
GO
ALTER TABLE [dbo].[TBL_User] ADD  CONSTRAINT [DF_TBL_User_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
USE [master]
GO
ALTER DATABASE [AVT] SET  READ_WRITE 
GO
