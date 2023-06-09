USE [master]
GO

/****** Object:  Database [ContactsDB]    Script Date: 23.05.2023 18:38:19 ******/
CREATE DATABASE [ContactsDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ContactsDB_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ContactsDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ContactsDB_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ContactsDB.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContactsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ContactsDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ContactsDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ContactsDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ContactsDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ContactsDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [ContactsDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ContactsDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ContactsDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ContactsDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ContactsDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ContactsDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ContactsDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ContactsDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ContactsDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ContactsDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ContactsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ContactsDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ContactsDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ContactsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ContactsDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ContactsDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ContactsDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ContactsDB] SET RECOVERY FULL 
GO

ALTER DATABASE [ContactsDB] SET  MULTI_USER 
GO

ALTER DATABASE [ContactsDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ContactsDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ContactsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ContactsDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [ContactsDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [ContactsDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [ContactsDB] SET QUERY_STORE = ON
GO

ALTER DATABASE [ContactsDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [ContactsDB] SET  READ_WRITE 
GO
