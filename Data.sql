USE [quanLiDienThoai]
GO
INSERT [dbo].[nhanvien] ([maNhanVien], [ten], [gioiTinh], [diaChi], [sdt]) VALUES (N'AD1', N'Văn Công Toàn', N'1', N'113/3 khu vực 8, Cần Thơ City', N'0778171871')
INSERT [dbo].[nhanvien] ([maNhanVien], [ten], [gioiTinh], [diaChi], [sdt]) VALUES (N'AD2', N'Nguyễn Đang Trường', N'1', N'', N'')
INSERT [dbo].[nhanvien] ([maNhanVien], [ten], [gioiTinh], [diaChi], [sdt]) VALUES (N'AD3', N'Huỳnh Anh Vũ', N'1', N'', N'')
INSERT [dbo].[taikhoan] ([username], [matKhau], [loaiTaiKhoan], [maNhanVien]) VALUES (N'admin', N'123', N'admin', N'AD1')
INSERT [dbo].[taikhoan] ([username], [matKhau], [loaiTaiKhoan], [maNhanVien]) VALUES (N'admin1', N'123', N'admin', N'AD2')
INSERT [dbo].[taikhoan] ([username], [matKhau], [loaiTaiKhoan], [maNhanVien]) VALUES (N'admin2', N'123', N'admin', N'AD3')
SET IDENTITY_INSERT [dbo].[hoaDon] ON 

INSERT [dbo].[hoaDon] ([maHoaDon], [maNhanVien], [ngayLap], [tongTien]) VALUES (1002, N'AD1', CAST(N'2019-10-27T17:28:22.000' AS DateTime), CAST(3700000 AS Decimal(18, 0)))
INSERT [dbo].[hoaDon] ([maHoaDon], [maNhanVien], [ngayLap], [tongTien]) VALUES (1003, N'AD1', CAST(N'2019-10-27T17:28:32.000' AS DateTime), CAST(18500000 AS Decimal(18, 0)))
INSERT [dbo].[hoaDon] ([maHoaDon], [maNhanVien], [ngayLap], [tongTien]) VALUES (1004, N'AD1', CAST(N'2019-10-27T17:31:44.000' AS DateTime), CAST(3700000 AS Decimal(18, 0)))
INSERT [dbo].[hoaDon] ([maHoaDon], [maNhanVien], [ngayLap], [tongTien]) VALUES (1005, N'AD1', CAST(N'2019-10-27T17:31:48.000' AS DateTime), CAST(3700000 AS Decimal(18, 0)))
INSERT [dbo].[hoaDon] ([maHoaDon], [maNhanVien], [ngayLap], [tongTien]) VALUES (1006, N'AD1', CAST(N'2019-10-27T18:29:04.000' AS DateTime), CAST(3700000 AS Decimal(18, 0)))
INSERT [dbo].[hoaDon] ([maHoaDon], [maNhanVien], [ngayLap], [tongTien]) VALUES (1007, N'AD1', CAST(N'2019-10-27T18:34:09.000' AS DateTime), CAST(28900000 AS Decimal(18, 0)))
INSERT [dbo].[hoaDon] ([maHoaDon], [maNhanVien], [ngayLap], [tongTien]) VALUES (1008, N'AD1', CAST(N'2019-10-27T18:34:51.000' AS DateTime), CAST(3700000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[hoaDon] OFF
INSERT [dbo].[nhoMatKhau] ([username], [matKhau]) VALUES (N'admin', N'123')
INSERT [dbo].[dienThoai] ([maSanPham], [ten], [thuongHieu], [moTa], [gia], [nhaCungCap]) VALUES (N'DT01', N'Xiaomi Redmi 4x', N'Xiaomi', N'', CAST(3700000 AS Decimal(18, 0)), N'.')
INSERT [dbo].[dienThoai] ([maSanPham], [ten], [thuongHieu], [moTa], [gia], [nhaCungCap]) VALUES (N'DT02', N'Xiaomi Redmi Note 4x', N'Xiaomi', N'', CAST(4700000 AS Decimal(18, 0)), N'.')
INSERT [dbo].[chiTietHoaDon] ([maHoaDon], [maSanPham], [soLuong]) VALUES (1002, N'DT01', 1)
INSERT [dbo].[chiTietHoaDon] ([maHoaDon], [maSanPham], [soLuong]) VALUES (1003, N'DT01', 5)
INSERT [dbo].[chiTietHoaDon] ([maHoaDon], [maSanPham], [soLuong]) VALUES (1004, N'DT01', 1)
INSERT [dbo].[chiTietHoaDon] ([maHoaDon], [maSanPham], [soLuong]) VALUES (1005, N'DT01', 1)
INSERT [dbo].[chiTietHoaDon] ([maHoaDon], [maSanPham], [soLuong]) VALUES (1006, N'DT01', 1)
INSERT [dbo].[chiTietHoaDon] ([maHoaDon], [maSanPham], [soLuong]) VALUES (1007, N'DT01', 4)
INSERT [dbo].[chiTietHoaDon] ([maHoaDon], [maSanPham], [soLuong]) VALUES (1007, N'DT02', 3)
INSERT [dbo].[chiTietHoaDon] ([maHoaDon], [maSanPham], [soLuong]) VALUES (1008, N'DT01', 1)
