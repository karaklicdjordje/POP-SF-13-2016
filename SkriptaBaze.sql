USE [master]
GO
/****** Object:  Database [salonnamestaja]    Script Date: 1/9/2018 1:30:25 AM ******/
CREATE DATABASE [salonnamestaja]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'salonnamestaja', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.INSTANCA\MSSQL\DATA\salonnamestaja.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'salonnamestaja_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.INSTANCA\MSSQL\DATA\salonnamestaja_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [salonnamestaja] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [salonnamestaja].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [salonnamestaja] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [salonnamestaja] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [salonnamestaja] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [salonnamestaja] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [salonnamestaja] SET ARITHABORT OFF 
GO
ALTER DATABASE [salonnamestaja] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [salonnamestaja] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [salonnamestaja] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [salonnamestaja] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [salonnamestaja] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [salonnamestaja] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [salonnamestaja] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [salonnamestaja] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [salonnamestaja] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [salonnamestaja] SET  DISABLE_BROKER 
GO
ALTER DATABASE [salonnamestaja] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [salonnamestaja] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [salonnamestaja] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [salonnamestaja] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [salonnamestaja] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [salonnamestaja] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [salonnamestaja] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [salonnamestaja] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [salonnamestaja] SET  MULTI_USER 
GO
ALTER DATABASE [salonnamestaja] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [salonnamestaja] SET DB_CHAINING OFF 
GO
ALTER DATABASE [salonnamestaja] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [salonnamestaja] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [salonnamestaja] SET DELAYED_DURABILITY = DISABLED 
GO
USE [salonnamestaja]
GO
/****** Object:  Table [dbo].[AkcijskaProdaja]    Script Date: 1/9/2018 1:30:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AkcijskaProdaja](
	[id] [int] NOT NULL,
	[idNamestaja] [int] NOT NULL,
	[cenaPopust] [real] NULL,
	[datumPocetka] [datetime] NULL,
	[datumZavrsetka] [datetime] NULL,
	[obrisan] [bit] NULL,
 CONSTRAINT [PK_AkcijskaProdaja] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 1/9/2018 1:30:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[id] [int] NOT NULL,
	[ime] [nvarchar](50) NULL,
	[prezime] [nvarchar](50) NULL,
	[korisnickoIme] [nvarchar](50) NULL,
	[lozinka] [nvarchar](50) NULL,
	[tipKorisnika] [nvarchar](50) NULL,
	[obrisan] [bit] NULL,
 CONSTRAINT [PK_Korisnik] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Namestaj]    Script Date: 1/9/2018 1:30:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Namestaj](
	[id] [int] NOT NULL,
	[naziv] [nvarchar](50) NULL,
	[sifra] [nvarchar](50) NULL,
	[cena] [real] NULL,
	[kolicina] [int] NULL,
	[tipNamestaja] [nvarchar](50) NULL,
	[obrisan] [bit] NULL,
 CONSTRAINT [PK_Namestaj] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Prodaja]    Script Date: 1/9/2018 1:30:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prodaja](
	[id] [int] NOT NULL,
	[idNamestaja] [int] NOT NULL,
	[brKomada] [int] NULL,
	[datumProdaje] [datetime] NULL,
	[brojRacuna] [nvarchar](50) NULL,
	[imePrezimeKupca] [nvarchar](50) NULL,
	[prevoz] [bit] NULL,
	[montaza] [bit] NULL,
	[ukupnaCena] [real] NULL,
	[obrisan] [bit] NULL,
 CONSTRAINT [PK_Prodaja] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AkcijskaProdaja]  WITH CHECK ADD  CONSTRAINT [FK_AkcijskaProdaja_Namestaj] FOREIGN KEY([idNamestaja])
REFERENCES [dbo].[Namestaj] ([id])
GO
ALTER TABLE [dbo].[AkcijskaProdaja] CHECK CONSTRAINT [FK_AkcijskaProdaja_Namestaj]
GO
ALTER TABLE [dbo].[Prodaja]  WITH CHECK ADD  CONSTRAINT [FK_Prodaja_Namestaj] FOREIGN KEY([idNamestaja])
REFERENCES [dbo].[Namestaj] ([id])
GO
ALTER TABLE [dbo].[Prodaja] CHECK CONSTRAINT [FK_Prodaja_Namestaj]
GO
USE [master]
GO
ALTER DATABASE [salonnamestaja] SET  READ_WRITE 
GO
