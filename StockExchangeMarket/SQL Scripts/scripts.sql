USE [master]
GO

/****** Object:  Database [StockExchangeMarket]    Script Date: 16.04.2016 16:24:52 ******/
CREATE DATABASE [StockExchangeMarket]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StockExchangeMarket', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StockExchangeMarket.mdf' , SIZE = 102400KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StockExchangeMarket_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StockExchangeMarket_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [StockExchangeMarket] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StockExchangeMarket].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [StockExchangeMarket] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET ARITHABORT OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [StockExchangeMarket] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [StockExchangeMarket] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET  DISABLE_BROKER 
GO

ALTER DATABASE [StockExchangeMarket] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [StockExchangeMarket] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [StockExchangeMarket] SET  MULTI_USER 
GO

ALTER DATABASE [StockExchangeMarket] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [StockExchangeMarket] SET DB_CHAINING OFF 
GO

ALTER DATABASE [StockExchangeMarket] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [StockExchangeMarket] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [StockExchangeMarket] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [StockExchangeMarket] SET  READ_WRITE 
GO


USE [StockExchangeMarket]
GO

/****** Object:  Table [dbo].[tblLogs]    Script Date: 16.04.2016 16:25:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LogMessage] [varchar](max) NOT NULL,
	[Username] [varchar](max) NOT NULL,
	[LogDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [StockExchangeMarket]
GO

/****** Object:  Table [dbo].[tblStocks]    Script Date: 16.04.2016 16:25:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblStocks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[UserId] [varchar](32) NOT NULL,
	[AddDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [StockExchangeMarket]
GO

/****** Object:  Table [dbo].[tblUsers]    Script Date: 16.04.2016 16:25:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblUsers](
	[Id] [varchar](32) NOT NULL,
	[Username] [varchar](64) NULL,
	[Pass] [varchar](32) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [StockExchangeMarket]
GO

/****** Object:  StoredProcedure [dbo].[spGetStocksByUserId]    Script Date: 16.04.2016 16:26:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetStocksByUserId]
@argUserId AS VARCHAR(32)
AS
BEGIN
SELECT Code FROM tblStocks WHERE UserId = @argUserId
END 

GO


USE [StockExchangeMarket]
GO

/****** Object:  StoredProcedure [dbo].[spGetUserById]    Script Date: 16.04.2016 16:26:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetUserById]
@argId VARCHAR(32)
AS
BEGIN
SELECT Id, Username, Pass FROM tblUsers WHERE Id = @argId 
END

GO

USE [StockExchangeMarket]
GO

/****** Object:  StoredProcedure [dbo].[spGetUserByInfo]    Script Date: 16.04.2016 16:27:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spGetUserByInfo]
@argUsername VARCHAR(64), @argPassword VARCHAR(32)
AS
BEGIN
SELECT Id, Username, Pass FROM tblUsers WHERE Username =  @argUsername AND Pass = @argPassword 
END

GO


USE [StockExchangeMarket]
GO

/****** Object:  StoredProcedure [dbo].[spGetUserByUsername]    Script Date: 16.04.2016 16:27:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spGetUserByUsername]
@argUsername VARCHAR(64)
AS
BEGIN
SELECT Id, Username, Pass FROM tblUsers WHERE Username = @argUsername 
END

GO


USE [StockExchangeMarket]
GO

/****** Object:  StoredProcedure [dbo].[spRemoveUserStock]    Script Date: 16.04.2016 16:28:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRemoveUserStock]
@argUserId AS VARCHAR(32), @argCode AS VARCHAR(10)
AS
BEGIN
DELETE FROM tblStocks WHERE Code = @argCode AND UserId = @argUserId
END

GO

USE [StockExchangeMarket]
GO

/****** Object:  StoredProcedure [dbo].[spSaveLog]    Script Date: 16.04.2016 16:28:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spSaveLog]
@argLogMessage VARCHAR(MAX), 
@argUsername VARCHAR(64) NULL
AS
BEGIN
INSERT INTO tblLogs(LogMessage, Username, LogDate) 
VALUES(@argLogMessage, ISNULL(@argUsername, 'SystemUser'), GETDATE())
END

GO

USE [StockExchangeMarket]
GO

/****** Object:  StoredProcedure [dbo].[spSaveUser]    Script Date: 16.04.2016 16:28:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spSaveUser]
@argId VARCHAR(32), @argUsername VARCHAR (64),
@argPassword VARCHAR(32)
AS
BEGIN
INSERT INTO tblUsers (Id, Username, Pass)
VALUES(@argId,@argUsername,@argPassword)
END

GO


USE [StockExchangeMarket]
GO

/****** Object:  StoredProcedure [dbo].[spSaveUserStock]    Script Date: 16.04.2016 16:28:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spSaveUserStock]
@argUserId AS VARCHAR(32), @argCode AS VARCHAR(10)
AS
BEGIN
INSERT INTO tblStocks(Code,UserId,AddDate) VALUES(@argCode, @argUserId, GETDATE())
END

GO


USE [StockExchangeMarket]
GO

/****** Object:  StoredProcedure [dbo].[spSaveUserStock]    Script Date: 16.04.2016 16:28:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetStock]
@argUserId AS VARCHAR(32), @argCode AS VARCHAR(10)
AS
BEGIN
SELECT * FROM tblStocks WHERE Code = @argCode AND UserId = @argUserId
END

GO
