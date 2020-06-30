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
--Create table HoaDon
--(
--	MaHD int identity not null primary key,
--	MaNV int not null REFERENCES NhanVien(MaNV),
--	MaHang char(10) not null REFERENCES HangHoa(MaHang),
--	MaKH int REFERENCES KhachHang(MaKH),
--	NgayBan datetime not null,
--	TongTien int not null
--)
--Go

----Tạo bảng chi tiết hóa đơn
--Create table ChiTietHD
--(
--	MaHD int identity not null REFERENCES HoaDon(MaHD),
--	MaHang char(10) not null REFERENCES HangHoa(MaHang),
--	SoLuong int not null,
--)
--Go

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
Alter table Account add MaNV int
Go

--Thêm khóa ngoại cho bảng Account và NhanVien
Alter table Account add constraint FK_Account foreign key(MaNV) references NhanVien(MaNV)
Go

--Thêm tài khoản
insert into Account values(N'Trần Văn Dương','admin','admin',N'Nhân viên',1)
insert into Account values(N'Đặng Văn Phúc','phuc','phuc',N'Nhân viên',2)
insert into Account values(N'Nguyễn Trọng Hiệp','hip','hip',N'Nhân viên',3)
insert into Account values(N'Phan Văn Tuân','tuan','tuan',N'Bảo vệ',4)
go
--Sửa tài khoản
update Account set fullname=N'Duong',usename=N'admin',pass=N'admin',chucvu=N'Nhân viên',MaNV='1' where id=4
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
insert into NhanVien values(N'Trần Văn Dương',N'Nam',N'Trừ Văn Thố, Bàu Bàng, Bình Dương',0396752611,'07-11-1999')
insert into NhanVien values(N'Nguyễn Trọng Hiệp',N'Nam',N'Bến Cát, Bình Dương',0123456789,'07-11-2000')
insert into NhanVien values(N'Đăng Văn Phúc',N'Nam',N'Lai Uyên, Bàu Bàng, Bình Dương',02123345,'07-11-1999')

go
select *from NhanVien

---Nhập dữ liệu cho bảng hàng hóa
--insert into HangHoa values('HH01',N'Tee-Shirt',10,100000,150000,N'Streetgang','06-23-2020')

select n.TenNhanVien,a.id,a.usename,a.pass,a.chucvu
from Account a,NhanVien n
where a.chucvu=n.chucvu

select *from Account a where a.usename='admin' and a.pass='admin'