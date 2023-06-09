USE [master]
GO
/****** Object:  Database [MyHotelDB]    Script Date: 5/31/2020 9:43:04 PM ******/
CREATE DATABASE [MyHotelDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyHotelDB', FILENAME = N'D:\GitHub\MyHotel\MyHotelDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MyHotelDB_log', FILENAME = N'D:\GitHub\MyHotel\MyHotelDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MyHotelDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyHotelDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyHotelDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyHotelDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyHotelDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyHotelDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyHotelDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyHotelDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyHotelDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyHotelDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyHotelDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyHotelDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyHotelDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyHotelDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyHotelDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyHotelDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyHotelDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyHotelDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyHotelDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyHotelDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyHotelDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyHotelDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyHotelDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyHotelDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyHotelDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MyHotelDB] SET  MULTI_USER 
GO
ALTER DATABASE [MyHotelDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyHotelDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyHotelDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyHotelDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MyHotelDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyHotelDB', N'ON'
GO
USE [MyHotelDB]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 5/31/2020 9:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoomTypeID] [int] NOT NULL,
	[CheckIn] [datetime] NOT NULL,
	[CheckOut] [datetime] NOT NULL,
	[CompletedDate] [datetime] NULL,
	[GuessName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[PhoneNo] [nvarchar](50) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/31/2020 9:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[FullName] [nvarchar](255) NOT NULL,
	[Roles] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Room]    Script Date: 5/31/2020 9:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[Number] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 5/31/2020 9:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Size] [int] NULL,
	[Exist] [int] NULL,
	[Capacity] [nvarchar](255) NULL,
	[Bed] [nvarchar](255) NULL,
	[Services] [nvarchar](255) NULL,
	[Image] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([ID], [RoomTypeID], [CheckIn], [CheckOut], [CompletedDate], [GuessName], [Email], [PhoneNo], [TotalPrice], [Status]) VALUES (2, 1, CAST(N'2020-05-26 00:00:00.000' AS DateTime), CAST(N'2020-05-28 00:00:00.000' AS DateTime), CAST(N'2020-05-28 00:00:00.000' AS DateTime), N'Nguyễn Văn An', N'nvan@gmail.com', N'0966773113', CAST(150.00 AS Decimal(18, 2)), 999)
INSERT [dbo].[Booking] ([ID], [RoomTypeID], [CheckIn], [CheckOut], [CompletedDate], [GuessName], [Email], [PhoneNo], [TotalPrice], [Status]) VALUES (3, 1, CAST(N'2020-05-29 00:00:00.000' AS DateTime), CAST(N'2020-05-31 00:00:00.000' AS DateTime), NULL, N'Đỗ Thanh Hải', N'dthai@gmail.com', N'0966771223', CAST(0.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Booking] ([ID], [RoomTypeID], [CheckIn], [CheckOut], [CompletedDate], [GuessName], [Email], [PhoneNo], [TotalPrice], [Status]) VALUES (4, 1, CAST(N'2020-05-25 00:00:00.000' AS DateTime), CAST(N'2020-05-27 00:00:00.000' AS DateTime), NULL, N'Đinh Mạnh Linh', N'dmlinh@gmail.com', N'01235556762', CAST(0.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Booking] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [Email], [Password], [FullName], [Roles]) VALUES (1, N'admin@gmail.com', N'12345678', N'Administrator', N'Home,Room,RoomType,Booking,Employee')
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([ID], [Type], [Number]) VALUES (1, 1, N'101')
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[RoomType] ON 

INSERT [dbo].[RoomType] ([ID], [Name], [Price], [Size],[Exist], [Capacity], [Bed], [Services], [Image], [Description]) VALUES (1, N'Double Room', CAST(159.00 AS Decimal(18, 2)), 30, 1, N'Max persion 2', N'King Beds', N'Wifi, Television, Bathroom,...', N'/Images/images/room-1.jpg', N'Motorhome or Trailer that is the question for you. Here are some of the advantages and disadvantages of both, so you will be confident when purchasing an RV. When comparing Rvs, a motorhome or a travel trailer, should you buy a motorhome or fifth wheeler? The advantages and disadvantages of both are studied so that you can make your choice wisely when purchasing an RV. Possessing a motorhome or fifth wheel is an achievement of a lifetime. It can be similar to sojourning with your residence as you search the various sites of our great land, America.

The two commonly known recreational vehicle classes are the motorized and towable. Towable rvs are the travel trailers and the fifth wheel. The rv travel trailer or fifth wheel has the attraction of getting towed by a pickup or a car, thus giving the adaptability of possessing transportation for you when you are parked at your campsite.')
SET IDENTITY_INSERT [dbo].[RoomType] OFF
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_RoomType] FOREIGN KEY([RoomTypeID])
REFERENCES [dbo].[RoomType] ([ID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_RoomType]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([Type])
REFERENCES [dbo].[RoomType] ([ID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_RoomType]
GO
USE [master]
GO
ALTER DATABASE [MyHotelDB] SET  READ_WRITE 
GO
