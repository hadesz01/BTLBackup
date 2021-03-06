use master 
go
if(exists(select * from sysdatabases where name='QUANLYHS'))
drop database QUANLYHS
go
create database QUANLYHS 



go
use QUANLYHS
go
create table MonHoc
(
MaMon nvarchar(100) not null primary key,
TenMon nvarchar(200) not null,
SoTiet int not null
)
create table CanBoGiaoVien
(
MaCanBoGiaoVien nvarchar(100) not null primary key,
HoTen nvarchar(200) not null,
DiaChi nvarchar(200) not null,
SoDienThoai nvarchar(101) not null,
TaiKhoan nvarchar(200) not null,
MatKhau nvarchar(80) not null,
LoaiTaiKhoan nvarchar(100) not null
)
create table Lop
(
MaLop nvarchar(100) not null primary key,
TenLop nvarchar(200) not null,
NienKhoa nvarchar(100) not null,
SiSo int not null,
GiaoVienChuNhiem nvarchar(100) not null,
constraint GVCN_Lop_CBGV foreign key(GiaoVienChuNhiem) references CanBoGiaoVien(MaCanBoGiaoVien)
)
create table HoSoHocSinh
(
MaHocSinh nvarchar(100) not null primary key,
HoTen nvarchar(200) not null,
NgaySinh datetime not null,
GioiTinh nvarchar(50) not null,
DiaChi nvarchar(200) not null,
DiemVaoTruong float not null,
HoTenBoMe nvarchar(200) not null,
SoDienThoai nvarchar(110) not null,
MaLop nvarchar(100) not null,
constraint Malop_HSHS_Lop foreign key (MaLop) references Lop(MaLop)
)
create table Diem
(
MaHocSinh nvarchar(100) not null,
MaMonHoc nvarchar(100) not null,
DiemTB_Ky1 float  null,
DiemTB_Ky2 float  null,
primary key(MaHocSinh,MaMonHoc),
constraint MaHS_Diem_HSHS foreign key (MaHocSinh) references HoSoHocSinh(MaHocSinh),
constraint MaMon_Diem_Mon foreign key (MaMonHoc) references MonHoc(MaMon)
)
create table PhanCongGiangDay
(
MaLop nvarchar(100) not null,
MaMon nvarchar(100) not null,
MaCanBoGiaoVien nvarchar(100) not null,
NgayPhanCong datetime not null,
primary key (MaLop,MaMon,MaCanBoGiaoVien),
constraint Lop_PhanCong foreign key (MaLop) references Lop(MaLop),
constraint CBGV_PhanCong foreign key (MaCanBoGiaoVien) references CanBoGiaoVien(MaCanBoGiaoVien),
constraint Mon_PhanCong foreign key (MaMon) references MonHoc(MaMon)
)
go
delete CanBoGiaoVien

select *from MonHoc

--mon
insert into MonHoc values ('mon1','lap trinh window','45')
insert into MonHoc values ('mon2','lap trinh nhung','45')
insert into MonHoc values ('mon3','lap trinh web','45')
insert into MonHoc values ('mon4','lap trinh android','45')
insert into MonHoc values ('mon5','lap trinh app','45')

--can bo giao vien

insert into CanBoGiaoVien values ('gv1','nguyen thi t','ha noi','012345678','nguyen thi','1','gv')
insert into CanBoGiaoVien values ('gv2','nguyen thi b','ha noi','012345678','nguyen thu','1','gv')
--insert into CanBoGiaoVien values ('gv3','nguyen thi c','ha noi','012345678','nguyen thi c','1','gv')
insert into CanBoGiaoVien values ('admin1','admin','ha noi','012345678','admin','admin','admin')
--delete from CanBoGiaoVien
--Lop
insert into Lop values ('lop1','cong  nghe thong tin','2018-2019','3','gv1')
insert into Lop values ('lop2','khoa hoc may tin','2018-2019','3','gv1')
insert into Lop values ('lop3','ky thuat phan mem','2018-2019','3','gv1')
insert into Lop values ('lop4','dien tu','2018-2019','3','gv2')
insert into Lop values ('lop5','tu dong hoa','2018-2019','3','gv2')
insert into Lop values ('lop6','tieng anh','2017-2018','3','gv2')
--insert into Lop values ('lop7','tieng nhat','2016-2017','3','gv1')
--delete Lop
select * from Lop
---ho so hoc sinh

