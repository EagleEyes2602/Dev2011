create database [TestDev2011LM47]
go

use [TestDev2011LM47]
go

create table [TestTable](
	IDA int not null,
	IDB int not null,
	IDC int not null
)
go

alter table [TestTable]
	add primary key (IDA, IDB, IDC)
GO

create table [TestJob](
	Id int primary key identity(1,1),
	[Name] nvarchar(255) not null
)
GO

select * from [TestJob]

--insert into [TestJob]([Name]) values (N'VietQQ')

use QLSV
go
-- DML --
-- Insert -- Thêm dữ liệu vào bảng
-- insert thuần
insert into Khoa(Ten, Phong) values 
(N'Giáo dục mầm non', 'B501')
--,(N'Giáo dục mầm non', 'B501')
GO

-- insert select
insert into Khoa(Ten, Phong)
select Ten, Phong from Khoa

-- Update --
update SinhVien set
	DiemTrungBinh = 0
where DiemTrungBinh is null

-- Delete --
delete from Khoa
where id > 9

-- Select --

-- select *
select * from Khoa
go

select Id, Ten, Phong from Khoa
go

-- where
-- Loại toán tử
-- Số: =, >=, <=, >, <, !=, between
select Id, Ten, Phong 
from Khoa
where Id != 10

-- between
select Id, Ten, Phong 
from Khoa
where Id between 10 and 15

-- Text: 
-- ss tuyệt đối: =, !=
select Id, Ten, Phong
from Khoa
where Ten = N'Giáo dục mầm non'

-- ss tương đối: like, not like
-- %: 1 đoạn ký tự
select Id, Ten, Phong
from Khoa
where Ten like N'Giáo%'

-- _: 1 ký tự
select Id, Ten, Phong
from Khoa
where Ten like N'_ơ%'

select Id, Ten, Phong
from Khoa
where Ten like N'_____n%'

select Id, Ten, Phong
from Khoa
where Ten like N'_ơ%' or Ten like N'_ê%' or Ten like N'_ô%'

-- [cab]: vị trí đó có các ký tự trong [] hay k
select Id, Ten, Phong
from Khoa
where Ten like N'_[ơêô]%'

select Id, Ten, Phong
from Khoa
where Ten not like N'_[ơêô]%'


-- [^cab] = not [cab]
select Id, Ten, Phong
from Khoa
where Ten like N'_[^ơêô]%'

-- Toán tử so sánh: or, and, not
-- NULL: is null, is not null
select * 
from SinhVien
where DiemTrungBinh is not null

select * 
from SinhVien
where DiemTrungBinh is null

-- so sánh tập hợp: IN, CONTAIN, EXISTS
select * 
from SinhVien
where DiemTrungBinh in (0, 8)

-- Concat, Wildcard
select Ho + ' ' + Ten as [HoVaTen], *
from SinhVien

-- case when then end
select Ho + ' ' + Ten as [HoVaTen], NgaySinh, Email
, Case 
when DiemTrungBinh < 4 then N'Yếu'
when DiemTrungBinh >= 4 and DiemTrungBinh < 7 then N'Trung bình'
when DiemTrungBinh >= 7 and DiemTrungBinh < 8.5 then N'Khá'
when DiemTrungBinh >= 8.5 then N'Giỏi'
end as [XepLoai]
from SinhVien

-- JOIN: Left join, left outer join
-- right join, right outer join
-- full join, full outer join
-- inner join, join,
-- Có các loại join nào ???
select k.Id [idk1], l.IdKhoa [idk2], l.Id [idl], k.Ten as TenKhoa, Phong, l.Ten TenLop 
from Khoa k
join Lop l on k.Id = l.IdKhoa

select k.Id [idk1], l.IdKhoa [idk2], l.Id [idl], k.Ten as TenKhoa, Phong, l.Ten TenLop 
from Khoa k
left join Lop l on k.Id = l.IdKhoa

select k.Id [idk1], l.IdKhoa [idk2], l.Id [idl], k.Ten as TenKhoa, Phong, l.Ten TenLop 
from Khoa k
full join Lop l on k.Id = l.IdKhoa

-- Lấy thông tin sinh viên gồm: Tên khoa, Tên lớp, Tên sinh viên và các thông tin đính kèm(email,...), 
-- và điểm kèm tên môn học mà các sinh viên đó đã có

select k.Ten as [TenKhoa]
		, l.Ten as [TenLop]
		, sv.Ho + ' ' 
		--+ sv.Ten 
		as [HovaTen]
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

-- Order asc/desc
-- asc (default): tăng dần
-- desc: giảm dần

select k.Ten as [TenKhoa]
		, l.Ten as [TenLop]
		, sv.Ho + ' ' 
		--+ sv.Ten 
		as [HovaTen]
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

