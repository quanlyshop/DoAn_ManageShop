CREATE DATABASE QL_ShopQuanAo
GO

USE QL_ShopQuanAo
GO

---Tạo bảng nhân viên
CREATE TABLE NhanVien
(
	MaNV INT identity NOT NULL PRIMARY KEY,
	TenNhanVien NVARCHAR(100) not null,
	GioiTinh NVARCHAR(5),
	DiaChi NVARCHAR(100),
	SDT varchar(10) not null,
	NamSinh date not null,
)
GO

Alter table NhanVien add chucvu nvarchar(50)
Alter table NhanVien alter column LuongCoBan int
Go
drop check CK_SDT
ALTER TABLE NhanVien ADD CONSTRAINT CK_SDT CHECK 
(LEN(SDT)=10)
go

ALTER TABLE NhanVien
ADD CONSTRAINT _SDT UNIQUE (SDT);
go

CREATE TABLE KhachHang
(
	MaKH int identity not null primary key,
	TenKH nvarchar(100),
	SDT varchar(10) not null,
	GioiTinh NVARCHAR(5),
	DiaChi nvarchar(100),
	SoDiem varchar(10) not null,
	NamSinh date not null,
	Email nvarchar(50)
)
GO
--Alter Table KhachHang
--	Add Constraint ck_DienThoaiKH 
--	Check (len(SDT)=10 or len(SDT)=11)
--Rang buoc sdt co 10 so
--ALTER TABLE KhachHang ADD CONSTRAINT CK_SDTKhachHang CHECK (LEN(SDT)=10)
--go
--ALTER TABLE KhachHang
--ADD CONSTRAINT _SDTKH UNIQUE (SDT)
--go


--Tạo bảng hàng hóa
Create table SanPham
(
	MaSP int identity not null primary key,
	TenSP nvarchar(50) not null,
	SoLuong int not null,
	DonGiaGoc int not null,
	DonGiaBan int not null,
	Size char(3) not null,
	NhaSX nvarchar(100) not null,
	NgaySX date
)
Go

--Tạo bảng hóa đơn
Create table HoaDon
(
	MaHD int identity not null primary key,
	MaNV int not null REFERENCES NhanVien(MaNV),
	MaKH int REFERENCES KhachHang(MaKH),
	NgayBan datetime not null,
	TongTien int not null
)
Go

--Thêm cột TenSanPham, SoLuong, DonGia vào bảng HoaDon
Alter table HoaDon add TenSanPham nvarchar(100)
alter table HoaDon add SoLuong int
Alter table HoaDon add DonGia int
Go

--Tạo bảng tài khoản
create table Account
(
	id int identity not null primary key,
	fullname nvarchar(100),
	usename varchar(50),
	pass varchar(50),
)
Go

--Thêm cột chức vụ và MaNV vào bảng account
Alter table Account add chucvu nvarchar(50)
Go

--Thêm khóa ngoại cho bảng Account và NhanVien
Alter table Account add constraint FK_Account foreign key(MaNV) references NhanVien(MaNV)
Go

--Thêm tài khoản
insert into Account values(N'Trần Văn Dương','admin','admin',N'Nhân viên')
insert into Account values(N'Đặng Văn Phúc','phuc','phuc',N'Nhân viên')
insert into Account values(N'Nguyễn Trọng Hiệp','hip','hip',N'Nhân viên')
insert into Account values(N'Phan Văn Tuân','tuan','tuan',N'Bảo vệ')
go

--Sửa tài khoản
update Account set fullname=N'Duong',usename=N'admin',pass=N'admin',chucvu=N'Nhân viên' where id=4

--Truy vấn tài khoản
select *
from Account 
where usename='admin' and pass='admin'

---Thêm khách hàng
INSERT INTO KhachHang values(N'Hùng',0123456789,'Nam',N'Bình Dương',10,'01-01-2000','hung@gmail.com')
INSERT INTO KhachHang values(N'Đức Phúc',0396752611,'Nam',N'Bình Dương',5,'02-08-2000','duc@gmail.com')
go


select *from KhachHang
go
---Nhập dữ liệu cho bảng nhân viên
insert into NhanVien values(N'Trần Văn Dương',N'Nam',N'Bình Dương','0396752614','01-01-2000',N'Thu ngân','100000')
insert into NhanVien values(N'Bùi Anh Tuấn',N'Nam',N'Bình Dương','0396752612','01-01-1990',N'Thu ngân','1000000')
go

--update NhanVien
update NhanVien set TenNhanVien=N'Đặng Văn Phúc',GioiTinh=N'Nam',DiaChi=N'Lai Uyên Bình Dương',SDT='0396752611',NamSinh='01-01-2000',chucvu=N'Giữ xe',LuongCoBan='10000' where MaNV='7'
select *from NhanVien

