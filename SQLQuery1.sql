create database quanLiDienThoai
go

use quanLiDienThoai
go

create table taikhoan
(
	username varchar(100) primary key,
	matKhau varchar(100) not null default '123',
	loaiTaiKhoan varchar(10) not null default 'NhanVien',
	maNhanVien varchar(10) references nhanVien(maNhanVien),
	maAdmin varchar(10) references ad_min(maAdmin)
)
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

create table ad_min
(
	maAdmin varchar(10) primary key,
	maNhanVien varchar(10) references nhanvien(maNhanVien),
	ten nvarchar(100) not null,
	gioiTinh varchar(1) not null default '0', --1 la nam, 2 la nu, 0 la 0 xac dinh
	diaChi nvarchar(200),
	sdt varchar(20)
)
go

create table dienThoai
(
	maSanPham varchar(10) primary key,
	ten nvarchar(200) not null default N'Chưa đặt tên',
	thuongHieu nvarchar(50) not null,
	moTa nvarchar(500),
	gia int not null default 0,
	nhaCungCap nvarchar(500)
)
go

create table kho
(
	maSanPham varchar(10) references DienThoai(maSanPham) not null,
	soLuong int not null default 0,
	tinhTrang nvarchar(100) not null default N'Bình thường'
)
go

create table hoaDon
(
	maHoaDon varchar(10) primary key,
	maNhanVien varchar(10) references nhanVien(maNhanVien) not null,
	ngayLap date not null default getdate(),
	tongTien int not null
)
go

create table chiTietHoaDon
(
	maHoaDon varchar(10) references hoaDon(maHoaDon) primary key,
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
@userName varchar(100), @password varchar(100), @loaiTaiKhoan varchar(10), @
as
	insert into taikhoan
	values ( @userName, @password, @loaiTaiKhoan)
go

create proc USP_UpdateAccount
@userName varchar(100), @password varchar(100), @loaiTaiKhoan varchar(10)
as
	update taikhoan set matKhau = @password, loaiTaiKhoan = @loaiTaiKhoan where username = @userName
go

create proc USP_DeleteAccount
@userName varchar(100)
as
	delete ad_min where username = @userName
	delete nhanvien where username = @userName
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

create proc USP_ChangeEmloyees
@username varchar(100), @Name nvarchar(100), @sex varchar(1), @Address nvarchar(200), @phoneNumber varchar(20)
as
	update nhanvien set ten = @Name, gioiTinh = @sex, diaChi = @Address, sdt = @phoneNumber
	where username = @username
go

create proc USP_ChangeAdmin
@username varchar(100), @Name nvarchar(100), @sex varchar(1), @Address nvarchar(200), @phoneNumber varchar(20)
as
	update ad_min set ten = @Name, gioiTinh = @sex, diaChi = @Address, sdt = @phoneNumber
	where username = @username
go