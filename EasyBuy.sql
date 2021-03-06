USE [master]
GO
/****** Object:  Database [EasyBuy]    Script Date: 12/29/2017 4:04:43 下午 ******/
CREATE DATABASE [EasyBuy] ON  PRIMARY 
( NAME = N'EasyBuy', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.S7OVSDB04\MSSQL\DATA\EasyBuy.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EasyBuy_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.S7OVSDB04\MSSQL\DATA\EasyBuy_log.ldf' , SIZE = 2816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EasyBuy] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EasyBuy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EasyBuy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EasyBuy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EasyBuy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EasyBuy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EasyBuy] SET ARITHABORT OFF 
GO
ALTER DATABASE [EasyBuy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EasyBuy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EasyBuy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EasyBuy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EasyBuy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EasyBuy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EasyBuy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EasyBuy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EasyBuy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EasyBuy] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EasyBuy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EasyBuy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EasyBuy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EasyBuy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EasyBuy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EasyBuy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EasyBuy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EasyBuy] SET RECOVERY FULL 
GO
ALTER DATABASE [EasyBuy] SET  MULTI_USER 
GO
ALTER DATABASE [EasyBuy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EasyBuy] SET DB_CHAINING OFF 
GO
USE [EasyBuy]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 12/29/2017 4:04:44 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Activity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Link] [nvarchar](100) NOT NULL,
	[ImageUrl] [nvarchar](100) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[ExpireTime] [datetime] NOT NULL,
	[BriefDescription] [nvarchar](50) NOT NULL,
	[InUser] [varchar](200) NOT NULL,
	[InDate] [datetime] NOT NULL,
	[LastEditUser] [varchar](200) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Activity] UNIQUE NONCLUSTERED 
(
	[ImageUrl] ASC,
	[Link] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Attribute]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Attribute](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AttributeID] [varchar](20) NOT NULL,
	[AttributeName] [nvarchar](20) NOT NULL,
	[AttributeDescription] [nvarchar](50) NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](200) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
	[LastEditUser] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Attribute] UNIQUE NONCLUSTERED 
(
	[AttributeID] ASC,
	[AttributeDescription] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [varchar](20) NOT NULL,
	[CategoryName] [nvarchar](30) NOT NULL,
	[CategoryDescription] [nvarchar](500) NOT NULL,
	[ParentCategoryID] [varchar](20) NOT NULL,
	[Priority] [int] NOT NULL,
	[Enable] [bit] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](200) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
	[LastEditUser] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Category] UNIQUE NONCLUSTERED 
(
	[CategoryID] ASC,
	[CategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Module]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Module](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [int] NOT NULL,
	[ModuleName] [nvarchar](20) NOT NULL,
	[ModuleDescription] [nvarchar](200) NOT NULL,
	[Priority] [int] NOT NULL,
	[Enable] [bit] NOT NULL,
	[InUser] [varchar](200) NOT NULL,
	[InDate] [datetime] NOT NULL,
	[LastEditUser] [varchar](200) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Module] UNIQUE NONCLUSTERED 
