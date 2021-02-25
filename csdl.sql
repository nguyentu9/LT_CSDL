﻿create database QuanLyKho
go
use QuanLyKho
go

create table TAIKHOAN (
	TenDangNhap varchar(20) primary key(TenDangNhap),
	MatKhau varchar(50)
);
go
create table KHACHHANG(
	MaKH int primary key(MaKH) identity,
	TenKH nvarchar(50),
	DiaChi nvarchar(100),
	SDT varchar(11)
);
go
create table NHANVIEN(
	MaNV int primary key(MaNV) identity,
	TenNV nvarchar(50),
	DiaChi nvarchar(100),
	SDT varchar(11)
);
go
create table HOADON(
	MaHD int primary key(MaHD) identity,
	MaKH int,
	MaNV int

	foreign key(MaKH) references KHACHHANG(MaKH),
	foreign key(MaNV) references NHANVIEN(MaNV)
);
go

create table SANPHAM(
	MaSP int primary key(MaSP) identity,
	TenSP nvarchar(30) unique,
	GiaTien int
);
go
create table CTHD(
	MaHD int primary key(MaHD, MaSP),
	MaSP int,
	NgayLap date,
	SoLuong int

	foreign key(MaHD) references HOADON(MaHD),
	foreign key(MaSP) references SANPHAM(MaSP),
);
go

create table KHO(
	MaSP int primary key(MaSP),
	SoLuongTonKho int
	foreign key(MaSP) references SANPHAM(MaSP)
);
go

create table PHIEUNHAP(
	MaPhieu int primary key(MaPhieu) identity,
	MaSP int,
	SoLuong int

	foreign key(MaSP) references SANPHAM(MaSP)
);
go

create table PHIEUXUAT(
	MaPhieu int primary key(MaPhieu) identity,
	MaSP int,
	SoLuong int

	foreign key(MaSP) references SANPHAM(MaSP)
);
go


insert into KHACHHANG (TenKH, DiaChi, SDT) values ('Lanita Goschalk', '472 Barby Road', '6676004869'),
												  ('Kamilah Give', '831 Bluejay Lane', '5106659925'),
												  ('Jacklyn Mogridge', '43 La Follette Alley', '5237552506'),
												  ('Caye Windmill', '5 Magdeline Plaza', '6528323117'),
												  ('Grazia Kenwell', '00433 John Wall Road', '4158775732');

insert into NHANVIEN ( TenNV, DiaChi, SDT) values ( 'Jeno Dyball', '94 Jenifer Avenue', '5383342690'),
												  ( 'Henderson Lundie', '4177 Division Court', '7243321364'),
												  ( 'Katya Swatridge', '34 Kensington Center', '1014299537'),
												  ( 'Allsun Edmand', '37 Springs Way', '6921172446'),
												  ( 'Nilson Teas', '92 Carey Alley', '5784101248');

insert into SANPHAM (TenSP, GiaTien) values ('Energy Drink - Redbull 355ml', 72489),
											('Tomatoes', 93457),
											('Bagel - Ched Chs Presliced', 56419),
											('Cheese - Pied De Vents', 64297),
											('Wiberg Super Cure', 27729),
											('Table Cloth 54x72 Colour', 42034),
											('Honey - Liquid', 76140),
											('Ice Cream - Vanilla', 20796),
											('Mushroom - Shitake, Fresh', 14729),
											('Pears - Bosc', 38843);

insert into KHO values (1, 200), 
					   (2, 200),
					   (3, 200),
					   (4, 200),
					   (5, 200),
					   (6, 200),
					   (7, 200),
					   (8, 200),
					   (9, 200),
					   (10, 200);

insert into HOADON values(1, 1),
						 (2, 1),
						 (3, 3),
						 (4, 2),
						 (5, 1);

insert into CTHD (MaHD, MaSP, NgayLap, SoLuong) values (1, 10, '12/24/2020', 142);
insert into CTHD (MaHD, MaSP, NgayLap, SoLuong) values (2, 5, '6/18/2020', 113);
insert into CTHD (MaHD, MaSP, NgayLap, SoLuong) values (3, 9, '12/22/2020', 174);
insert into CTHD (MaHD, MaSP, NgayLap, SoLuong) values (4, 9, '2/4/2021', 112);
insert into CTHD (MaHD, MaSP, NgayLap, SoLuong) values (5, 6, '1/3/2021', 44);