insert into HoSoHocSinh values ('hs1','do duc vinh','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop1')
insert into HoSoHocSinh values ('hs2','nguyen duc anh','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop1')
insert into HoSoHocSinh values ('hs4','nguyen duc ba','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop1')
insert into HoSoHocSinh values ('hs3','do van bang','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop2')
insert into HoSoHocSinh values ('hs5','dao duc ngao','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop2')
insert into HoSoHocSinh values ('hs6','do duc tran','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop2')
insert into HoSoHocSinh values ('hs7','do duc trang','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop3')
insert into HoSoHocSinh values ('hs8','nguyen duc hoa','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop3')
insert into HoSoHocSinh values ('hs9','do duc qua','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop4')
insert into HoSoHocSinh values ('hs10','tran duc com','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop4')
insert into HoSoHocSinh values ('hs11','ly duc canh','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop5')
insert into HoSoHocSinh values ('hs12','ton duc vi','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop5')
insert into HoSoHocSinh values ('hs13','ta duc ngot','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop6')
insert into HoSoHocSinh values ('hs14','la duc nhat','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop6')
insert into HoSoHocSinh values ('hs15','tu duc nhi','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop4')
insert into HoSoHocSinh values ('hs16','truong duc the','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop5')
insert into HoSoHocSinh values ('hs17','trieu duc gioi','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop6')
insert into HoSoHocSinh values ('hs18','hoa duc nha','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop1')
insert into HoSoHocSinh values ('hs19','Tran duc nha','12/20/1997','Nu','ha noi',10,'ko biet','01696437653','lop1')
insert into HoSoHocSinh values ('hs20','hoa duc hieu','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop2')
insert into HoSoHocSinh values ('hs21','do duc khong','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop3')
insert into HoSoHocSinh values ('hs22','ta bien cuong','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop4')
insert into HoSoHocSinh values ('hs23','le cong vinh','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop5')
insert into HoSoHocSinh values ('hs24','bui thi yen','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop6')
insert into HoSoHocSinh values ('hs25','tran van chi','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop2')
insert into HoSoHocSinh values ('hs26','anh thi muon','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop2')
insert into HoSoHocSinh values ('hs27','cuong thi','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop3')

insert into HoSoHocSinh values ('hs28','ta bien cuong','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop4')
insert into HoSoHocSinh values ('hs29','le cong vinh','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop5')
insert into HoSoHocSinh values ('hs30','bui thi yen','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop6')
insert into HoSoHocSinh values ('hs31','tran van chi','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop3')
insert into HoSoHocSinh values ('hs32','anh thi muon','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop2')
insert into HoSoHocSinh values ('hs33','cuong thi','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop3')
insert into HoSoHocSinh values ('hs34','ta bien cuong','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop4')
insert into HoSoHocSinh values ('hs35','le cong vinh','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop5')
insert into HoSoHocSinh values ('hs36','bui thi yen','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop6')
insert into HoSoHocSinh values ('hs37','tran van chi','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop4')
insert into HoSoHocSinh values ('hs38','anh thi muon','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop2')
insert into HoSoHocSinh values ('hs39','cuong thi','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop3')
insert into HoSoHocSinh values ('hs40','Tran duc nha','12/20/1997','Nu','ha noi',10,'ko biet','01696437653','lop1')
insert into HoSoHocSinh values ('hs41','hoa duc hieu','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop2')
insert into HoSoHocSinh values ('hs42','do duc khong','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop3')
insert into HoSoHocSinh values ('hs43','Tran duc nha','12/20/1997','Nu','ha noi',10,'ko biet','01696437653','lop1')
insert into HoSoHocSinh values ('hs44','hoa duc hieu','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop2')
insert into HoSoHocSinh values ('hs45','do duc khong','12/20/1997','nam','ha noi',10,'ko biet','01696437653','lop3')
select * from HoSoHocSinh


