create database quanLiDienThoai
go

use quanLiDienThoai
go

create table nhanvien
(
	maNhanVien varchar(10) primary key,
	ten nvarchar(100) not null,
	gioiTinh varchar(1) not null default '0', --1 la nam, 2 la nu, 0 la 0 xac dinh
	diaChi nvarchar(200),
	sdt varchar(20)
)
go

create table taikhoan
(
	username varchar(100) primary key,
	matKhau varchar(100) not null default '123',
	loaiTaiKhoan varchar(10) not null default 'NhanVien',
	maNhanVien varchar(10) references nhanVien(maNhanVien)
)
go



create table dienThoai
(
	maSanPham varchar(10) primary key,
	ten nvarchar(200) not null default N'Chưa đặt tên',
	thuongHieu nvarchar(50) not null,
	moTa nvarchar(500),
	gia decimal not null default 0,
	nhaCungCap nvarchar(500)
)
go

create table kho
(
	maSanPham varchar(10) references DienThoai(maSanPham) not null,
	soLuong int not null default 0,
	ngayNhap datetime not null default getdate(),
	tinhTrang nvarchar(100) not null default N'Bình thường'
)
go

create table hoaDon
(
	maHoaDon int identity(1,1) primary key,
	maNhanVien varchar(10) references nhanVien(maNhanVien) not null,
	ngayLap datetime not null default getdate(),
	tongTien decimal not null
)
go

create table chiTietHoaDon
(
	maHoaDon int references hoaDon(maHoaDon),
	maSanPham varchar(10) references dienThoai(maSanPham) not null,
	soLuong int not null default 1
)
go

create table nhoMatKhau
(
	username varchar(100) references taiKhoan(username) primary key,
	matKhau varchar(100)
)
go

create proc USP_Login
@userName varchar(100), @password varchar(100)
as
	Select * from taikhoan where username = @userName and matKhau = @password
go

create proc USP_SaveUser
@userName varchar(100), @password varchar(100)
as
	insert into nhoMatKhau 
	values (@userName, @password)
go

create proc USP_ChangePassword
@userName varchar(100), @newPassword varchar(100)
as
	update taikhoan set matKhau = @newPassword where username = @userName
go

create proc USP_AddAccount
@userName varchar(100), @password varchar(100), @loaiTaiKhoan varchar(10), @maNhanvien varchar(10)
as
	insert into taikhoan
	values ( @userName, @password, @loaiTaiKhoan, @maNhanVien)
go

create proc USP_UpdateAccount
@userName varchar(100), @password varchar(100), @loaiTaiKhoan varchar(10)
as
	update taikhoan set matKhau = @password, loaiTaiKhoan = @loaiTaiKhoan where username = @userName
go

create proc USP_DeleteAccount
@userName varchar(100)
as
	delete taikhoan where username = @userName
go

create proc USP_AddProduct
@idProduct varchar(10), @name nvarchar(200), @branch nvarchar(50), @description nvarchar(500), @price int, @supplier nvarchar(500)
as
	insert into dienthoai
	values (@idProduct, @name, @branch, @description, @price, @supplier)
go

create proc USP_UpdateProduct
@idProduct varchar(10), @name nvarchar(200), @branch nvarchar(50), @description nvarchar(500), @price int, @supplier nvarchar(500)
as
	update dienThoai set ten = @name, thuongHieu = @branch, moTa = @description, gia = @price, nhaCungCap = @supplier
	where maSanPham = @idProduct
go

create proc USP_DeleteProduct
@idProduct varchar(10)
as
	delete dienThoai where maSanPham = @idProduct
go

create proc USP_SaveBill
@maNhanVien varchar(10), @ngayLap datetime, @TongTien decimal
as
	insert into hoaDon
	values (@maNhanVien, convert(varchar, @ngayLap, 22), @TongTien)
go

create proc USP_SaveDetailBill
@idBill int, @idProduct varchar(10), @amount int
as
	insert into chiTietHoaDon
	values (@idBill, @idProduct, @amount)
go

create proc USP_AddEmloyees
@idEmloyees varchar(10), @name nvarchar(100), @Sex varchar(1), @Address nvarchar(200), @Phone varchar(20)
as
	insert into nhanvien
	values(@idEmloyees, @name, @Sex, @Address, @Phone)
go


create proc USP_UpdateEmloyees
@idEmloyees varchar(10), @name nvarchar(100), @Sex varchar(1), @Address nvarchar(200), @Phone varchar(20)
as
	update nhanvien
	set ten = @name, gioiTinh = @Sex, diaChi = @Address, sdt = @Phone
	where maNhanVien = @idEmloyees;
go

create proc USP_DeleteEmloyees
@idEmloyees varchar(10)
as
	delete nhanvien
	where maNhanVien = @idEmloyees;
go