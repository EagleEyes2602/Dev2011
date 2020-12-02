
-- View --
-- 1 nguồn dữ liệu được tạo nên bởi các nguồn dữ liệu khác (Bảng vật lý, View khác)
-- tối đa 1024 cột
-- base từ các câu truy vấn

-- Điểm mạnh tính bảo mật
-- Được Compile trước => tốc độ được cải thiện
-- Có thể đánh index cho view để cải thiện tốc độ hơn nữa
-- Trong view muốn order by thì phải có top
-- Tạo View
create view vw_GetSinhVien
as
	select top 100 percent k.Ten as [TenKhoa]
		, l.Ten as [TenLop]
		, sv.Ho
		, sv.Ten
		, sv.Email
		, sv.NgaySinh
		, sv.DiaChi
		, sv.DiemTrungBinh
		, mh.Ten as [TenMonHoc]
		, kq.Diem
	from SinhVien sv
	join Lop l on sv.IdLop = l.Id
	join Khoa k on l.IdKhoa = k.Id
	join KetQua kq on kq.IdSinhVien = sv.Id
	join MonHoc mh on kq.IdMonHoc = mh.Id
	order by DiemTrungBinh desc
go

-- Sửa View
alter view vw_GetSinhVien
	with encryption
as
	select top 100 percent k.Ten as [TenKhoa]
		, sv.Ho
		, sv.Ten
		, sv.Email
		, sv.NgaySinh
		, sv.DiaChi
		, sv.DiemTrungBinh
		, mh.Ten as [TenMonHoc]
		, kq.Diem
	from SinhVien sv
	join Lop l on sv.IdLop = l.Id
	join Khoa k on l.IdKhoa = k.Id
	join KetQua kq on kq.IdSinhVien = sv.Id
	join MonHoc mh on kq.IdMonHoc = mh.Id
	order by DiemTrungBinh desc
go

-- Xóa View
drop view vw_GetSinhVien
go

select * from vw_GetSinhVien

-- Function --
-- Không thể Insert update delete table => select

-- Stored Procedure (Thủ tục nội tại) --
-- CRUD --

1997-01-12
yyyy-MM-dd

01/12/1997
MM/dd/yyyy

select CONVERT(varchar, NgaySinh, 101)
from SinhVien

select FORMAT(NgaySinh, 'dd/MM/yyyy')
from SinhVien
go
-- Function --
create function dbo.fn_ChanLe(
	@num int
)
returns nvarchar(MAX)
as
begin
	declare @str nvarchar(max)
	if(@num % 2 = 0)
	begin
		set @str = N'Chẵn'
	end
	else
	begin
		set @str = N'Lẻ'
	end
	return @str
end
go

-- alter

-- drop

-- encryption

select dbo.fn_ChanLe(10)

N'ahihi;đồ;ngốc'

N'ahihi'
N'đồ'
N'ngốc'

(input, startIndex, endIndex)

