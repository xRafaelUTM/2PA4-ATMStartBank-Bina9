USE [clientesBank]
GO
/****** Object:  Table [dbo].[clientesCuenta]    Script Date: 29/02/2024 02:34:12 p. m. ******/
DROP TABLE [dbo].[clientesCuenta]
GO
/****** Object:  Table [dbo].[atmEfectivo]    Script Date: 29/02/2024 02:34:12 p. m. ******/
DROP TABLE [dbo].[atmEfectivo]
GO
USE [master]
GO
/****** Object:  Database [clientesBank]    Script Date: 29/02/2024 02:34:12 p. m. ******/
DROP DATABASE [clientesBank]
GO
/****** Object:  Database [clientesBank]    Script Date: 29/02/2024 02:34:12 p. m. ******/
CREATE DATABASE [clientesBank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'clientesBank', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\clientesBank.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'clientesBank_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\clientesBank_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [clientesBank] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [clientesBank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [clientesBank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [clientesBank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [clientesBank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [clientesBank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [clientesBank] SET ARITHABORT OFF 
GO
ALTER DATABASE [clientesBank] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [clientesBank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [clientesBank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [clientesBank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [clientesBank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [clientesBank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [clientesBank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [clientesBank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [clientesBank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [clientesBank] SET  DISABLE_BROKER 
GO
ALTER DATABASE [clientesBank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [clientesBank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [clientesBank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [clientesBank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [clientesBank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [clientesBank] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [clientesBank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [clientesBank] SET RECOVERY FULL 
GO
ALTER DATABASE [clientesBank] SET  MULTI_USER 
GO
ALTER DATABASE [clientesBank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [clientesBank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [clientesBank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [clientesBank] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [clientesBank] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'clientesBank', N'ON'
GO
ALTER DATABASE [clientesBank] SET QUERY_STORE = OFF
GO
USE [clientesBank]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [clientesBank]
GO
/****** Object:  Table [dbo].[atmEfectivo]    Script Date: 29/02/2024 02:34:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[atmEfectivo](
	[efectivoDisponible] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientesCuenta]    Script Date: 29/02/2024 02:34:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientesCuenta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidoPaterno] [varchar](50) NULL,
	[apellidoMaterno] [varchar](50) NULL,
	[tarjetaDebito] [decimal](16, 0) NOT NULL,
	[tarjetaCredito] [decimal](16, 0) NOT NULL,
	[pinTarjeta] [int] NOT NULL,
	[saldoTarjetaDebito] [decimal](18, 2) NULL,
	[saldoTarjetaCredito] [decimal](18, 2) NULL,
	[pagoHipotecario] [decimal](18, 2) NULL,
	[pagoCarro] [decimal](18, 2) NULL,
	[pagoCFE] [decimal](18, 2) NULL,
	[pagoTelmex] [decimal](18, 2) NULL,
	[pagoJapay] [decimal](18, 2) NULL,
	[pagoTelcel] [decimal](18, 2) NULL,
	[pagoTotalPlay] [decimal](18, 2) NULL,
	[pagoColegiatura] [decimal](18, 2) NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[atmEfectivo] ([efectivoDisponible]) VALUES (CAST(300000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[clientesCuenta] ON 

INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (1, N'Mario Rafael', N'Solis', N'Suarez', CAST(5786709677231470 AS Decimal(16, 0)), CAST(5662044162468873 AS Decimal(16, 0)), 1206, CAST(17570.09 AS Decimal(18, 2)), CAST(3782.42 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), CAST(7000.00 AS Decimal(18, 2)), CAST(350.00 AS Decimal(18, 2)), CAST(520.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), CAST(350.00 AS Decimal(18, 2)), CAST(750.00 AS Decimal(18, 2)), CAST(3700.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (2, N'KEVIN ENMANUEL', N'PADILLA', N'VALDEZ', CAST(5752012256582762 AS Decimal(16, 0)), CAST(5708988521981451 AS Decimal(16, 0)), 3185, CAST(13185.19 AS Decimal(18, 2)), CAST(2450.92 AS Decimal(18, 2)), CAST(4000.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), CAST(199.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)), CAST(800.00 AS Decimal(18, 2)), CAST(1200.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (3, N'SAIDY ASURY', N'RODRIGUEZ', N'OSORIO', CAST(5722171528569223 AS Decimal(16, 0)), CAST(5852996984757313 AS Decimal(16, 0)), 8505, CAST(9842.59 AS Decimal(18, 2)), CAST(2282.57 AS Decimal(18, 2)), CAST(9000.00 AS Decimal(18, 2)), CAST(4000.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), CAST(350.00 AS Decimal(18, 2)), CAST(950.00 AS Decimal(18, 2)), CAST(3700.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (4, N'HECTOR ENRIQUE', N'MENDOZA', N'NAVA', CAST(5585534185761346 AS Decimal(16, 0)), CAST(5522937451145280 AS Decimal(16, 0)), 1141, CAST(29572.99 AS Decimal(18, 2)), CAST(1182.42 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)), CAST(950.00 AS Decimal(18, 2)), CAST(220.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), CAST(1454.00 AS Decimal(18, 2)), CAST(3700.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (5, N'RODRIGO DE LA CRUZ', N'GONZALEZ', N'MONTERO', CAST(5572136128787799 AS Decimal(16, 0)), CAST(5985386257013773 AS Decimal(16, 0)), 4486, CAST(1122.89 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(3700.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (6, N'ALEJANDRO', N'MAGANA', N'LOPEZ', CAST(5716747958312739 AS Decimal(16, 0)), CAST(5772083936392807 AS Decimal(16, 0)), 4158, CAST(11091.89 AS Decimal(18, 2)), CAST(3782.42 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), CAST(7000.00 AS Decimal(18, 2)), CAST(350.00 AS Decimal(18, 2)), CAST(520.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), CAST(453.00 AS Decimal(18, 2)), CAST(124.00 AS Decimal(18, 2)), CAST(3700.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (7, N'JOSE ARIEL', N'MARTINEZ', N'LLANES', CAST(5912219448252724 AS Decimal(16, 0)), CAST(5963524266212978 AS Decimal(16, 0)), 6495, CAST(28000.00 AS Decimal(18, 2)), CAST(1882.42 AS Decimal(18, 2)), CAST(812.00 AS Decimal(18, 2)), CAST(4000.00 AS Decimal(18, 2)), CAST(455.00 AS Decimal(18, 2)), CAST(520.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), CAST(1235.00 AS Decimal(18, 2)), CAST(550.00 AS Decimal(18, 2)), CAST(3700.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (8, N'BRANDON ISAI', N'JIMENEZ', N'HAU', CAST(5871410557766564 AS Decimal(16, 0)), CAST(5805541990302946 AS Decimal(16, 0)), 1684, CAST(48115.56 AS Decimal(18, 2)), CAST(4565.42 AS Decimal(18, 2)), CAST(1505.00 AS Decimal(18, 2)), CAST(3000.00 AS Decimal(18, 2)), CAST(455.00 AS Decimal(18, 2)), CAST(520.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(680.00 AS Decimal(18, 2)), CAST(3700.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (9, N'ALEXIS YHAIR', N'GUEMEZ', N'MONTALVO', CAST(5923175728438364 AS Decimal(16, 0)), CAST(5973538923459994 AS Decimal(16, 0)), 9638, CAST(15115.59 AS Decimal(18, 2)), CAST(4645.42 AS Decimal(18, 2)), CAST(5744.00 AS Decimal(18, 2)), CAST(687.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(520.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), CAST(350.00 AS Decimal(18, 2)), CAST(453.00 AS Decimal(18, 2)), CAST(3700.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (10, N'JOSE ANTONIO DE JESUS', N'POOL', N'KU', CAST(5786708914231470 AS Decimal(16, 0)), CAST(5651646172792955 AS Decimal(16, 0)), 2936, CAST(8984.01 AS Decimal(18, 2)), CAST(2282.57 AS Decimal(18, 2)), CAST(4532.00 AS Decimal(18, 2)), CAST(4500.00 AS Decimal(18, 2)), CAST(155.00 AS Decimal(18, 2)), CAST(520.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(950.00 AS Decimal(18, 2)), CAST(3700.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (11, N'ALEXIS ALEXANDER', N'BOLIO', N'CHAN', CAST(5786709677231470 AS Decimal(16, 0)), CAST(5651646131852955 AS Decimal(16, 0)), 2132, CAST(44615.56 AS Decimal(18, 2)), CAST(7545.42 AS Decimal(18, 2)), CAST(4532.00 AS Decimal(18, 2)), CAST(4500.00 AS Decimal(18, 2)), CAST(155.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), CAST(350.00 AS Decimal(18, 2)), CAST(1454.00 AS Decimal(18, 2)), CAST(1200.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (12, N'JOSE ARTURO', N'CABRERA', N'ARCOS', CAST(5786709254919470 AS Decimal(16, 0)), CAST(5651346172792999 AS Decimal(16, 0)), 3210, CAST(11191.89 AS Decimal(18, 2)), CAST(2450.92 AS Decimal(18, 2)), CAST(9000.00 AS Decimal(18, 2)), CAST(3000.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), CAST(452.00 AS Decimal(18, 2)), CAST(1454.00 AS Decimal(18, 2)), CAST(3700.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (13, N'EDSON DANIEL', N'CHAVEZ', N'MERITO', CAST(5786709712218505 AS Decimal(16, 0)), CAST(5651346172911979 AS Decimal(16, 0)), 4853, CAST(4844.01 AS Decimal(18, 2)), CAST(7545.99 AS Decimal(18, 2)), CAST(3532.00 AS Decimal(18, 2)), CAST(4500.00 AS Decimal(18, 2)), CAST(199.00 AS Decimal(18, 2)), CAST(220.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), CAST(350.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), CAST(3700.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (14, N'JOSUE ISMAEL', N'SANCHEZ', N'PUC', CAST(5786709212231470 AS Decimal(16, 0)), CAST(5651346192792955 AS Decimal(16, 0)), 2836, CAST(48115.56 AS Decimal(18, 2)), CAST(2450.92 AS Decimal(18, 2)), CAST(5532.00 AS Decimal(18, 2)), CAST(2500.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(452.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), CAST(1200.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (15, N'CRISTIAN ISAAC', N'LLANES', N'PUC', CAST(5786709629361499 AS Decimal(16, 0)), CAST(5651346172992056 AS Decimal(16, 0)), 2930, CAST(10542.59 AS Decimal(18, 2)), CAST(2282.57 AS Decimal(18, 2)), CAST(812.00 AS Decimal(18, 2)), CAST(4500.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(520.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), CAST(452.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), CAST(3700.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (16, N'MIGUEL ANGEL', N'CANTO', N'POOT', CAST(5786709677231471 AS Decimal(16, 0)), CAST(5651346293692966 AS Decimal(16, 0)), 3425, CAST(11091.89 AS Decimal(18, 2)), CAST(7545.42 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)), CAST(5200.00 AS Decimal(18, 2)), CAST(199.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(950.00 AS Decimal(18, 2)), CAST(1200.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (17, N'MARICARMEN', N'ESCALANTE', N'AGUILAR', CAST(5786709677231271 AS Decimal(16, 0)), CAST(5651346971192932 AS Decimal(16, 0)), 2948, CAST(8000.01 AS Decimal(18, 2)), CAST(2450.92 AS Decimal(18, 2)), CAST(812.00 AS Decimal(18, 2)), CAST(6000.00 AS Decimal(18, 2)), CAST(155.00 AS Decimal(18, 2)), CAST(220.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(350.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), CAST(3700.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (18, N'LUIS GERARDO', N'DIAZ', N'PARDENILLA', CAST(5786709549131672 AS Decimal(16, 0)), CAST(5651346172792983 AS Decimal(16, 0)), 2958, CAST(8884.01 AS Decimal(18, 2)), CAST(7595.42 AS Decimal(18, 2)), CAST(5532.00 AS Decimal(18, 2)), CAST(7500.00 AS Decimal(18, 2)), CAST(199.00 AS Decimal(18, 2)), CAST(520.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(452.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), CAST(3700.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (19, N'RAUL ALEJANDRO', N'DONDE', N'PEREZ', CAST(5786709677231573 AS Decimal(16, 0)), CAST(5651346172792967 AS Decimal(16, 0)), 3210, CAST(13491.89 AS Decimal(18, 2)), CAST(7545.42 AS Decimal(18, 2)), CAST(812.00 AS Decimal(18, 2)), CAST(3000.00 AS Decimal(18, 2)), CAST(155.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(950.00 AS Decimal(18, 2)), CAST(1200.00 AS Decimal(18, 2)))
INSERT [dbo].[clientesCuenta] ([id], [nombres], [apellidoPaterno], [apellidoMaterno], [tarjetaDebito], [tarjetaCredito], [pinTarjeta], [saldoTarjetaDebito], [saldoTarjetaCredito], [pagoHipotecario], [pagoCarro], [pagoCFE], [pagoTelmex], [pagoJapay], [pagoTelcel], [pagoTotalPlay], [pagoColegiatura]) VALUES (20, N'JORGE ABRAHAAM', N'CRUZ', N'PECH', CAST(5786709596831454 AS Decimal(16, 0)), CAST(5651346172792954 AS Decimal(16, 0)), 2978, CAST(9842.59 AS Decimal(18, 2)), CAST(1182.42 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)), CAST(5200.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(520.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), CAST(452.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), CAST(3700.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[clientesCuenta] OFF
USE [master]
GO
ALTER DATABASE [clientesBank] SET  READ_WRITE 
GO
