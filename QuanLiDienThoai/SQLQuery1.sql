create table taikhoan
(
	taikhoan varchar(50) primary key,
	matkhau varchar(50) not null default 1,
	loaiTaiKhoan char(10) not null default 'thuong'
)
go

create table sanpham
(
	maSanPham varchar(10) primary key,
	ten nvarchar(100) not null default N'Chưa đặt tên',
	donGia int not null,
)
go

create table nhanvien
(
	maNhanVien varchar(10) primary key,
	ten nvarchar(100) not null default N'Chưa đặt tên',
	tuoi tinyint,
	sdt varchar(20)
)
go

create table kho
(
	maSanPham varchar(10) foreign key references sanpham(maSanPham),
	soLuong int not null default 1,
)
go

create table hoadon
(
	maHoaDon varchar(10) primary key,
	ngayLap getdate,
	maNhanVien varchar(10) foreign key references nhanvien(maNhanVien)
)
go

create table chitietHD
(
	maSanPham varchar(10) foreign key references sanpham(maSanPham),
	donGia int not null,
	soLuong int not null default 1,
)
go
