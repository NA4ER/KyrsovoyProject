USE [master]
GO
/****** Object:  Database [CarShop]    Script Date: 29.04.2024 17:50:12 ******/
CREATE DATABASE [CarShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarShop', FILENAME = N'D:\SQL\MSSQL15.SQLEXPRESS\MSSQL\DATA\CarShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarShop_log', FILENAME = N'D:\SQL\MSSQL15.SQLEXPRESS\MSSQL\DATA\CarShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CarShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarShop] SET  MULTI_USER 
GO
ALTER DATABASE [CarShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CarShop] SET QUERY_STORE = OFF
GO
USE [CarShop]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 29.04.2024 17:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[CarID] [int] NOT NULL,
	[Year] [nvarchar](4) NOT NULL,
	[Brand] [nvarchar](10) NOT NULL,
	[Model] [nvarchar](10) NOT NULL,
	[Price] [money] NOT NULL,
	[Description] [nvarchar](100) NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[CarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 29.04.2024 17:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
	[MiddleName] [nvarchar](15) NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 29.04.2024 17:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] NOT NULL,
	[LastName] [nvarchar](20) NULL,
	[Name] [nvarchar](10) NOT NULL,
	[MiddleName] [nvarchar](15) NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Position] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 29.04.2024 17:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[CarID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 29.04.2024 17:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[SalesID] [int] NOT NULL,
	[CarID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[DateOfSale] [datetime] NOT NULL,
	[SalesAmount] [money] NOT NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[SalesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Car] ([CarID], [Year], [Brand], [Model], [Price], [Description], [Image]) VALUES (1, N'2006', N'Ford', N'Focus 2', 350000.0000, NULL, NULL)
INSERT [dbo].[Car] ([CarID], [Year], [Brand], [Model], [Price], [Description], [Image]) VALUES (2, N'2018', N'Renault', N'Duster', 1415000.0000, NULL, NULL)
INSERT [dbo].[Car] ([CarID], [Year], [Brand], [Model], [Price], [Description], [Image]) VALUES (3, N'2009', N'Toyota', N'Camry 2.4', 850000.0000, NULL, NULL)
INSERT [dbo].[Car] ([CarID], [Year], [Brand], [Model], [Price], [Description], [Image]) VALUES (4, N'2017', N'Kia', N'Rio', 1170000.0000, NULL, NULL)
GO
INSERT [dbo].[Client] ([ClientID], [LastName], [Name], [MiddleName], [Phone]) VALUES (1, N'Вертел ', N'Андрей', N'Владимирович', N'89121376745')
INSERT [dbo].[Client] ([ClientID], [LastName], [Name], [MiddleName], [Phone]) VALUES (2, N'Горелый', N'Федор', N'Витальевич', N'86661456785')
INSERT [dbo].[Client] ([ClientID], [LastName], [Name], [MiddleName], [Phone]) VALUES (3, N'Уголек', N'Павел', N'Александрович', N'89884356715')
INSERT [dbo].[Client] ([ClientID], [LastName], [Name], [MiddleName], [Phone]) VALUES (4, N'Пшык', N'Егор', N'Денисович', N'87658389566')
GO
INSERT [dbo].[Employee] ([EmployeeID], [LastName], [Name], [MiddleName], [Phone], [Position]) VALUES (1, N'Раб', N'Артем', N'Николаевич', N'89234512345', N'Менеджер')
INSERT [dbo].[Employee] ([EmployeeID], [LastName], [Name], [MiddleName], [Phone], [Position]) VALUES (2, N'Конь', N'Федор', N'Станиславович', N'89451286901', N'Менеджер')
GO
INSERT [dbo].[Orders] ([OrderID], [ClientID], [CarID], [Date]) VALUES (1, 2, 3, CAST(N'2024-02-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderID], [ClientID], [CarID], [Date]) VALUES (2, 1, 4, CAST(N'2023-09-20T00:00:00.000' AS DateTime))
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Car] FOREIGN KEY([CarID])
REFERENCES [dbo].[Car] ([CarID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Car]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Client]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Car] FOREIGN KEY([CarID])
REFERENCES [dbo].[Car] ([CarID])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Car]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Client]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Employee]
GO
USE [master]
GO
ALTER DATABASE [CarShop] SET  READ_WRITE 
GO