--delete HoSoHocSinh

--diem
insert into Diem values ('hs1','mon1',10,null)
insert into Diem values ('hs2','mon1',null,10)
insert into Diem values ('hs3','mon1',7,null)
insert into Diem values ('hs4','mon2',null,8)
insert into Diem values ('hs5','mon2',2,null)
insert into Diem values ('hs6','mon2',null,10)
insert into Diem values ('hs7','mon3',3,null)
insert into Diem values ('hs8','mon3',null,8)
insert into Diem values ('hs9','mon3',6,null)
insert into Diem values ('hs10','mon4',null,10)
insert into Diem values ('hs11','mon4',10,4)
insert into Diem values ('hs12','mon4',10,null)
insert into Diem values ('hs13','mon5',1,10)
insert into Diem values ('hs14','mon5',7,null)
insert into Diem values ('hs15','mon5',10,8)
insert into Diem values ('hs16','mon1',null,10)
insert into Diem values ('hs17','mon2',9,10)
insert into Diem values ('hs18','mon1',10,10)
insert into Diem values ('hs19','mon2',null,10)
insert into Diem values ('hs20','mon3',10,3)
insert into Diem values ('hs21','mon4',6,10)
insert into Diem values ('hs22','mon5',10,2)
insert into Diem values ('hs23','mon2',null,10)
insert into Diem values ('hs24','mon4',5,10)
insert into Diem values ('hs25','mon2',null,10)
insert into Diem values ('hs26','mon1',10,7)
insert into Diem values ('hs27','mon5',null,10)


insert into Diem values ('hs28','mon5',7,null)
insert into Diem values ('hs29','mon5',10,8)
insert into Diem values ('hs30','mon1',null,10)
insert into Diem values ('hs31','mon2',9,10)
insert into Diem values ('hs32','mon1',10,10)
insert into Diem values ('hs33','mon2',null,10)
insert into Diem values ('hs34','mon3',10,3)
insert into Diem values ('hs35','mon4',6,10)
insert into Diem values ('hs36','mon5',10,2)
insert into Diem values ('hs37','mon2',null,10)
insert into Diem values ('hs38','mon4',5,10)
insert into Diem values ('hs39','mon2',null,10)
insert into Diem values ('hs40','mon1',10,7)
insert into Diem values ('hs41','mon5',null,10)
insert into Diem values ('hs42','mon5',10,2)
insert into Diem values ('hs43','mon2',null,10)
insert into Diem values ('hs44','mon4',5,10)
insert into Diem values ('hs45','mon2',null,10)
insert into Diem values ('hs41','mon1',10,7)
--insert into Diem values ('hs42','mon5',null,10)
select *from Diem
--delete Diem
--phan cong
select * from Diem

insert into PhanCongGiangDay values ('lop1','mon1','gv1','12-22-2016')
insert into PhanCongGiangDay values ('lop2','mon5','gv1','12-22-2016')
insert into PhanCongGiangDay values ('lop3','mon1','gv1','12-22-2016')
insert into PhanCongGiangDay values ('lop4','mon2','gv2','12-22-2016')
insert into PhanCongGiangDay values ('lop5','mon3','gv2','12-22-2016')

insert into PhanCongGiangDay values ('lop6','mon4','gv2','12-22-2016')
--insert into PhanCongGiangDay values ('lop2','mon5','gv2','12-22-2016')
--insert into PhanCongGiangDay values ('lop1','mon5','gv2','12-22-2016')
select * from PhanCongGiangDay
--delete PhanCongGiangDay