(
	[ModuleID] ASC,
	[ModuleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [varchar](20) NOT NULL,
	[OrderState] [int] NOT NULL,
	[CostomerID] [varchar](200) NOT NULL,
	[OrderTotal] [int] NOT NULL,
	[Discount] [int] NOT NULL,
	[PayCostomerID] [varchar](200) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[InUser] [varchar](200) NOT NULL,
	[InDate] [datetime] NOT NULL,
	[LastEditUser] [varchar](200) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Order] UNIQUE NONCLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [varchar](20) NOT NULL,
	[ProductID] [varchar](20) NOT NULL,
	[PayState] [int] NOT NULL,
	[AddressID] [int] NOT NULL,
	[PostID] [varchar](50) NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](200) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
	[LastEditUser] [varchar](200) NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PostHistory]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PostHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PostID] [varchar](50) NOT NULL,
	[PostName] [nvarchar](50) NOT NULL,
	[PostCost] [int] NOT NULL,
	[PostDescription] [nvarchar](500) NOT NULL,
	[PostSpeed] [int] NOT NULL,
	[PostStart] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](200) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
	[LastEditUser] [varchar](200) NOT NULL,
 CONSTRAINT [PK_PostHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_PostHistory] UNIQUE NONCLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [varchar](20) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ImageUrl] [nvarchar](100) NOT NULL,
	[ImageName] [nvarchar](max) NOT NULL,
	[ImagePosition] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[ItemType] [int] NOT NULL,
	[CategoryID] [varchar](20) NOT NULL,
	[IsPublish] [bit] NOT NULL,
	[HomePriority] [int] NOT NULL,
	[ProductPriority] [int] NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[DetailDescription] [nvarchar](max) NOT NULL,
	[OriginalPrice] [int] NOT NULL,
	[Discount] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](200) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
	[LastEditUser] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Product] UNIQUE NONCLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductAttribute]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductAttribute](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AttributeID] [varchar](20) NOT NULL,
	[ProductID] [varchar](20) NOT NULL,
	[AttributeValue] [nvarchar](500) NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](200) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
	[LastEditUser] [varchar](200) NOT NULL,
 CONSTRAINT [PK_ProductAttribute] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Review]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Review](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReviewID] [varchar](20) NOT NULL,
	[ProductOROrderID] [varchar](20) NOT NULL,
	[UserID] [varchar](200) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[CheckPassed] [bit] NOT NULL,
	[Score] [int] NOT NULL,
	[Images] [varchar](500) NULL,
	[Videos] [varchar](500) NULL,
	[FavourCount] [int] NOT NULL,
	[OpposeCount] [int] NOT NULL,
	[VoteUsers] [varchar](max) NULL,
	[ReviewDate] [datetime] NOT NULL,
	[EBReplay] [nvarchar](max) NULL,
	[VendorReplay] [nvarchar](max) NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](200) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
	[LastEditUser] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Review] UNIQUE NONCLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShoppingCart]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ShoppingCart](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AttributeID] [varchar](20) NOT NULL,
	[ProductID] [varchar](20) NOT NULL,
	[AttributeValue] [nvarchar](500) NOT NULL,
	[UserID] [varchar](200) NOT NULL,
	[ProductCount] [int] NOT NULL,
	[SellerID] [varchar](200) NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](200) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
	[LastEditUser] [varchar](200) NOT NULL,
 CONSTRAINT [PK_ShoppingCart] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestTable]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestTable](
	[ID] [int] NOT NULL,
	[Bullertdes] [varchar](max) NOT NULL,
 CONSTRAINT [PK_TestTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TransactionHistory]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TransactionHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionNumber] [varchar](20) NOT NULL,
	[FromUser] [varchar](200) NOT NULL,
	[ToUser] [varchar](200) NOT NULL,
	[Title] [nvarchar](30) NOT NULL,
	[State] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Comment] [nvarchar](200) NOT NULL,
	[Number] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](200) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
	[LastEditUser] [varchar](200) NOT NULL,
 CONSTRAINT [PK_TransactionHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_TransactionHistory] UNIQUE NONCLUSTERED 
(
	[TransactionNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [varchar](200) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserPassWord] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[Phone] [char](11) NULL,
	[LastChangeUserNameDate] [datetime] NOT NULL,
	[Role] [char](5) NOT NULL,
	[DefaultAddressID] [int] NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](200) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
	[LastEditUser] [varchar](200) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_User] UNIQUE NONCLUSTERED 
(
	[UserID] ASC,
	[Phone] ASC,
	[UserName] ASC,
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserAddress]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserAddress](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [varchar](200) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[CustomerPhone] [char](11) NOT NULL,
	[CustomerPostCode] [varchar](10) NOT NULL,
	[Province] [nvarchar](20) NOT NULL,
	[City] [nvarchar](20) NOT NULL,
	[County] [nvarchar](20) NOT NULL,
	[Town] [nvarchar](20) NOT NULL,
	[Village] [nvarchar](50) NOT NULL,
	[DetailedAddress] [nvarchar](200) NOT NULL,
	[Tags] [nvarchar](max) NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](200) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
	[LastEditUser] [varchar](200) NOT NULL,
 CONSTRAINT [PK_UserAddress_1] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_UserAddress] UNIQUE NONCLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserWatch]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserWatch](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [varchar](200) NOT NULL,
	[WatchID] [varchar](200) NOT NULL,
	[WatchType] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](200) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
	[LastEditUser] [varchar](200) NOT NULL,
 CONSTRAINT [PK_UserWatch] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[pro_name]    Script Date: 12/29/2017 4:04:45 下午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[pro_name](@UserID varchar(200))
as
	INSERT INTO [dbo].[User]
           ([UserID]
           ,[UserName]
           ,[UserPassWord]
           ,[Email]
           ,[Phone]
           ,[Role])
     VALUES
           (@UserID
           ,'az8g'
           ,'111111'
           ,'Alvin.X.Zhang@newegg.com'
           ,12345678910
           ,'11111')

GO
USE [master]
GO
ALTER DATABASE [EasyBuy] SET  READ_WRITE 
GO
