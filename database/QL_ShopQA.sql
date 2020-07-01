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

---Tạo bảng khách hàng
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

--Tạo bảng hàng hóa
Create table HangHoa
(
	MaHang int identity not null primary key,
	TenHang nvarchar(50) not null,
	SoLuong int not null,
	DonGiaGoc int not null,
	DonGiaBan int not null,
)
Go

--Thêm cột nhà cung cấp và ngày nhập vào bảng HangHoa
Alter table HangHoa add NhaCungCap nvarchar(100)
Go
Alter table HangHoa add NgayNhap date
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

--Tạo bảng chi tiết hóa đơn
Create table ChiTietHD
(
	MaHoaDon int not null REFERENCES HoaDon(MaHD),
	MaHang int not null REFERENCES HangHoa(MaHang),
	SoLuong int not null
)
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
INSERT INTO KhachHang values(N'Đức',0123456789,'Nam',N'Bình Dương',5,'02-08-2000','duc@gmail.com')
go

select *from KhachHang
go
---Nhập dữ liệu cho bảng nhân viên
insert into NhanVien values(N'Dương đẹp troai',N'Nam',N'Bình Dương',0396752611,'01-01-2000',N'Thu ngân',100000)
insert into NhanVien values(N'Trần Văn Dương',N'Nam',N'Bình Dương','0396752611','01-01-2000',N'Thu ngân','100000')
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