
/****** Object:  Database [konbini]    Script Date: 2/11/2023 7:27:34 PM ******/
CREATE DATABASE [konbini]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'konbini', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\konbini.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'konbini_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\konbini_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [konbini].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [konbini] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [konbini] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [konbini] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [konbini] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [konbini] SET ARITHABORT OFF 
GO

ALTER DATABASE [konbini] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [konbini] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [konbini] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [konbini] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [konbini] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [konbini] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [konbini] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [konbini] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [konbini] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [konbini] SET  DISABLE_BROKER 
GO

ALTER DATABASE [konbini] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [konbini] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [konbini] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [konbini] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [konbini] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [konbini] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [konbini] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [konbini] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [konbini] SET  MULTI_USER 
GO

ALTER DATABASE [konbini] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [konbini] SET DB_CHAINING OFF 
GO

ALTER DATABASE [konbini] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [konbini] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [konbini] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [konbini] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [konbini] SET QUERY_STORE = OFF
GO

ALTER DATABASE [konbini] SET  READ_WRITE 
GO

USE [konbini]
GO

/****** Object:  Table [dbo].[Fornecedor]    Script Date: 2/11/2023 7:29:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Fornecedor](
	[CNPJ] [numeric](14, 0) NOT NULL,
	[CodFornecedor] [varchar](1) NULL,
	[DescricaoFornecedor] [varchar](100) NULL,
 CONSTRAINT [PK_Fornecedor] PRIMARY KEY CLUSTERED 
(
	[CNPJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [konbini]
GO

/****** Object:  Table [dbo].[Produto]    Script Date: 2/11/2023 7:30:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Produto](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
	[Situacao] [bit] NOT NULL,
	[Fabricacao] [date] NULL,
	[Validade] [date] NULL,
	[Fornecedor] [numeric](14, 0) NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [Fk_Fornecedor] FOREIGN KEY([Fornecedor])
REFERENCES [dbo].[Fornecedor] ([CNPJ])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [Fk_Fornecedor]
GO

