USE [master]
GO

/****** Object:  Database [SIS]    Script Date: 22.10.2021 12:41:44 ******/
CREATE DATABASE [SIS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SIS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SIS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'SIS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SIS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SIS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [SIS] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [SIS] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [SIS] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [SIS] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [SIS] SET ARITHABORT OFF 
GO

ALTER DATABASE [SIS] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [SIS] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [SIS] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [SIS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [SIS] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [SIS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [SIS] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [SIS] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [SIS] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [SIS] SET  DISABLE_BROKER 
GO

ALTER DATABASE [SIS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [SIS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [SIS] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [SIS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [SIS] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [SIS] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [SIS] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [SIS] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [SIS] SET  MULTI_USER 
GO

ALTER DATABASE [SIS] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [SIS] SET DB_CHAINING OFF 
GO

ALTER DATABASE [SIS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [SIS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [SIS] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [SIS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [SIS] SET QUERY_STORE = OFF
GO

ALTER DATABASE [SIS] SET  READ_WRITE 
GO
