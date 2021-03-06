USE [master]
GO
/****** Object:  Database [QLSV]    Script Date: 11/28/2020 7:52:59 PM ******/
CREATE DATABASE [QLSV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLSV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.EAGLEMSSQL17\MSSQL\DATA\QLSV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLSV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.EAGLEMSSQL17\MSSQL\DATA\QLSV_log.ldf' , SIZE = 3976KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLSV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLSV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLSV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLSV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLSV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLSV] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLSV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLSV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLSV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLSV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLSV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLSV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLSV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLSV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLSV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLSV] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLSV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLSV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLSV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLSV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLSV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLSV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLSV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLSV] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLSV] SET  MULTI_USER 
GO
ALTER DATABASE [QLSV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLSV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLSV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLSV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLSV', N'ON'
GO
USE [QLSV]
GO
/****** Object:  UserDefinedTableType [dbo].[Khoa]    Script Date: 11/28/2020 7:53:00 PM ******/
CREATE TYPE [dbo].[Khoa] AS TABLE(
	[Ten] [nvarchar](255) NULL,
	[Phong] [char](5) NULL
)
GO
/****** Object:  UserDefinedFunction [dbo].[fn_split]    Script Date: 11/28/2020 7:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[fn_split](
@input nvarchar(max),
@char nvarchar(max)
)
returns @tbl TABLE (val nvarchar(max))
as
begin
	while(charindex(@char, @input) > 0)
	begin
		insert into @tbl 
		select left(@input, charindex(@char, @input)-1)
		set @input = right(@input, len(@input) - charindex(@char, @input))
	end
	insert into @tbl
	select @input
	return
end
GO
/****** Object:  UserDefinedFunction [dbo].[fn_substring]    Script Date: 11/28/2020 7:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[fn_substring](
@input nvarchar(max),
@startIndex int,
@range int)
returns nvarchar(MAX)
as
begin
	return left(right(@input,len(@input)-@startIndex+1), @range)
end
GO
/****** Object:  Table [dbo].[KetQua]    Script Date: 11/28/2020 7:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KetQua](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSinhVien] [int] NOT NULL,
	[IdMonHoc] [int] NOT NULL,
	[Diem] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 11/28/2020 7:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
	[Phong] [char](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHocBong]    Script Date: 11/28/2020 7:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHocBong](
	[IdLHB] [bigint] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NULL,
	[DiemHB_CanDuoi] [float] NULL,
	[DiemHB_CanTren] [float] NULL,
	[MucTien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_LoaiHocBong] PRIMARY KEY CLUSTERED 
(
	[IdLHB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 11/28/2020 7:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdKhoa] [int] NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK__Lop__3214EC07CEA8A0F4] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 11/28/2020 7:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
	[TinChi] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 11/28/2020 7:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdLop] [int] NOT NULL,
	[Ho] [nvarchar](255) NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](255) NULL,
	[Email] [varchar](100) NULL,
	[DiemTrungBinh] [float] NULL,
 CONSTRAINT [PK__SinhVien__3214EC078DE43E65] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_GetAllData]    Script Date: 11/28/2020 7:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vw_GetAllData]
AS
	select K.ID [IDK], K.Ten [TenKhoa], K.Phong, L.Id [IDL], L.Ten [TenLop], SV.Ho, SV.Ten, Diem
	from Khoa K
	JOIN Lop L on K.Id = L.IdKhoa
	JOIN SinhVien SV on SV.IdLop = l.Id
	JOIN KetQua KQ ON sv.Id = kq.IdSinhVien
GO
SET IDENTITY_INSERT [dbo].[KetQua] ON 

INSERT [dbo].[KetQua] ([Id], [IdSinhVien], [IdMonHoc], [Diem]) VALUES (1, 1, 1, 7)
INSERT [dbo].[KetQua] ([Id], [IdSinhVien], [IdMonHoc], [Diem]) VALUES (2, 1, 2, 9)
INSERT [dbo].[KetQua] ([Id], [IdSinhVien], [IdMonHoc], [Diem]) VALUES (3, 2, 1, 3.9)
INSERT [dbo].[KetQua] ([Id], [IdSinhVien], [IdMonHoc], [Diem]) VALUES (4, 2, 2, 5.4)
INSERT [dbo].[KetQua] ([Id], [IdSinhVien], [IdMonHoc], [Diem]) VALUES (5, 3, 1, 4.9)
INSERT [dbo].[KetQua] ([Id], [IdSinhVien], [IdMonHoc], [Diem]) VALUES (6, 3, 2, 6.9)
INSERT [dbo].[KetQua] ([Id], [IdSinhVien], [IdMonHoc], [Diem]) VALUES (7, 4, 1, 8.4)
INSERT [dbo].[KetQua] ([Id], [IdSinhVien], [IdMonHoc], [Diem]) VALUES (8, 4, 2, 6.9)
INSERT [dbo].[KetQua] ([Id], [IdSinhVien], [IdMonHoc], [Diem]) VALUES (9, 5, 1, 8.3)
INSERT [dbo].[KetQua] ([Id], [IdSinhVien], [IdMonHoc], [Diem]) VALUES (10, 5, 2, 5.9)
INSERT [dbo].[KetQua] ([Id], [IdSinhVien], [IdMonHoc], [Diem]) VALUES (11, 6, 1, 6.9)
INSERT [dbo].[KetQua] ([Id], [IdSinhVien], [IdMonHoc], [Diem]) VALUES (12, 6, 2, 9.4)
SET IDENTITY_INSERT [dbo].[KetQua] OFF
SET IDENTITY_INSERT [dbo].[Khoa] ON 

INSERT [dbo].[Khoa] ([Id], [Ten], [Phong]) VALUES (1, N'Công Nghệ Thông Tin', N'A101 ')
INSERT [dbo].[Khoa] ([Id], [Ten], [Phong]) VALUES (2, N'Điện - Điện tử', N'A102 ')
INSERT [dbo].[Khoa] ([Id], [Ten], [Phong]) VALUES (3, N'Hệ Thống Thông Tin', N'A103 ')
INSERT [dbo].[Khoa] ([Id], [Ten], [Phong]) VALUES (4, N'Cơ khí', N'A104 ')
INSERT [dbo].[Khoa] ([Id], [Ten], [Phong]) VALUES (5, N'Công trình', N'A105 ')
INSERT [dbo].[Khoa] ([Id], [Ten], [Phong]) VALUES (6, N'Kinh tế', N'B101 ')
INSERT [dbo].[Khoa] ([Id], [Ten], [Phong]) VALUES (7, N'Kiểm toán', N'B102 ')
INSERT [dbo].[Khoa] ([Id], [Ten], [Phong]) VALUES (8, N'Luật', N'B103 ')
SET IDENTITY_INSERT [dbo].[Khoa] OFF
SET IDENTITY_INSERT [dbo].[LoaiHocBong] ON 

INSERT [dbo].[LoaiHocBong] ([IdLHB], [Ten], [DiemHB_CanDuoi], [DiemHB_CanTren], [MucTien]) VALUES (1, N'Kha', 7, 8, CAST(1000000 AS Decimal(18, 0)))
INSERT [dbo].[LoaiHocBong] ([IdLHB], [Ten], [DiemHB_CanDuoi], [DiemHB_CanTren], [MucTien]) VALUES (2, N'Gioi', 8, 9, CAST(3000000 AS Decimal(18, 0)))
INSERT [dbo].[LoaiHocBong] ([IdLHB], [Ten], [DiemHB_CanDuoi], [DiemHB_CanTren], [MucTien]) VALUES (3, N'Xuat Sac', 9, 10, CAST(5000000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[LoaiHocBong] OFF
SET IDENTITY_INSERT [dbo].[Lop] ON 

INSERT [dbo].[Lop] ([Id], [IdKhoa], [Ten]) VALUES (1, 1, N'Khoa Học Máy Tính')
INSERT [dbo].[Lop] ([Id], [IdKhoa], [Ten]) VALUES (2, 1, N'Hệ Thống Thông Tin Quản Lý')
INSERT [dbo].[Lop] ([Id], [IdKhoa], [Ten]) VALUES (3, 1, N'An Toàn Thông Tin')
INSERT [dbo].[Lop] ([Id], [IdKhoa], [Ten]) VALUES (4, 1, N'Công Nghệ Phần Mềm')
INSERT [dbo].[Lop] ([Id], [IdKhoa], [Ten]) VALUES (5, 2, N'Điện Tử Viễn Thông')
INSERT [dbo].[Lop] ([Id], [IdKhoa], [Ten]) VALUES (6, 2, N'Tự Động Hóa')
INSERT [dbo].[Lop] ([Id], [IdKhoa], [Ten]) VALUES (7, 2, N'Tin Học Công Nghiệp')
SET IDENTITY_INSERT [dbo].[Lop] OFF
SET IDENTITY_INSERT [dbo].[MonHoc] ON 

INSERT [dbo].[MonHoc] ([Id], [Ten], [TinChi]) VALUES (1, N'Cấu trúc máy tính', 4)
INSERT [dbo].[MonHoc] ([Id], [Ten], [TinChi]) VALUES (2, N'Cơ sở dữ liệu', 4)
INSERT [dbo].[MonHoc] ([Id], [Ten], [TinChi]) VALUES (3, N'Giáo dục thể chất', 2)
SET IDENTITY_INSERT [dbo].[MonHoc] OFF
SET IDENTITY_INSERT [dbo].[SinhVien] ON 

INSERT [dbo].[SinhVien] ([Id], [IdLop], [Ho], [Ten], [NgaySinh], [DiaChi], [Email], [DiemTrungBinh]) VALUES (1, 2, N'Nguyễn Quang', N'Hải', CAST(N'1997-01-12' AS Date), NULL, N'haicute@gmail.com', 8)
INSERT [dbo].[SinhVien] ([Id], [IdLop], [Ho], [Ten], [NgaySinh], [DiaChi], [Email], [DiemTrungBinh]) VALUES (2, 2, N'Đoàn Văn', N'Hậu', CAST(N'1999-01-01' AS Date), NULL, N'hau1999@gmail.com', 4.65)
INSERT [dbo].[SinhVien] ([Id], [IdLop], [Ho], [Ten], [NgaySinh], [DiaChi], [Email], [DiemTrungBinh]) VALUES (3, 3, N'Nguyễn Văn', N'Toản', CAST(N'1999-10-09' AS Date), NULL, N'toan1999@gmail.com', NULL)
INSERT [dbo].[SinhVien] ([Id], [IdLop], [Ho], [Ten], [NgaySinh], [DiaChi], [Email], [DiemTrungBinh]) VALUES (4, 3, N'Hà Đức', N'Chinh', CAST(N'1997-02-15' AS Date), NULL, N'chinh1997@gmail.com', NULL)
INSERT [dbo].[SinhVien] ([Id], [IdLop], [Ho], [Ten], [NgaySinh], [DiaChi], [Email], [DiemTrungBinh]) VALUES (5, 1, N'Nguyễn Tiến', N'Linh', CAST(N'1997-03-26' AS Date), NULL, N'linh1997@gmail.com', NULL)
INSERT [dbo].[SinhVien] ([Id], [IdLop], [Ho], [Ten], [NgaySinh], [DiaChi], [Email], [DiemTrungBinh]) VALUES (6, 1, N'Huỳnh Tấn', N'Sinh', CAST(N'1998-01-30' AS Date), NULL, N'sinh1999@gmail.com', 8.15)
SET IDENTITY_INSERT [dbo].[SinhVien] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__SinhVien__A9D10534E013DD10]    Script Date: 11/28/2020 7:53:00 PM ******/
ALTER TABLE [dbo].[SinhVien] ADD  CONSTRAINT [UQ__SinhVien__A9D10534E013DD10] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SinhVien] ADD  CONSTRAINT [DF__SinhVien__NgaySi__5629CD9C]  DEFAULT (getdate()) FOR [NgaySinh]
GO
ALTER TABLE [dbo].[KetQua]  WITH CHECK ADD FOREIGN KEY([IdMonHoc])
REFERENCES [dbo].[MonHoc] ([Id])
GO
ALTER TABLE [dbo].[KetQua]  WITH CHECK ADD  CONSTRAINT [FK__KetQua__IdSinhVi__59063A47] FOREIGN KEY([IdSinhVien])
REFERENCES [dbo].[SinhVien] ([Id])
GO
ALTER TABLE [dbo].[KetQua] CHECK CONSTRAINT [FK__KetQua__IdSinhVi__59063A47]
GO
ALTER TABLE [dbo].[Lop]  WITH CHECK ADD  CONSTRAINT [FK__Lop__IdKhoa__3B75D760] FOREIGN KEY([IdKhoa])
REFERENCES [dbo].[Khoa] ([Id])
GO
ALTER TABLE [dbo].[Lop] CHECK CONSTRAINT [FK__Lop__IdKhoa__3B75D760]
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD  CONSTRAINT [FK__SinhVien__IdLop__5535A963] FOREIGN KEY([IdLop])
REFERENCES [dbo].[Lop] ([Id])
GO
ALTER TABLE [dbo].[SinhVien] CHECK CONSTRAINT [FK__SinhVien__IdLop__5535A963]
GO
ALTER TABLE [dbo].[KetQua]  WITH CHECK ADD CHECK  (([Diem]>=(0) AND [Diem]<=(10)))
GO
/****** Object:  StoredProcedure [dbo].[spud_AddKhoa]    Script Date: 11/28/2020 7:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spud_AddKhoa]
@Ten nvarchar(255),
@Phong Char(5)
as
begin
	insert into Khoa values
	(@Ten, @Phong)
end
GO
/****** Object:  StoredProcedure [dbo].[spud_AddKhoa_Multiple]    Script Date: 11/28/2020 7:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[spud_AddKhoa_Multiple]
@K Khoa readonly
as
begin
	insert into Khoa(Ten, Phong)
	select Ten, Phong from @K
end
GO
USE [master]
GO
ALTER DATABASE [QLSV] SET  READ_WRITE 
GO
