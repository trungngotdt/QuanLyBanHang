USE [master]
GO
/****** Object:  Database [QuanLyBanHang]    Script Date: 11/27/2017 10:38:07 PM ******/
CREATE DATABASE [QuanLyBanHang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyBanHang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\QuanLyBanHang.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyBanHang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\QuanLyBanHang_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QuanLyBanHang] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyBanHang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyBanHang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyBanHang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyBanHang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyBanHang] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyBanHang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyBanHang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyBanHang] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyBanHang] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyBanHang', N'ON'
GO
ALTER DATABASE [QuanLyBanHang] SET QUERY_STORE = OFF
GO
USE [QuanLyBanHang]
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
USE [QuanLyBanHang]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 11/27/2017 10:38:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHoaDon] [int] NOT NULL,
	[MaHang] [varchar](50) NOT NULL,
	[DonGia] [float] NOT NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hang]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hang](
	[MaHang] [varchar](50) NOT NULL,
	[TenHang] [nvarchar](50) NOT NULL,
	[DonGia] [float] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_Hang] PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NOT NULL,
	[LoaiHoaDon] [nvarchar](50) NOT NULL,
	[MaNV] [int] NOT NULL,
	[NgayLap] [datetime] NOT NULL,
	[NguoiLap] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_HoaDon_1] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](50) NOT NULL,
	[SDT] [int] NOT NULL,
	[GioiTinh] [bit] NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[LoaiKhachHang] [nvarchar](10) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[ChucVu] [nvarchar](20) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[DienThoai] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaHang], [DonGia], [SoLuong]) VALUES (7, N'DT-HHSP', 1080, 1)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaHang], [DonGia], [SoLuong]) VALUES (7, N'Hang', 123, 10)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaHang], [DonGia], [SoLuong]) VALUES (1007, N'AAA', 1200, 1)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaHang], [DonGia], [SoLuong]) VALUES (1012, N'AAA', 1200, 1199)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaHang], [DonGia], [SoLuong]) VALUES (1012, N'DT-HHSP', 1080, 10000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaHang], [DonGia], [SoLuong]) VALUES (1013, N'AAA', 1200, -1200)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaHang], [DonGia], [SoLuong]) VALUES (1013, N'DT-HHSP', 1080, -2000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaHang], [DonGia], [SoLuong]) VALUES (1014, N'AAA', 1200, -1200)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaHang], [DonGia], [SoLuong]) VALUES (1014, N'DT-HHSP', 1080, -2000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaHang], [DonGia], [SoLuong]) VALUES (1015, N'AAA', 1200, 1200)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaHang], [DonGia], [SoLuong]) VALUES (1015, N'DT-HHSP', 1080, 2000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaHang], [DonGia], [SoLuong]) VALUES (1016, N'AAA', 1200, 1200)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaHang], [DonGia], [SoLuong]) VALUES (1016, N'DT-HHSP', 1080, 2000)
