

use QuanLyThuVien
go

alter table Employee
add RoleId int
go

create table [Roles](
	Id int identity(1,1) primary key,
	[Name] nvarchar(255),
	[CreatedTime] [datetime] NULL,
	[UpdatedTime] [datetime] NULL,
	[DeletedTime] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[DeletedBy] [int] NULL,
	[Notes] [ntext] NULL,
	[Status] [tinyint] NULL,
	[IsDelete] [bit] NULL,
)
go

create table [Permissions](
	Id int identity(1,1) primary key,
	[Name] nvarchar(255),
	[ControllerName] nvarchar(255),
	[ActionName] nvarchar(255),
	[CreatedTime] [datetime] NULL,
	[UpdatedTime] [datetime] NULL,
	[DeletedTime] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[DeletedBy] [int] NULL,
	[Notes] [ntext] NULL,
	[Status] [tinyint] NULL,
	[IsDelete] [bit] NULL,
)
go

create table [RolePermissions](
	Id int identity(1,1) primary key,
	RoleId int not null,
	PermissionId int not null
)
go

insert into Roles([Name], IsDelete) values
('Administrator', 0),
('Employee', 0)

insert into [Permissions]([Name], ControllerName, ActionName, IsDelete) values
(N'Trang chủ', 'Home', 'Index', 0),
(N'Về chúng tôi', 'Home', 'About', 0),
(N'Liên hệ', 'Home', 'Contact', 0),
(N'Danh sách NXB', 'Publishers', 'Index', 0),
(N'Chi tiết NXB', 'Publishers', 'Details', 0),
(N'Thêm NXB', 'Publishers', 'Create', 0),
(N'Sửa NXB', 'Publishers', 'Edit', 0),
(N'Xóa NXB', 'Publishers', 'Delete', 0),
(N'Danh sách NPH', 'Releasers', 'Index', 0),
(N'Chi tiết NPH', 'Releasers', 'Details', 0),
(N'Thêm NPH', 'Releasers', 'Create', 0),
(N'Sửa NPH', 'Releasers', 'Edit', 0),
(N'Xóa NPH', 'Releasers', 'Delete', 0)

insert into [RolePermissions](RoleId, PermissionId) values
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(1, 6),
(1, 7),
(1, 8),
(1, 9),
(1, 10),
(1, 11),
(1, 12),
(1, 13),

(2, 1),
(2, 2),
(2, 3),
(2, 4),
(2, 5),
(2, 9),
(2, 10)
go

update Employee set RoleId = 1 where Id = 5
go

insert into Employee(Code, FirstName, LastName, Email, [Password], Phone, Gender, RoleId, IsDelete) values
('E100002', N'Nguyễn Anh', N'Tuấn', 'tuanna@gmail.com', 'E81D80A7C8BE381022D431A024526B44', '0328937612', 0, 2, 0)
go

select * from [dbo].[Employee]