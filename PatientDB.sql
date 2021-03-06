USE [master]
GO
/****** Object:  Database [PatientDb]    Script Date: 18/08/2020 23:26:40 ******/
CREATE DATABASE [PatientDb]
GO
ALTER DATABASE [PatientDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PatientDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PatientDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PatientDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PatientDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PatientDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PatientDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [PatientDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PatientDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PatientDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PatientDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PatientDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PatientDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PatientDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PatientDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PatientDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PatientDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PatientDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PatientDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PatientDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PatientDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PatientDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PatientDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PatientDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PatientDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PatientDb] SET  MULTI_USER 
GO
ALTER DATABASE [PatientDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PatientDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PatientDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PatientDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PatientDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PatientDb] SET QUERY_STORE = OFF
GO
USE [PatientDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [PatientDb]
GO
/****** Object:  Table [dbo].[PatientTbl]    Script Date: 18/08/2020 23:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientTbl](
	[PatientID] [int] IDENTITY(1,1) NOT NULL,
	[Patient] [nvarchar](50) NULL,
	[MRN] [bigint] NULL,
	[CSN] [bigint] NULL,
	[Gender] [nchar](10) NULL,
	[HomePhone] [nvarchar](30) NULL,
	[SSN] [nvarchar](30) NULL,
	[PassportNo] [nvarchar](30) NULL,
	[LocationCode] [char](10) NULL,
	[LocationID] [bigint] NULL,
	[DOB] [nvarchar](20) NULL,
	[UpdateDateTime] [nvarchar](20) NULL,
 CONSTRAINT [PK_PatientTbl] PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceConfiguration]    Script Date: 18/08/2020 23:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceConfiguration](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FolderLocation] [nvarchar](500) NULL,
	[Timer] [int] NULL,
	[DatabaseName] [nvarchar](50) NULL,
	[LogsFilePath] [nvarchar](500) NULL,
 CONSTRAINT [PK_ServiceConfiguration] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PatientTbl] ON 

INSERT [dbo].[PatientTbl] ([PatientID], [Patient], [MRN], [CSN], [Gender], [HomePhone], [SSN], [PassportNo], [LocationCode], [LocationID], [DOB], [UpdateDateTime]) VALUES (1, N'TEST,SHAIKHA ALI', 1188445, 50814518, N'F         ', N'04 348 1988', N'784-2000-1111111-0', N'B638222', N'BRHC      ', 3620756, N'19930524', N'20200627034100')
INSERT [dbo].[PatientTbl] ([PatientID], [Patient], [MRN], [CSN], [Gender], [HomePhone], [SSN], [PassportNo], [LocationCode], [LocationID], [DOB], [UpdateDateTime]) VALUES (2, N'MY TEST, PATIENT', 920000311, 50814518, N'M         ', N'04 111 2221', N'784-1993-222222-0', N'P382312', N'RH        ', 3828332, N'19760101', N'20200526034100')
SET IDENTITY_INSERT [dbo].[PatientTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceConfiguration] ON 

INSERT [dbo].[ServiceConfiguration] ([ID], [FolderLocation], [Timer], [DatabaseName], [LogsFilePath]) VALUES (1, N'C:\BatchFiles\batch_Patient_12082020.txt', 5000, N'PatientDb', N'c:\Logs')
SET IDENTITY_INSERT [dbo].[ServiceConfiguration] OFF
GO
USE [master]
GO
ALTER DATABASE [PatientDb] SET  READ_WRITE 
GO