INSERT [dbo].[Hang] ([MaHang], [TenHang], [DonGia], [SoLuong], [GhiChu]) VALUES (N'AAA', N'AA', 1200, 4799, N'AA')
INSERT [dbo].[Hang] ([MaHang], [TenHang], [DonGia], [SoLuong], [GhiChu]) VALUES (N'AAB', N'Pin', 100, 100, N'')
INSERT [dbo].[Hang] ([MaHang], [TenHang], [DonGia], [SoLuong], [GhiChu]) VALUES (N'DT-HHSP', N'Nokia', 1080, 16000, NULL)
INSERT [dbo].[Hang] ([MaHang], [TenHang], [DonGia], [SoLuong], [GhiChu]) VALUES (N'Hang', N'Một', 123, 500, NULL)
INSERT [dbo].[Hang] ([MaHang], [TenHang], [DonGia], [SoLuong], [GhiChu]) VALUES (N'HH1', N'HH1', 100, 10, NULL)
INSERT [dbo].[Hang] ([MaHang], [TenHang], [DonGia], [SoLuong], [GhiChu]) VALUES (N'HH2', N'HH2', 1000, 20, NULL)
INSERT [dbo].[Hang] ([MaHang], [TenHang], [DonGia], [SoLuong], [GhiChu]) VALUES (N'HH3', N'HH3', 5000, 30, NULL)
INSERT [dbo].[Hang] ([MaHang], [TenHang], [DonGia], [SoLuong], [GhiChu]) VALUES (N'HH4', N'HH4', 6000, 40, NULL)
INSERT [dbo].[Hang] ([MaHang], [TenHang], [DonGia], [SoLuong], [GhiChu]) VALUES (N'Laptop', N'Dell', 7000500, 90, NULL)
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (1, 5, N'Bán hàng', 1, CAST(N'2017-09-17T00:00:00.000' AS DateTime), N'A')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (2, 1, N'Xuất', 2, CAST(N'2017-10-17T00:00:00.000' AS DateTime), N'B')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (3, 2, N'Nhập', 2, CAST(N'2017-11-17T00:00:00.000' AS DateTime), N'B')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (4, 1, N'Hoàn', 2, CAST(N'2017-12-17T00:00:00.000' AS DateTime), N'B')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (5, 4, N'Bán Hàng', 1, CAST(N'2017-10-15T15:55:10.000' AS DateTime), N'A')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (6, 5, N'Bán Hàng', 1, CAST(N'2017-09-10T10:34:09.000' AS DateTime), N'A')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (7, 1, N'Bán Hàng', 1, CAST(N'2017-10-15T19:18:47.000' AS DateTime), N'A')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (8, 5, N'Bán Hàng', 1, CAST(N'2017-10-15T20:22:04.000' AS DateTime), N'A')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (1007, 1, N'Bán Hàng', 1, CAST(N'2017-11-27T17:17:51.000' AS DateTime), N'A')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (1008, 6, N'Xuất', 2, CAST(N'2017-11-27T17:52:23.000' AS DateTime), N'B')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (1009, 6, N'Xuất', 2, CAST(N'2017-11-27T17:52:58.000' AS DateTime), N'B')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (1010, 6, N'Xuất', 2, CAST(N'2017-11-27T18:08:36.000' AS DateTime), N'B')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (1011, 6, N'Xuất', 2, CAST(N'2017-11-27T18:10:36.000' AS DateTime), N'B')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (1012, 6, N'Nhập', 2, CAST(N'2017-11-27T18:12:27.000' AS DateTime), N'B')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (1013, 6, N'Nhập', 2, CAST(N'2017-11-27T18:22:26.000' AS DateTime), N'B')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (1014, 6, N'Nhập', 2, CAST(N'2017-11-27T18:23:44.000' AS DateTime), N'B')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (1015, 6, N'Xuất', 2, CAST(N'2017-11-27T18:25:38.000' AS DateTime), N'B')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [LoaiHoaDon], [MaNV], [NgayLap], [NguoiLap]) VALUES (1016, 6, N'Nhập', 2, CAST(N'2017-11-27T18:28:16.000' AS DateTime), N'B')
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [LoaiKhachHang]) VALUES (1, N'CT1', 456, 0, N'CTDC', N'DT')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [LoaiKhachHang]) VALUES (2, N'CT2', 654, 0, N'CTDC1', N'DT')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [LoaiKhachHang]) VALUES (3, N'Microsoft', 789, 1, N'TP', N'DT')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [LoaiKhachHang]) VALUES (4, N'võ', 987, 1, N'Sài gòn', N'VIP')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [LoaiKhachHang]) VALUES (5, N'KH', 123, NULL, N'DC', N'VIP')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [LoaiKhachHang]) VALUES (6, N'KH2', 321, NULL, N'DC1', N'DT')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [LoaiKhachHang]) VALUES (7, N'CMC', 12, 1, N'VungTau', N'DT')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [LoaiKhachHang]) VALUES (8, N'AAA', 210, 0, N'TayNinh', N'VIP')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [LoaiKhachHang]) VALUES (1007, N'BBB', 111, 1, N'BBB', N'DT')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [LoaiKhachHang]) VALUES (1010, N'BBc', 1121, 0, N'BBcB', N'DT')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [DiaChi], [DienThoai], [Email], [TenDangNhap], [MatKhau]) VALUES (1, N'A', N'NV', N'B', 123, N'@gmail', N'A', N'123')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [DiaChi], [DienThoai], [Email], [TenDangNhap], [MatKhau]) VALUES (2, N'B', N'TK', N'C', 123, N'@gmail', N'B', N'321')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [DiaChi], [DienThoai], [Email], [TenDangNhap], [MatKhau]) VALUES (3, N'Admin', N'GD', N'GD', 123, N'@gmail', N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Hang__19C0DB1C5807381D]    Script Date: 11/27/2017 10:38:08 PM ******/
ALTER TABLE [dbo].[Hang] ADD UNIQUE NONCLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__KhachHan__2725CF1F9E407547]    Script Date: 11/27/2017 10:38:08 PM ******/
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [UQ__KhachHan__2725CF1F9E407547] UNIQUE NONCLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__KhachHan__CA1930A5566D1C79]    Script Date: 11/27/2017 10:38:08 PM ******/
ALTER TABLE [dbo].[KhachHang] ADD UNIQUE NONCLUSTERED 
(
	[SDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__227ABFF70236789D]    Script Date: 11/27/2017 10:38:08 PM ******/
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [UQ__NhanVien__227ABFF70236789D] UNIQUE NONCLUSTERED 
(
	[MaNV] ASC,
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHo__MaHan__59063A47] FOREIGN KEY([MaHang])
REFERENCES [dbo].[Hang] ([MaHang])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK__ChiTietHo__MaHan__59063A47]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHo__MaHoa__2CF2ADDF] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK__ChiTietHo__MaHoa__2CF2ADDF]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK__HoaDon__MaKH__236943A5] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK__HoaDon__MaKH__236943A5]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK__HoaDon__MaNV__6A30C649] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK__HoaDon__MaNV__6A30C649]
GO
/****** Object:  StoredProcedure [dbo].[USP_CheckChucVu]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_CheckChucVu]
	@Name nvarchar(50)
AS
BEGIN
	SELECT nv.ChucVu FROM dbo.NhanVien nv WHERE nv.TenDangNhap LIKE @Name
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetChiTietHoaDon]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_GetChiTietHoaDon]
@id int
AS
BEGIN
	SELECT cthd.* FROM dbo.ChiTietHoaDon cthd WHERE cthd.MaHoaDon = @id
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetDonGia]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_GetDonGia]
@name nvarchar(50)
AS
BEGIN
	SELECT h.DonGia FROM dbo.Hang h WHERE h.TenHang LIKE @name
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetDonGiaByMH]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_GetDonGiaByMH]
@id nvarchar(50)
AS
BEGIN
	SELECT h.DonGia FROM dbo.Hang h WHERE h.MaHang like @id
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetKHBySDT]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetKHBySDT]
@SDT int
AS
BEGIN
	SELECT * FROM dbo.KhachHang kh WHERE kh.SDT LIKE @SDT
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetMaHang]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetMaHang]
@name nvarchar(50)
AS
BEGIN
SELECT h.MaHang FROM dbo.Hang h WHERE h.TenHang LIKE @name
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetMaHoaDon]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_GetMaHoaDon]
@idcustomer int,@type nvarchar(50),@idstaff int,@date datetime,@namestaff nvarchar(50)
AS
BEGIN
SELECT hd.MaHoaDon FROM dbo.HoaDon hd WHERE hd.MaKH LIKE @idcustomer AND hd.LoaiHoaDon LIKE @type AND hd.MaNV LIKE @idstaff AND hd.NguoiLap LIKE @namestaff AND hd.NgayLap = @date
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetMaKH]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetMaKH]
@name nvarchar(50)
AS
BEGIN
SELECT kh.MaKH FROM dbo.KhachHang kh WHERE kh.TenKH LIKE @name
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetMaKHBySDT]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_GetMaKHBySDT]
@sdt int
AS
BEGIN
SELECT kh.MaKH FROM dbo.KhachHang kh WHERE kh.SDT LIKE @sdt
END


GO
/****** Object:  StoredProcedure [dbo].[USP_GetMaNV]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_GetMaNV]
@name nvarchar(50)
AS
BEGIN
SELECT nv.MaNV FROM dbo.NhanVien nv WHERE nv.TenNV LIKE @name
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetMaNVByNameSignIn]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[USP_GetMaNVByNameSignIn]
@name nvarchar(50)
AS
BEGIN
	SELECT nv.MaNV FROM dbo.NhanVien nv WHERE nv.TenDangNhap LIKE @name
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetPassword]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetPassword]
@name nvarchar(50)
AS 
BEGIN
	SELECT nv.MatKhau FROM dbo.NhanVien nv WHERE nv.TenDangNhap LIKE @name
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetSoLuong]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_GetSoLuong]
@idgoods varchar(50)
AS
BEGIN
	SELECT h.SoLuong FROM dbo.Hang h WHERE h.MaHang LIKE @idgoods
END


GO
/****** Object:  StoredProcedure [dbo].[USP_GetTenKH]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_GetTenKH]
@sdt int
AS
BEGIN
SELECT kh.TenKH FROM dbo.KhachHang kh WHERE kh.SDT LIKE @sdt
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTenNV]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_GetTenNV]
@ma int
AS
BEGIN
	SELECT nv.TenNV FROM dbo.NhanVien nv WHERE nv.MaNV LIKE @ma
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertChiTietHoaDon]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_InsertChiTietHoaDon]
@idbill int,@idgoods varchar(50),@price float,@number int
AS
BEGIN

INSERT dbo.ChiTietHoaDon
(
    MaHoaDon,
    MaHang,
    DonGia,
    SoLuong
)
VALUES
(
    @idbill, -- MaHoaDon - varchar
    @idgoods, -- MaHang - varchar
    @price, -- DonGia - float
    @number -- SoLuong - int
)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertHang]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_InsertHang]
@idgoods varchar(50),@namegoods nvarchar(50),@price float,@number int,@notice nvarchar(50)
AS
BEGIN
INSERT dbo.Hang
(
    MaHang,
    TenHang,
    DonGia,
    SoLuong,
	GhiChu
)
VALUES
(
    @idgoods, -- MaHang - varchar
    @namegoods, -- TenHang - nvarchar
    @price, -- DonGia - float
    @number, -- SoLuong - int
	@notice
)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertHoaDon]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[USP_InsertHoaDon]
@idcustomer int,@typebill nvarchar(50),@idstaff int,@date datetime,@namestaff nvarchar(50)
AS
BEGIN 
INSERT dbo.HoaDon
(
    
    MaKH,
    LoaiHoaDon,
    MaNV,
    NgayLap,
    NguoiLap
)
VALUES
(
    
    @idcustomer, -- MaKH - varchar
    @typebill, -- LoaiHoaDon - nvarchar
    @idstaff, -- MaNV - varchar
    @date, -- NgayLap - datetime
    @namestaff -- NguoiLap - nvarchar
)

END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertKhachHang]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_InsertKhachHang]

@name nvarchar(50),
@phone int ,
@sex bit ,
@address nvarchar(100) ,
@level nvarchar(10)
AS
BEGIN
	
INSERT dbo.KhachHang
(
    
    TenKH,
    SDT,
    GioiTinh,
    DiaChi,
    LoaiKhachHang
)
VALUES
(
    @name, -- TenKH - nvarchar
    @phone, -- SDT - int
    @sex, -- GioiTinh - bit
    @address, -- DiaChi - nvarchar
    @level -- LoaiKhachHang - nvarchar
)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertNV]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_InsertNV]

@Ten nvarchar(50),
@Chuc nvarchar(20) ,
@DiaChi nvarchar(100) ,
@SDT int,
@Email nvarchar(50) 

AS
BEGIN

INSERT dbo.NhanVien
(
    --MaNV - this column value is auto-generated
    TenNV,
    ChucVu,
    DiaChi,
    DienThoai,
    Email,
    TenDangNhap,
    MatKhau
)
VALUES
(
    -- MaNV - int
    @Ten, -- TenNV - nvarchar
    @Chuc, -- ChucVu - nvarchar
    @DiaChi, -- DiaChi - nvarchar
    @SDT, -- DienThoai - int
    @Email, -- Email - nvarchar
    @Ten, -- TenDangNhap - nvarchar
    @SDT -- MatKhau - nvarchar
)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SearchHang]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_SearchHang]
@name nvarchar(50)
AS
BEGIN
	SELECT * FROM dbo.Hang h WHERE h.TenHang LIKE @name
End
GO
/****** Object:  StoredProcedure [dbo].[USP_SignIn]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_SignIn]
	@Name nvarchar(50),@Pass nvarchar(50)
	AS
	BEGIN
		SELECT * FROM dbo.NhanVien nv WHERE nv.TenDangNhap LIKE @Name AND nv.MatKhau LIKE @Pass
	END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateHang]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_UpdateHang]
@idgoods varchar(50),@namegoods nvarchar(50),@price float,@number int,@notice nvarchar(50)
AS
BEGIN
	UPDATE dbo.Hang
SET
    dbo.Hang.TenHang = @namegoods, -- nvarchar
    dbo.Hang.DonGia = @price, -- float
    dbo.Hang.SoLuong = @number, -- int
    dbo.Hang.GhiChu = @notice -- nvarchar
	WHERE dbo.Hang.MaHang LIKE @idgoods
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateKH]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_UpdateKH]

@MaKH int,
@TenKH nvarchar(50),
@SDT int,
@Gioi bit,
@DiaChi nvarchar(100),
@Loai nvarchar(10)

AS
BEGIN

UPDATE dbo.KhachHang
SET
    --MaKH - this column value is auto-generated
    dbo.KhachHang.TenKH = @TenKH, -- nvarchar
    dbo.KhachHang.SDT = @SDT, -- int
    dbo.KhachHang.GioiTinh = @Gioi, -- bit
    dbo.KhachHang.DiaChi = @DiaChi, -- nvarchar
    dbo.KhachHang.LoaiKhachHang = @Loai -- nvarchar
WHERE dbo.KhachHang.MaKH LIKE  @MaKH

END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateNVWithoutPassAndNameSignIn]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_UpdateNVWithoutPassAndNameSignIn]
@MaNV int,
@Ten nvarchar(50),
@Chuc nvarchar(20) ,
@DiaChi nvarchar(100) ,
@SDT int,
@Email nvarchar(50) 

As
BEGIN
UPDATE dbo.NhanVien
SET
    --MaNV - this column value is auto-generated
    dbo.NhanVien.TenNV = @Ten, -- nvarchar
    dbo.NhanVien.ChucVu = @Chuc, -- nvarchar
    dbo.NhanVien.DiaChi = @DiaChi, -- nvarchar
    dbo.NhanVien.DienThoai = @SDT, -- int
    dbo.NhanVien.Email = @Email -- nvarchar
	WHERE dbo.NhanVien.MaNV LIKE @MaNV
end 
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateSoLuongHang]    Script Date: 11/27/2017 10:38:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_UpdateSoLuongHang]
@idgoods varchar(50),@number int
AS
BEGIN
	UPDATE dbo.Hang
SET
	 dbo.Hang.SoLuong = @number -- int
WHERE dbo.Hang.MaHang LIKE @idgoods 
END
GO
USE [master]
GO
ALTER DATABASE [QuanLyBanHang] SET  READ_WRITE 
GO
