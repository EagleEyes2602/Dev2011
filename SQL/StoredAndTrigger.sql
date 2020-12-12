-- Stored Proceudure --
-- aspx .Net
-- jsp Jar
-- Test: UnitTest, SIT, UAT

-- Deploy: Biên dịch code, mã hóa => .dll, .jar
-- GoLive => Production (Lỗi)

-- Hàm xử lý nghiệp vụ
-- Có input, output
-- input (in/out)
-- VD: phân trang => số bản ghi thỏa mãn điều kiện, tổng số lượng bản ghi

-- Create
alter procedure spud_GetTopStudentByClass
	@top int = 1,
	@totalRecord int out
as
begin
	select ttsv.Ten as [TenKhoa]
		, ttsv.[TenLop] as [TenLop]
		, ttsv.Ho
		, ttsv.Ten
		, ttsv.Email
		, ttsv.NgaySinh
		, ttsv.DiaChi
		, ttsv.DTB
	from (
		select k.Ten as [TenKhoa]
				, l.Ten as [TenLop]
				, sv.Ho
				, sv.Ten
				, sv.Email
				, sv.NgaySinh
				, sv.DiaChi
				, DTBSV.DTB
				, ROW_NUMBER() over(partition by l.Id order by DTB desc) rn
		from SinhVien sv
		join Lop l on sv.IdLop = l.Id
		join Khoa k on l.IdKhoa = k.Id
		join (
			select kq.IdSinhVien, AVG(kq.Diem) as [DTB]
			from KetQua kq
			group by kq.IdSinhVien
		) DTBSV on sv.Id = DTBSV.IdSinhVien
	) ttsv
	where ttsv.rn <= @top

	select @totalRecord = count(1)
	from (
		select k.Ten as [TenKhoa]
				, l.Ten as [TenLop]
				, sv.Ho
				, sv.Ten
				, sv.Email
				, sv.NgaySinh
				, sv.DiaChi
				, DTBSV.DTB
				, ROW_NUMBER() over(partition by l.Id order by DTB desc) rn
		from SinhVien sv
		join Lop l on sv.IdLop = l.Id
		join Khoa k on l.IdKhoa = k.Id
		join (
			select kq.IdSinhVien, AVG(kq.Diem) as [DTB]
			from KetQua kq
			group by kq.IdSinhVien
		) DTBSV on sv.Id = DTBSV.IdSinhVien
	) ttsv
	where ttsv.rn <= @top
end
go

declare @total int
exec spud_GetTopStudentByClass @totalRecord=@total out
select @total
go

-- Alter

-- Drop
drop procedure spud_GetTopStudentByClass
go

-- Trigger --
-- Bộ lọc dữ liệu
-- được đặt phía trước hoặc phía sau bảng

-- Insert, Update, Delete
-- Inserted, deleted

-- Instead of: Tiền xử lý. VD: Kiểm tra tính đúng đắn (validate) dữ liệu
-- Viết trigger cho bảng KetQua
-- Kiểm tra dữ liệu đầu vào (Diem >=0 && Diem <= 10)
-- Insert, Update
-- Instead of

-- Create, Alter, Drop
alter trigger trg_ValidateKetQua
on KetQua
instead of insert, update
as
begin
	if exists (select 1 from inserted where Diem < 0 or Diem > 10)
	begin
		declare @error nvarchar(255) = N'Lỗi rồi: Diem < 0 or Diem > 10'
		print(@error)
		--raiserror(@error, 16, 1)
	end
	else
	begin
		print(N'Thành công')
		insert into KetQua(IdMonHoc, IdSinhVien, Diem)
		select IdMonHoc, IdSinhVien, Diem from inserted
	end
end
go

create trigger trg_ValidateUpdateKetQua
on KetQua
instead of update
as
begin
	if exists (select 1 from inserted where Diem < 0 or Diem > 10)
	begin
		declare @error nvarchar(255) = N'Lỗi rồi: Diem < 0 or Diem > 10'
		print(@error)
		--raiserror(@error, 16, 1)
	end
	else
	begin
		print(N'Thành công')
		insert into KetQua(IdMonHoc, IdSinhVien, Diem)
		select IdMonHoc, IdSinhVien, Diem from inserted
	end
end
go

drop trigger trg_ValidateUpdateKetQua
go

insert into KetQua(IdMonHoc, IdSinhVien, Diem)
values 
(3, 1, 6), 
(3, 2, 8), 
(3, 3, 8.4)

update KetQua set Diem = -1
where id = 1

select * from KetQua

-- VD: Instead of delete. Xóa dữ liệu quan hệ trước khi xóa dữ liệu chính.

-- FOR: Hậu xử lý. 
-- VD: insert dữ liệu vào bảng KetQua và update trường điểm trung bình trong bảng SinhVien

alter trigger trg_UpdateDTBSinhVien
on KetQua
for insert, update, delete
as
begin
	update sv
		set DiemTrungBinh = (select avg(Diem) from KetQua where IdSinhVien = sv.Id)
	from SinhVien sv
	where sv.Id in (select i.IdSinhVien from inserted i)
	or sv.Id in (select d.IdSinhVien from deleted d)
	--exists (select 1 from inserted i where sv.Id = i.IdSinhVien)
	--or exists (select 1 from deleted i where sv.Id = i.IdSinhVien)
end
go

select * from SinhVien

select * from KetQua
delete KetQua where id > 12

update KetQua set Diem = 10
where id = 12


-- Type --
-- Tương tự class trong C#, Java
-- 1 kiểu dữ liệu do người dùng định nghĩa

create type TypeKetQua as table(
	[IdSinhVien] int,
	[IdMonHoc] int,
	[Diem] float
)

declare @DanhSachDiem TypeKetQua
insert into @DanhSachDiem
values 
(1, 0, 6),
(2, 0, 8),
(3, 0, 8.4)

select * from @DanhSachDiem

-- Insert sinh viên kèm danh sách điểm của sinh viên đó
-- 1.Insert thông tin sinh viên
-- 2.Insert danh sách đầu điểm của sinh viên đó
alter proc spud_InsertSinhvienVaKetqua
	@IdLop int,
	@Ho nvarchar(255),
	@Ten nvarchar(255),
	@NgaySinh date,
	@DiaChi nvarchar(255),
	@Email varchar(100),
	@DanhSachDiem TypeKetQua readonly
as
begin
	begin tran
	begin try
		-- 1.Insert thông tin sinh viên
		insert into SinhVien(IdLop, Ho, Ten, NgaySinh, DiaChi, Email)
		values(@IdLop, @Ho, @Ten, @NgaySinh, @DiaChi, @Email)

		declare @IdSinhVien int = SCOPE_IDENTITY()
		print(@IdSinhVien)
		-- 2.Insert danh sách đầu điểm của sinh viên đó
		insert into KetQua (IdSinhVien, IdMonHoc, Diem)
		select @IdSinhVien, IdMonHoc, Diem from @DanhSachDiem

	commit tran
	end try
	begin catch
		rollback
		declare @error_message nvarchar(max) = Error_Message()
		raiserror(@error_message, 16, 1)
	end catch
end
go


declare @DanhSachDiem TypeKetQua
insert into @DanhSachDiem
values 
(0, 1, 7),
(0, 2, 6.4),
(0, 3, 8.2)

exec spud_InsertSinhvienVaKetqua 3, N'Nguyễn', N'Hoàng', '2001-04-11', N'Hà Nội', N'hoangn@gmail.com', @DanhSachDiem
go

select * from SinhVien
select * from KetQua
select * from MonHoc