---Nhập dữ liệu cho bảng hàng hóa
--insert into HangHoa values('HH01',N'Tee-Shirt',10,100000,150000,N'Streetgang','06-23-2020')

select n.TenNhanVien,a.id,a.usename,a.pass,a.chucvu
from Account a,NhanVien n
where a.chucvu=n.chucvu

select *from Account a where a.usename='admin' and a.pass='admin'
go

---Thêm dữ liệu cho bảng hàng hóa
insert into SanPham values(N'Áo thun','10','100000','200000','M',N'Yame','7-7-2020')
insert into SanPham values(N'Áo Sơ mi','5','200000','450000','X',N'HiYu','8-7-2020')
insert into SanPham values(N'Local brand','10','200000','500000','M',N'Camper','9-7-2020')
insert into SanPham values(N'Hoodie','10','50000','220000','M',N'Camper','10-7-2020')
insert into SanPham values(N'Quần Short','10','50000','250000','M',N'GoGi','11-7-2020')
go

---Thêm dữ liệu bảng hóa đơn
insert into HoaDon values('3','9','8-7-2020','50000',N'Hoodie','1','50000')
go

---Search KhachHang bằng tên khách hàng, mã khách hàng, số điện thoại hoặc năm sinh
create proc SearchKhachHang(@ten nvarchar(100))
as
begin 
	select *
	from KhachHang kh 
	where kh.TenKH like '%' + @ten + '%' Or kh.MaKH like '%' + @ten + '%' or kh.SDT like '%' + @ten + '%' or kh.NamSinh like '%' + @ten + '%'
end
go

exec SearchKhachHang N'0244447766'


select *from HoaDon
select *from SanPham
select *from NhanVien
select *from KhachHang
select *from Account
---Tính tổng tiền
go
create function TongTien (@maHD int)
returns int
as
	begin
		declare @TongTien int
		set @TongTien = (select (DonGia*SoLuong)
		from HoaDon
		where HoaDon.MaHD=@maHD)
		return @TongTien
	end
go

---Cập nhật số lượng hàng hóa khi tạo hóa đơn
--create trigger trg_SoLuong on SanPham
--after insert,update,delete
--as
--begin transaction
--	declare @MaHD int
--	declare @SoLuong int
--	if exists (select *from inserted)
--			select @MaHD=


--go

--- Trigger ràng buộc đơn giá phải lớn hơn giá gốc
create trigger trg_DonGia on SanPham
after insert,update
as
begin transaction
	declare @MaSP nvarchar(30)
	declare @DonGiaBan int
	declare @DonGiaGoc int
	select @DonGiaBan=DonGiaBan,@MaSP=MaSP from inserted
	select @MaSP=MaSP,@DonGiaBan=DonGiaBan,@DonGiaGoc=DonGiaGoc from SanPham where Masp=@MaSP
	if(@DonGiaBan<@DonGiaGoc)
	begin
			raiserror(N'Đơn giá bán phải lớn hơn đơn giá gốc',0,1)
			rollback transaction		
		end
	else
		commit transaction
		--drop trigger trg_DonGia
go

---Tìm kiếm sản phẩm
create proc Search_SanPham(@Ten nvarchar(100))
as
begin 
	select *
	from SanPham sp 
	where sp.TenSP like '%' + @Ten + '%' or sp.MaSP like '%' + @Ten + '%' or sp.NhaSX like '%' + @Ten + '%' or sp.Size like '%' + @Ten + '%'
end
go

exec Search_SanPham N'Áo thun'
go

---Tìm kiếm hóa đơn
create proc Search_HoaDon(@Ten nvarchar(100))
as
begin 
	select *
	from HoaDon hd 
	where hd.MaHD like '%' + @Ten + '%' Or hd.MaKH like '%' + @Ten + '%' or hd.NgayBan like '%' + @Ten + '%' or hd.TenSanPham like '%' + @ten + '%' or hd.TongTien like '%' + @Ten + '%'
end
go

exec Search_HoaDon N'7'
go

---Get HoaDon
create proc GetHoaDon(@MaHD int)
as
begin
	select hd.MaHD,nv.TenNhanVien, hd.TenSanPham,hd.DonGia,hd.SoLuong,hd.TongTien,hd.NgayBan 
	from HoaDon hd, NhanVien nv
	where @MaHD=hd.MaHD and hd.MaNV=nv.MaNV
end
go

exec GetHoaDon '7'
go

---Lấy danh sách sản phẩm
create proc GetListSanPham
as
	begin
		select *
		from SanPham
end
go

exec GetListSanPham
go