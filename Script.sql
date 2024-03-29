USE [master]
GO
/****** Object:  Database [XEPLICH]    Script Date: 10/25/2019 8:06:53 PM ******/
CREATE DATABASE [XEPLICH]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'XEPLICH', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\XEPLICH.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'XEPLICH_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\XEPLICH_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [XEPLICH] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [XEPLICH].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [XEPLICH] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [XEPLICH] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [XEPLICH] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [XEPLICH] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [XEPLICH] SET ARITHABORT OFF 
GO
ALTER DATABASE [XEPLICH] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [XEPLICH] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [XEPLICH] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [XEPLICH] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [XEPLICH] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [XEPLICH] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [XEPLICH] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [XEPLICH] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [XEPLICH] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [XEPLICH] SET  ENABLE_BROKER 
GO
ALTER DATABASE [XEPLICH] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [XEPLICH] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [XEPLICH] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [XEPLICH] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [XEPLICH] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [XEPLICH] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [XEPLICH] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [XEPLICH] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [XEPLICH] SET  MULTI_USER 
GO
ALTER DATABASE [XEPLICH] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [XEPLICH] SET DB_CHAINING OFF 
GO
ALTER DATABASE [XEPLICH] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [XEPLICH] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [XEPLICH] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [XEPLICH] SET QUERY_STORE = OFF
GO
USE [XEPLICH]
GO
/****** Object:  Table [dbo].[GIANGVIEN]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIANGVIEN](
	[maGV] [varchar](10) NOT NULL,
	[ten] [nvarchar](100) NULL,
	[soBuoiGac] [varchar](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOP]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOP](
	[maLop] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOPHOCPHAN]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOPHOCPHAN](
	[maLHP] [varchar](20) NOT NULL,
	[maLop] [varchar](10) NULL,
	[maMon] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[maLHP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MON]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MON](
	[maMon] [varchar](10) NOT NULL,
	[tenMon] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[maMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONG]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONG](
	[maPhong] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONGTHI]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONGTHI](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[maPhong] [varchar](10) NULL,
	[maGV] [varchar](10) NULL,
	[maLHP] [varchar](20) NOT NULL,
	[ngayThi] [date] NOT NULL,
	[caThi] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maLHP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[taiKhoan] [varchar](100) NOT NULL,
	[matKhau] [varchar](100) NULL,
	[maGV] [varchar](10) NULL,
	[loaiTK] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[taiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[GIANGVIEN] ([maGV], [ten], [soBuoiGac]) VALUES (N'1CNTT', NULL, N'2')
INSERT [dbo].[GIANGVIEN] ([maGV], [ten], [soBuoiGac]) VALUES (N'2CNTT', NULL, N'2')
INSERT [dbo].[GIANGVIEN] ([maGV], [ten], [soBuoiGac]) VALUES (N'3CNTT', NULL, N'2')
INSERT [dbo].[GIANGVIEN] ([maGV], [ten], [soBuoiGac]) VALUES (N'4CNTT', NULL, N'2')
INSERT [dbo].[GIANGVIEN] ([maGV], [ten], [soBuoiGac]) VALUES (N'5CNTT', NULL, N'1')
INSERT [dbo].[GIANGVIEN] ([maGV], [ten], [soBuoiGac]) VALUES (N'6CNTT', NULL, N'1')
INSERT [dbo].[LOP] ([maLop]) VALUES (N'HTTT0117')
INSERT [dbo].[LOP] ([maLop]) VALUES (N'HTTT0217')
INSERT [dbo].[LOP] ([maLop]) VALUES (N'KHMT0117')
INSERT [dbo].[LOP] ([maLop]) VALUES (N'KHMT0217')
INSERT [dbo].[LOP] ([maLop]) VALUES (N'KTPM0117')
INSERT [dbo].[LOP] ([maLop]) VALUES (N'KTPM0217')
INSERT [dbo].[LOPHOCPHAN] ([maLHP], [maLop], [maMon]) VALUES (N'010100091201', N'HTTT0217', N'003')
INSERT [dbo].[LOPHOCPHAN] ([maLHP], [maLop], [maMon]) VALUES (N'010100091202', N'KHMT0117', N'003')
INSERT [dbo].[LOPHOCPHAN] ([maLHP], [maLop], [maMon]) VALUES (N'010100091402', N'KTPM0117', N'001')
INSERT [dbo].[LOPHOCPHAN] ([maLHP], [maLop], [maMon]) VALUES (N'010100091403', N'KTPM0217', N'001')
INSERT [dbo].[LOPHOCPHAN] ([maLHP], [maLop], [maMon]) VALUES (N'010100138201', N'KTPM0117', N'004')
INSERT [dbo].[LOPHOCPHAN] ([maLHP], [maLop], [maMon]) VALUES (N'010100138202', N'KTPM0217', N'004')
INSERT [dbo].[LOPHOCPHAN] ([maLHP], [maLop], [maMon]) VALUES (N'010100139201', N'KHMT0217', N'002')
INSERT [dbo].[LOPHOCPHAN] ([maLHP], [maLop], [maMon]) VALUES (N'010100139202', N'HTTT0117', N'002')
INSERT [dbo].[LOPHOCPHAN] ([maLHP], [maLop], [maMon]) VALUES (N'010100214301', N'KHMT0117', N'005')
INSERT [dbo].[LOPHOCPHAN] ([maLHP], [maLop], [maMon]) VALUES (N'010100214302', N'KHMT0217', N'005')
INSERT [dbo].[MON] ([maMon], [tenMon]) VALUES (N'001', N'Phần mềm mã nguồn mở')
INSERT [dbo].[MON] ([maMon], [tenMon]) VALUES (N'002', N'Lập trình an toàn')
INSERT [dbo].[MON] ([maMon], [tenMon]) VALUES (N'003', N'Lập trình Java 1')
INSERT [dbo].[MON] ([maMon], [tenMon]) VALUES (N'004', N'Kiến trúc phần mềm')
INSERT [dbo].[MON] ([maMon], [tenMon]) VALUES (N'005', N'Ngôn ngữ mô hình hóa UML')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C1.1')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C1.2')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C1.3')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C1.4')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C1.5')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C2.1')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C2.2')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C2.3')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C2.4')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C2.5')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C3.1')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C3.2')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C3.3')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C3.4')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C3.5')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C4.1')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C4.2')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C4.3')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C4.4')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C4.5')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C5.1')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C5.2')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C5.3')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C5.4')
INSERT [dbo].[PHONG] ([maPhong]) VALUES (N'C5.5')
SET IDENTITY_INSERT [dbo].[PHONGTHI] ON 

INSERT [dbo].[PHONGTHI] ([id], [maPhong], [maGV], [maLHP], [ngayThi], [caThi]) VALUES (6, N'C4.4', N'2CNTT', N'010100091201', CAST(N'2019-01-02' AS Date), 2)
INSERT [dbo].[PHONGTHI] ([id], [maPhong], [maGV], [maLHP], [ngayThi], [caThi]) VALUES (5, N'C4.5', N'1CNTT', N'010100091202', CAST(N'2019-01-02' AS Date), 2)
INSERT [dbo].[PHONGTHI] ([id], [maPhong], [maGV], [maLHP], [ngayThi], [caThi]) VALUES (2, N'C1.2', N'3CNTT', N'010100091402', CAST(N'2019-01-07' AS Date), 3)
INSERT [dbo].[PHONGTHI] ([id], [maPhong], [maGV], [maLHP], [ngayThi], [caThi]) VALUES (1, N'C1.1', N'5CNTT', N'010100091403', CAST(N'2019-01-07' AS Date), 3)
INSERT [dbo].[PHONGTHI] ([id], [maPhong], [maGV], [maLHP], [ngayThi], [caThi]) VALUES (8, N'C5.3', N'4CNTT', N'010100138201', CAST(N'2018-12-26' AS Date), 1)
INSERT [dbo].[PHONGTHI] ([id], [maPhong], [maGV], [maLHP], [ngayThi], [caThi]) VALUES (7, N'C5.2', N'3CNTT', N'010100138202', CAST(N'2018-12-26' AS Date), 1)
INSERT [dbo].[PHONGTHI] ([id], [maPhong], [maGV], [maLHP], [ngayThi], [caThi]) VALUES (4, N'C4.3', N'1CNTT', N'010100139201', CAST(N'2019-01-04' AS Date), 1)
INSERT [dbo].[PHONGTHI] ([id], [maPhong], [maGV], [maLHP], [ngayThi], [caThi]) VALUES (3, N'C4.2', N'6CNTT', N'010100139202', CAST(N'2019-01-04' AS Date), 1)
INSERT [dbo].[PHONGTHI] ([id], [maPhong], [maGV], [maLHP], [ngayThi], [caThi]) VALUES (10, N'C3.4', N'2CNTT', N'010100214301', CAST(N'2018-12-25' AS Date), 4)
INSERT [dbo].[PHONGTHI] ([id], [maPhong], [maGV], [maLHP], [ngayThi], [caThi]) VALUES (9, N'C3.3', N'4CNTT', N'010100214302', CAST(N'2018-12-25' AS Date), 4)
SET IDENTITY_INSERT [dbo].[PHONGTHI] OFF
INSERT [dbo].[TAIKHOAN] ([taiKhoan], [matKhau], [maGV], [loaiTK]) VALUES (N'1CNTT', N'1', N'1CNTT', NULL)
INSERT [dbo].[TAIKHOAN] ([taiKhoan], [matKhau], [maGV], [loaiTK]) VALUES (N'2CNTT', N'1', N'2CNTT', NULL)
INSERT [dbo].[TAIKHOAN] ([taiKhoan], [matKhau], [maGV], [loaiTK]) VALUES (N'3CNTT', N'1', N'3CNTT', NULL)
INSERT [dbo].[TAIKHOAN] ([taiKhoan], [matKhau], [maGV], [loaiTK]) VALUES (N'4CNTT', N'1', N'4CNTT', NULL)
INSERT [dbo].[TAIKHOAN] ([taiKhoan], [matKhau], [maGV], [loaiTK]) VALUES (N'5CNTT', N'1', N'5CNTT', NULL)
INSERT [dbo].[TAIKHOAN] ([taiKhoan], [matKhau], [maGV], [loaiTK]) VALUES (N'6CNTT', N'1', N'6CNTT', NULL)
INSERT [dbo].[TAIKHOAN] ([taiKhoan], [matKhau], [maGV], [loaiTK]) VALUES (N'admin', N'1', N'admin', NULL)
ALTER TABLE [dbo].[GIANGVIEN] ADD  DEFAULT ((0)) FOR [soBuoiGac]
GO
ALTER TABLE [dbo].[LOPHOCPHAN]  WITH CHECK ADD FOREIGN KEY([maLop])
REFERENCES [dbo].[LOP] ([maLop])
GO
ALTER TABLE [dbo].[LOPHOCPHAN]  WITH CHECK ADD FOREIGN KEY([maMon])
REFERENCES [dbo].[MON] ([maMon])
GO
ALTER TABLE [dbo].[PHONGTHI]  WITH CHECK ADD FOREIGN KEY([maGV])
REFERENCES [dbo].[GIANGVIEN] ([maGV])
GO
ALTER TABLE [dbo].[PHONGTHI]  WITH CHECK ADD FOREIGN KEY([maLHP])
REFERENCES [dbo].[LOPHOCPHAN] ([maLHP])
GO
ALTER TABLE [dbo].[PHONGTHI]  WITH CHECK ADD FOREIGN KEY([maPhong])
REFERENCES [dbo].[PHONG] ([maPhong])
GO
/****** Object:  StoredProcedure [dbo].[USP_CapNhatGiangVien]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--Cập nhật
create proc [dbo].[USP_CapNhatGiangVien] --
@maGV varchar(10), @ten nvarchar(100)
as
	update GIANGVIEN set ten = @ten
	where maGV = @maGV

GO
/****** Object:  StoredProcedure [dbo].[USP_CapNhatPhongThi]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_CapNhatPhongThi] --
@maGV varchar(10), @maLHP varchar(20)
as
	update PHONGTHI set maGV = @maGV
	where maLHP = @maLHP
GO
/****** Object:  StoredProcedure [dbo].[USP_CapNhatSoBuoiGac]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_CapNhatSoBuoiGac] --
@maGV varchar(10), @soBuoiGac varchar(2)
as
	update GIANGVIEN set soBuoiGac = @soBuoiGac
	where maGV = @maGV
GO
/****** Object:  StoredProcedure [dbo].[USP_LayDSGiangVien]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_LayDSGiangVien] --
as
	select * from GIANGVIEN
GO
/****** Object:  StoredProcedure [dbo].[USP_LayDSLHP]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_LayDSLHP] --
as
	select * from LOPHOCPHAN
GO
/****** Object:  StoredProcedure [dbo].[USP_LayDSLop]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_LayDSLop] --
as
	select * from LOP
GO
/****** Object:  StoredProcedure [dbo].[USP_LayDSMon]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_LayDSMon] -- 
as
	select * from MON
GO
/****** Object:  StoredProcedure [dbo].[USP_LayDSPhong]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- lấy danh sách
create proc [dbo].[USP_LayDSPhong] --
as
	select * from PHONG
GO
/****** Object:  StoredProcedure [dbo].[USP_LayDSPhongThi]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_LayDSPhongThi] --
as
	select * from PHONGTHI
GO
/****** Object:  StoredProcedure [dbo].[USP_LayDSTaiKhoan]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_LayDSTaiKhoan] --
as
	select * from TAIKHOAN
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Login]  --đăng nhập--
@userName varchar(100), @passWord varchar(100)
as
begin
	select * from taikhoan where taiKhoan = @userName and matKhau = @passWord
end
GO
/****** Object:  StoredProcedure [dbo].[USP_ThemGiangVien]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Thêm
create proc [dbo].[USP_ThemGiangVien] --
@maGV varchar(10), @ten nvarchar(100)
as
begin
	insert into GIANGVIEN (maGV, ten)
	values (@maGV, @ten)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_ThemLHP]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_ThemLHP] --
@maLHP varchar(20), @maLop varchar(10), @maMon varchar(10)
as
	insert into LOPHOCPHAN
	values (@maLHP, @maLop, @maMon)

GO
/****** Object:  StoredProcedure [dbo].[USP_ThemLop]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_ThemLop] --
@maLop varchar(10)
as
	insert into LOP (maLop)
	values (@maLop)

GO
/****** Object:  StoredProcedure [dbo].[USP_ThemMon]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_ThemMon] --
@maMon varchar(20), @tenMon nvarchar(100)
as
	insert into MON
	values (@maMon, @tenMon)

GO
/****** Object:  StoredProcedure [dbo].[USP_ThemPhong]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_ThemPhong] --
@maPhong varchar(10)
as
	insert into PHONG
	values (@maPhong)

GO
/****** Object:  StoredProcedure [dbo].[USP_ThemPhongThi]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_ThemPhongThi] --
@maPhong varchar(10), @maGV varchar(10), @maLHP varchar(20), @ngay date, @caThi tinyint
as
	insert into PHONGTHI 
	values (@maPhong, @maGV, @maLHP, @ngay, @caThi)

GO
/****** Object:  StoredProcedure [dbo].[USP_ThemTaiKhoan]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_ThemTaiKhoan] --
@taiKhoan varchar(100), @matKhau varchar(100), @maGV varchar(10), @loaiTK varchar(10)
as
	insert into TAIKHOAN
	values (@taiKhoan, @matKhau, @maGV, @loaiTK)

GO
/****** Object:  StoredProcedure [dbo].[USP_XoaGiangVien]    Script Date: 10/25/2019 8:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- xóa

create proc [dbo].[USP_XoaGiangVien] --
@maGV varchar(10)
as
	delete from GIANGVIEN
	where maGV = @maGV
GO
USE [master]
GO
ALTER DATABASE [XEPLICH] SET  READ_WRITE 
GO
