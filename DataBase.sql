USE [master]
GO
/****** Object:  Database [ShoppingCart]    Script Date: 7/14/2024 2:38:39 AM ******/
CREATE DATABASE [ShoppingCart]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShoppingCart', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShoppingCart.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShoppingCart_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShoppingCart_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ShoppingCart] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShoppingCart].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShoppingCart] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShoppingCart] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShoppingCart] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShoppingCart] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShoppingCart] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShoppingCart] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShoppingCart] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShoppingCart] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShoppingCart] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShoppingCart] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShoppingCart] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShoppingCart] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShoppingCart] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShoppingCart] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShoppingCart] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShoppingCart] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShoppingCart] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShoppingCart] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShoppingCart] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShoppingCart] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShoppingCart] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ShoppingCart] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShoppingCart] SET RECOVERY FULL 
GO
ALTER DATABASE [ShoppingCart] SET  MULTI_USER 
GO
ALTER DATABASE [ShoppingCart] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShoppingCart] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShoppingCart] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShoppingCart] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShoppingCart] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShoppingCart] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShoppingCart', N'ON'
GO
ALTER DATABASE [ShoppingCart] SET QUERY_STORE = ON
GO
ALTER DATABASE [ShoppingCart] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ShoppingCart]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/14/2024 2:38:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 7/14/2024 2:38:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CatName] [nvarchar](50) NOT NULL,
	[slug] [nvarchar](30) NOT NULL,
	[Availability] [bit] NOT NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loginRegister]    Script Date: 7/14/2024 2:38:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loginRegister](
	[LoginRegisterId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](25) NOT NULL,
	[PasswordConfirmed] [nvarchar](25) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_loginRegister] PRIMARY KEY CLUSTERED 
(
	[LoginRegisterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 7/14/2024 2:38:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Pname] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
	[Subject] [nvarchar](100) NOT NULL,
	[Brand] [nvarchar](50) NOT NULL,
	[Pimage] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Slug] [nvarchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_products_CategoryId]    Script Date: 7/14/2024 2:38:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_products_CategoryId] ON [dbo].[products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [FK_products_categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [FK_products_categories_CategoryId]
GO
USE [master]
GO
ALTER DATABASE [ShoppingCart] SET  READ_WRITE 
GO