-- Lấy 3 sv có điểm trung bình cao nhất
-- top n => lấy n bản ghi đầu tiên
select top 3 k.Ten as [TenKhoa]
		, l.Ten as [TenLop]
		, sv.Ho + ' ' 
		--+ sv.Ten 
		as [HovaTen]
		, sv.Email
		, sv.NgaySinh
		, sv.DiaChi
		, sv.DiemTrungBinh
from SinhVien sv
join Lop l on sv.IdLop = l.Id
join Khoa k on l.IdKhoa = k.Id
order by DiemTrungBinh desc

-- top x percent => lấy ra x% bản ghi đầu tiên
select top 20 percent k.Ten as [TenKhoa]
		, l.Ten as [TenLop]
		, sv.Ho + ' ' 
		--+ sv.Ten 
		as [HovaTen]
		, sv.Email
		, sv.NgaySinh
		, sv.DiaChi
		, sv.DiemTrungBinh
from SinhVien sv
join Lop l on sv.IdLop = l.Id
join Khoa k on l.IdKhoa = k.Id
order by DiemTrungBinh desc

-- top n with ties
select top 3 with ties k.Ten as [TenKhoa]
		, l.Ten as [TenLop]
		, sv.Ho + ' ' 
		--+ sv.Ten 
		as [HovaTen]
		, sv.Email
		, sv.NgaySinh
		, sv.DiaChi
		, sv.DiemTrungBinh
from SinhVien sv
join Lop l on sv.IdLop = l.Id
join Khoa k on l.IdKhoa = k.Id
order by DiemTrungBinh desc

-- distinct
-- Lấy ra tên các lớp đã có sinh viên học
select distinct l.Ten as [TenLop]
from SinhVien sv
join Lop l on sv.IdLop = l.Id
join Khoa k on l.IdKhoa = k.Id

-- Hàm tính toán thống kê: Sum, Count, Max, Min, Avg
select IdLop, avg(DiemTrungBinh) as [DiemTrungBinhLop]
from SinhVien
group by IdLop

-- Having: lọc dữ liệu của các hàm tính toán thống kê
-- Lấp những lớp có [DiemTrungBinhLop] >= 6.0
select IdLop, avg(DiemTrungBinh) as [DiemTrungBinhLop]
from SinhVien
group by IdLop
having avg(DiemTrungBinh) >= 6.0
order by DiemTrungBinhLop desc

--select
--from (join)
--where lọc cột dữ liệu
--group by
--having lọc dữ liệu các hàm tính toán thống kê
--order by

-- 1. Tính điểm trung bình của từng sinh viên từ bảng kết quả
-- Thêm họ tên
select IdSinhVien, avg(Diem) as [DiemTrungBinh]
from KetQua kq
group by IdSinhVien

-- 2. Từ kết quả trên => update trường DiemTrungBinh vào bảng sinh viên
update sv set DiemTrungBinh = kqsv.DiemTrungBinh
from SinhVien sv
join (
	select IdSinhVien, avg(Diem) as [DiemTrungBinh]
	from KetQua kq
	group by IdSinhVien
) kqsv on sv.Id = kqsv.IdSinhVien

update SinhVien set DiemTrungBinh = kqsv.DiemTrungBinh
from (
	select IdSinhVien, avg(Diem) as [DiemTrungBinh]
	from KetQua kq
	group by IdSinhVien
) kqsv
where Id = kqsv.IdSinhVien

select * 
from SinhVien sv, Lop l
where sv.IdLop = l.Id

-- SubQuery: truy vấn con, truy vấn lồng
-- truy vẫn => dữ liệu (bảng)

-- 3. Cho biết sinh viên(Tên sinh viên, Tên khoa, Điểm Trung bình của sv đó) 
-- có điểm trung bình cao nhất của từng khoa với điểm trung bình lấy từ bảng KetQua

--update SinhVien set DiemTrungBinh = 7.5
--where Email = 'toan1999@gmail.com' or email = 'chinh1997@gmail.com'


-- PascalCase
-- camelCase
-- snake_case
-- ALL_CAP_SNAKE_CASE
-- kebab-case


-- Bảng tạm
-- 2 loại: #, ##
-- #: có phạm vi cho User hiện tại
-- ##: có phạm vi cho các User đang hoạt động trong DB

create table #Test(
	Id int
)

insert into #Test values (1)

select * from #Test
drop table #Test

-- Tạo biến

declare @param float

-- c1
--set @param = 10

-- c2
--set @param = (select sum(Diem) from KetQua)

-- c3
select @param = Diem from KetQua

select @param as [param]

-- Biến dạng bảng
declare @tbl as table (
	[Name] nvarchar(255)
)

insert into @tbl(Name) values (N'Nguyễn Anh'), (N'Nguyễn Quang')

--select * from @tbl

-- Union

--select [Name] as Ten from @tbl
--union
--select Ho from SinhVien

-- Union all
select [Name] as Ten from @tbl
union all
select Ho from SinhVien

