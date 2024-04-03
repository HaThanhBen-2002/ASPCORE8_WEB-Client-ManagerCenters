using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection.Emit;

namespace Data.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<ChiTietThuChi> ChiTietThuChis { get; set; }

        public virtual DbSet<DichVu> DichVus { get; set; }

        public virtual DbSet<HocSinh> HocSinhs { get; set; }

        public virtual DbSet<KetQua> KetQuas { get; set; }

        public virtual DbSet<LoSanPham> LoSanPhams { get; set; }

        public virtual DbSet<Lop> Lops { get; set; }

        public virtual DbSet<MonHoc> MonHocs { get; set; }

        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

        public virtual DbSet<NhanVien> NhanViens { get; set; }

        public virtual DbSet<PhieuThuChi> PhieuThuChis { get; set; }

        public virtual DbSet<SanPham> SanPhams { get; set; }

        public virtual DbSet<SuDungDichVu> SuDungDichVus { get; set; }

        public virtual DbSet<TrungTam> TrungTams { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);

            builder.Entity<ChiTietThuChi>(entity =>
            {
                entity.HasKey(e => e.MaChiTiet).HasName("PK__chiTietT__9996488817FF50DE");

                entity.ToTable("chiTietThuChi");

                entity.Property(e => e.MaChiTiet).HasColumnName("maChiTiet");
                entity.Property(e => e.DonVi)
                    .HasMaxLength(50)
                    .HasColumnName("donVi");
                entity.Property(e => e.MaPhieu).HasColumnName("maPhieu");
                entity.Property(e => e.NgayXoa)
                    .HasMaxLength(20)
                    .HasColumnName("ngayXoa");
                entity.Property(e => e.NguoiXoa)
                    .HasMaxLength(50)
                    .HasColumnName("nguoiXoa");
                entity.Property(e => e.SoLuong)
                    .HasMaxLength(10)
                    .HasColumnName("soLuong");
                entity.Property(e => e.TenChiTiet)
                    .HasMaxLength(255)
                    .HasColumnName("tenChiTiet");
                entity.Property(e => e.TongTien)
                    .HasMaxLength(10)
                    .HasColumnName("tongTien");

                entity.HasOne(d => d.MaPhieuNavigation).WithMany(p => p.ChiTietThuChis)
                    .HasForeignKey(d => d.MaPhieu)
                    .HasConstraintName("FK__chiTietTh__maPhi__6B24EA82");
            });

            builder.Entity<DichVu>(entity =>
            {
                entity.HasKey(e => e.MaDichVu).HasName("PK__DichVu__80F48B09A0BEC9A7");

                entity.ToTable("DichVu");

                entity.Property(e => e.MaDichVu).HasColumnName("maDichVu");
                entity.Property(e => e.Gia)
                    .HasMaxLength(15)
                    .HasColumnName("gia");
                entity.Property(e => e.NgayXoa)
                    .HasMaxLength(20)
                    .HasColumnName("ngayXoa");
                entity.Property(e => e.NguoiXoa)
                    .HasMaxLength(50)
                    .HasColumnName("nguoiXoa");
                entity.Property(e => e.Post).HasColumnName("post");
                entity.Property(e => e.TenDichVu)
                    .HasMaxLength(255)
                    .HasColumnName("tenDichVu");
                entity.Property(e => e.ThongTin)
                    .HasMaxLength(1000)
                    .HasColumnName("thongTin");
            });

            builder.Entity<HocSinh>(entity =>
            {
                entity.HasKey(e => e.MaHocSinh).HasName("PK__HocSinh__B9EB19743168849F");

                entity.ToTable("HocSinh");

                entity.Property(e => e.MaHocSinh).HasColumnName("maHocSinh");
                entity.Property(e => e.Bmi)
                    .HasMaxLength(10)
                    .HasColumnName("BMI");
                entity.Property(e => e.CanNang)
                    .HasMaxLength(20)
                    .HasColumnName("canNang");
                entity.Property(e => e.Cccdcha)
                    .HasMaxLength(20)
                    .HasColumnName("CCCDCha");
                entity.Property(e => e.Cccdme)
                    .HasMaxLength(20)
                    .HasColumnName("CCCDMe");
                entity.Property(e => e.ChieuCao)
                    .HasMaxLength(20)
                    .HasColumnName("chieuCao");
                entity.Property(e => e.ChucNangCoThe)
                    .HasMaxLength(500)
                    .HasColumnName("chucNangCoThe");
                entity.Property(e => e.DanhGiaSucKhoe)
                    .HasMaxLength(1000)
                    .HasColumnName("danhGiaSucKhoe");
                entity.Property(e => e.DiaChi)
                    .HasMaxLength(255)
                    .HasColumnName("diaChi");
                entity.Property(e => e.EmailCha)
                    .HasMaxLength(255)
                    .HasColumnName("emailCha");
                entity.Property(e => e.EmailMe)
                    .HasMaxLength(255)
                    .HasColumnName("emailMe");
                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(20)
                    .HasColumnName("gioiTinh");
                entity.Property(e => e.HinhAnh).HasColumnName("hinhAnh");
                entity.Property(e => e.MaLop).HasColumnName("maLop");
                entity.Property(e => e.MaTrungTam).HasColumnName("maTrungTam");
                entity.Property(e => e.NgaySinh)
                    .HasMaxLength(20)
                    .HasColumnName("ngaySinh");
                entity.Property(e => e.NgaySinhCha)
                    .HasMaxLength(20)
                    .HasColumnName("ngaySinhCha");
                entity.Property(e => e.NgaySinhMe)
                    .HasMaxLength(20)
                    .HasColumnName("ngaySinhMe");
                entity.Property(e => e.NgayXoa)
                    .HasMaxLength(20)
                    .HasColumnName("ngayXoa");
                entity.Property(e => e.NgheNghiepCha)
                    .HasMaxLength(255)
                    .HasColumnName("ngheNghiepCha");
                entity.Property(e => e.NgheNghiepMe)
                    .HasMaxLength(255)
                    .HasColumnName("ngheNghiepMe");
                entity.Property(e => e.NguoiXoa)
                    .HasMaxLength(50)
                    .HasColumnName("nguoiXoa");
                entity.Property(e => e.SoDienThoaiCha)
                    .HasMaxLength(11)
                    .HasColumnName("soDienThoaiCha");
                entity.Property(e => e.SoDienThoaiMe)
                    .HasMaxLength(11)
                    .HasColumnName("soDienThoaiMe");
                entity.Property(e => e.TenCha)
                    .HasMaxLength(255)
                    .HasColumnName("tenCha");
                entity.Property(e => e.TenHocSinh)
                    .HasMaxLength(255)
                    .HasColumnName("tenHocSinh");
                entity.Property(e => e.TenMe)
                    .HasMaxLength(255)
                    .HasColumnName("tenMe");
                entity.Property(e => e.ThongTin)
                    .HasMaxLength(1000)
                    .HasColumnName("thongTin");
                entity.Property(e => e.TinhTrangMat)
                    .HasMaxLength(255)
                    .HasColumnName("tinhTrangMat");
                entity.Property(e => e.TinhTrangRang)
                    .HasMaxLength(255)
                    .HasColumnName("tinhTrangRang");
                entity.Property(e => e.TinhTrangTamLy)
                    .HasMaxLength(500)
                    .HasColumnName("tinhTrangTamLy");

                entity.HasOne(d => d.MaLopNavigation).WithMany(p => p.HocSinhs)
                    .HasForeignKey(d => d.MaLop)
                    .HasConstraintName("FK__HocSinh__maLop__6C190EBB");

                entity.HasOne(d => d.MaTrungTamNavigation).WithMany(p => p.HocSinhs)
                    .HasForeignKey(d => d.MaTrungTam)
                    .HasConstraintName("FK__HocSinh__maTrung__6D0D32F4");
            });

            builder.Entity<KetQua>(entity =>
            {
                entity.HasKey(e => e.MaKetQua).HasName("PK__KetQua__A2FDF9D61CD040EC");

                entity.ToTable("KetQua");

                entity.Property(e => e.MaKetQua).HasColumnName("maKetQua");
                entity.Property(e => e.Diem)
                    .HasMaxLength(5)
                    .HasColumnName("diem");
                entity.Property(e => e.MaHocSinh).HasColumnName("maHocSinh");
                entity.Property(e => e.MaMonHoc).HasColumnName("maMonHoc");
                entity.Property(e => e.MaNhanVien).HasColumnName("maNhanVien");
                entity.Property(e => e.MaTrungTam).HasColumnName("maTrungTam");
                entity.Property(e => e.NgayKiemTra)
                    .HasMaxLength(20)
                    .HasColumnName("ngayKiemTra");
                entity.Property(e => e.NgayXoa)
                    .HasMaxLength(20)
                    .HasColumnName("ngayXoa");
                entity.Property(e => e.NguoiXoa)
                    .HasMaxLength(50)
                    .HasColumnName("nguoiXoa");
                entity.Property(e => e.TenKetQua)
                    .HasMaxLength(255)
                    .HasColumnName("tenKetQua");
                entity.Property(e => e.TrangThai)
                    .HasMaxLength(50)
                    .HasColumnName("trangThai");
                entity.Property(e => e.XepLoai)
                    .HasMaxLength(20)
                    .HasColumnName("xepLoai");

                entity.HasOne(d => d.MaHocSinhNavigation).WithMany(p => p.KetQuas)
                    .HasForeignKey(d => d.MaHocSinh)
                    .HasConstraintName("FK__KetQua__maHocSin__6E01572D");

                entity.HasOne(d => d.MaMonHocNavigation).WithMany(p => p.KetQuas)
                    .HasForeignKey(d => d.MaMonHoc)
                    .HasConstraintName("FK__KetQua__maMonHoc__6EF57B66");

                entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.KetQuas)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK__KetQua__maNhanVi__6FE99F9F");

                entity.HasOne(d => d.MaTrungTamNavigation).WithMany(p => p.KetQuas)
                    .HasForeignKey(d => d.MaTrungTam)
                    .HasConstraintName("FK__KetQua__maTrungT__70DDC3D8");
            });

            builder.Entity<LoSanPham>(entity =>
            {
                entity.HasKey(e => e.MaLoSanPham).HasName("PK__LoSanPha__17801A8BD327A917");

                entity.ToTable("LoSanPham");

                entity.Property(e => e.MaLoSanPham).HasColumnName("maLoSanPham");
                entity.Property(e => e.DonVi)
                    .HasMaxLength(10)
                    .HasColumnName("donVi");
                entity.Property(e => e.GhiChu)
                    .HasMaxLength(255)
                    .HasColumnName("ghiChu");
                entity.Property(e => e.MaNhanVien).HasColumnName("maNhanVien");
                entity.Property(e => e.MaSanPham).HasColumnName("maSanPham");
                entity.Property(e => e.MaTrungTam).HasColumnName("maTrungTam");
                entity.Property(e => e.NgayHetHan)
                    .HasMaxLength(20)
                    .HasColumnName("ngayHetHan");
                entity.Property(e => e.NgayNhap)
                    .HasMaxLength(20)
                    .HasColumnName("ngayNhap");
                entity.Property(e => e.NgayXoa)
                    .HasMaxLength(20)
                    .HasColumnName("ngayXoa");
                entity.Property(e => e.NguoiXoa)
                    .HasMaxLength(50)
                    .HasColumnName("nguoiXoa");
                entity.Property(e => e.SoLuong)
                    .HasMaxLength(10)
                    .HasColumnName("soLuong");
                entity.Property(e => e.TenLoSanPham)
                    .HasMaxLength(255)
                    .HasColumnName("tenLoSanPham");
                entity.Property(e => e.TrangThai)
                    .HasMaxLength(50)
                    .HasColumnName("trangThai");

                entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.LoSanPhams)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK__LoSanPham__maNha__73BA3083");

                entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.LoSanPhams)
                    .HasForeignKey(d => d.MaSanPham)
                    .HasConstraintName("FK__LoSanPham__maSan__74AE54BC");

                entity.HasOne(d => d.MaTrungTamNavigation).WithMany(p => p.LoSanPhams)
                    .HasForeignKey(d => d.MaTrungTam)
                    .HasConstraintName("FK__LoSanPham__maTru__75A278F5");
            });

            builder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.MaLop).HasName("PK__Lop__261ECAE3BB44420E");

                entity.ToTable("Lop");

                entity.Property(e => e.MaLop).HasColumnName("maLop");
                entity.Property(e => e.HocPhi)
                    .HasMaxLength(15)
                    .HasColumnName("hocPhi");
                entity.Property(e => e.LichHoc)
                    .HasMaxLength(100)
                    .HasColumnName("lichHoc");
                entity.Property(e => e.MaNhanVien).HasColumnName("maNhanVien");
                entity.Property(e => e.MaTrungTam).HasColumnName("maTrungTam");
                entity.Property(e => e.NamHoc).HasColumnName("namHoc");
                entity.Property(e => e.NgayBatDau)
                    .HasMaxLength(20)
                    .HasColumnName("ngayBatDau");
                entity.Property(e => e.NgayKetThuc)
                    .HasMaxLength(20)
                    .HasColumnName("ngayKetThuc");
                entity.Property(e => e.NgayXoa)
                    .HasMaxLength(20)
                    .HasColumnName("ngayXoa");
                entity.Property(e => e.NguoiXoa)
                    .HasMaxLength(50)
                    .HasColumnName("nguoiXoa");
                entity.Property(e => e.TenLop)
                    .HasMaxLength(255)
                    .HasColumnName("tenLop");
                entity.Property(e => e.ThongTin)
                    .HasMaxLength(1000)
                    .HasColumnName("thongTin");

                entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.Lops)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK__Lop__maNhanVien__71D1E811");

                entity.HasOne(d => d.MaTrungTamNavigation).WithMany(p => p.Lops)
                    .HasForeignKey(d => d.MaTrungTam)
                    .HasConstraintName("FK__Lop__maTrungTam__72C60C4A");
            });

            builder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMonHoc).HasName("PK__MonHoc__990DDC6B53DEDC66");

                entity.ToTable("MonHoc");

                entity.Property(e => e.MaMonHoc).HasColumnName("maMonHoc");
                entity.Property(e => e.Gia)
                    .HasMaxLength(20)
                    .HasColumnName("gia");
                entity.Property(e => e.NgayXoa)
                    .HasMaxLength(20)
                    .HasColumnName("ngayXoa");
                entity.Property(e => e.NguoiXoa)
                    .HasMaxLength(50)
                    .HasColumnName("nguoiXoa");
                entity.Property(e => e.TenMonHoc)
                    .HasMaxLength(255)
                    .HasColumnName("tenMonHoc");
                entity.Property(e => e.ThongTin)
                    .HasMaxLength(1000)
                    .HasColumnName("thongTin");
            });

            builder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNhaCungCap).HasName("PK__NhaCungC__D0B4D6DE148B1F68");

                entity.ToTable("NhaCungCap");

                entity.Property(e => e.MaNhaCungCap).HasColumnName("maNhaCungCap");
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");
                entity.Property(e => e.GioiThieu)
                    .HasMaxLength(1000)
                    .HasColumnName("gioiThieu");
                entity.Property(e => e.MaSoThue)
                    .HasMaxLength(15)
                    .HasColumnName("maSoThue");
                entity.Property(e => e.MaTrungTam).HasColumnName("maTrungTam");
                entity.Property(e => e.NganHang)
                    .HasMaxLength(255)
                    .HasColumnName("nganHang");
                entity.Property(e => e.NgayXoa)
                    .HasMaxLength(20)
                    .HasColumnName("ngayXoa");
                entity.Property(e => e.NguoiXoa)
                    .HasMaxLength(50)
                    .HasColumnName("nguoiXoa");
                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(11)
                    .HasColumnName("soDienThoai");
                entity.Property(e => e.SoTaiKhoan)
                    .HasMaxLength(20)
                    .HasColumnName("soTaiKhoan");
                entity.Property(e => e.TenNhaCungCap)
                    .HasMaxLength(255)
                    .HasColumnName("tenNhaCungCap");

                entity.HasOne(d => d.MaTrungTamNavigation).WithMany(p => p.NhaCungCaps)
                    .HasForeignKey(d => d.MaTrungTam)
                    .HasConstraintName("FK__NhaCungCa__maTru__76969D2E");
            });

            builder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__BDDEF20D1863E7B9");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNhanVien).HasColumnName("maNhanVien");
                entity.Property(e => e.Cccd)
                    .HasMaxLength(20)
                    .HasColumnName("CCCD");
                entity.Property(e => e.DanToc)
                    .HasMaxLength(50)
                    .HasColumnName("danToc");
                entity.Property(e => e.DiaChi)
                    .HasMaxLength(255)
                    .HasColumnName("diaChi");
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");
                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(10)
                    .HasColumnName("gioiTinh");
                entity.Property(e => e.HinhAnh).HasColumnName("hinhAnh");
                entity.Property(e => e.LoaiNhanVien)
                    .HasMaxLength(50)
                    .HasColumnName("loaiNhanVien");
                entity.Property(e => e.Luong)
                    .HasMaxLength(15)
                    .HasColumnName("luong");
                entity.Property(e => e.MaTaiKhoan)
                    .HasMaxLength(450)
                    .HasColumnName("maTaiKhoan");
                entity.Property(e => e.MaTrungTam).HasColumnName("maTrungTam");
                entity.Property(e => e.NganHang)
                    .HasMaxLength(255)
                    .HasColumnName("nganHang");
                entity.Property(e => e.NgaySinh)
                    .HasMaxLength(20)
                    .HasColumnName("ngaySinh");
                entity.Property(e => e.NgayXoa)
                    .HasMaxLength(20)
                    .HasColumnName("ngayXoa");
                entity.Property(e => e.NguoiXoa)
                    .HasMaxLength(50)
                    .HasColumnName("nguoiXoa");
                entity.Property(e => e.PhongBan)
                    .HasMaxLength(50)
                    .HasColumnName("phongBan");
                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(20)
                    .HasColumnName("soDienThoai");
                entity.Property(e => e.SoTaiKhoan)
                    .HasMaxLength(20)
                    .HasColumnName("soTaiKhoan");
                entity.Property(e => e.TenNhanVien)
                    .HasMaxLength(255)
                    .HasColumnName("tenNhanVien");
                entity.Property(e => e.ThongTin)
                    .HasMaxLength(1000)
                    .HasColumnName("thongTin");
                entity.Property(e => e.TonGiao)
                    .HasMaxLength(50)
                    .HasColumnName("tonGiao");

                entity.HasOne(d => d.MaTrungTamNavigation).WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaTrungTam)
                    .HasConstraintName("FK__NhanVien__maTrun__787EE5A0");
            });

            builder.Entity<PhieuThuChi>(entity =>
            {
                entity.HasKey(e => e.MaPhieu).HasName("PK__PhieuThu__49A5B11F02F2C7D1");

                entity.ToTable("PhieuThuChi");

                entity.Property(e => e.MaPhieu).HasColumnName("maPhieu");
                entity.Property(e => e.GhiChu)
                    .HasMaxLength(1000)
                    .HasColumnName("ghiChu");
                entity.Property(e => e.HinhThucThanhToan)
                    .HasMaxLength(100)
                    .HasColumnName("hinhThucThanhToan");
                entity.Property(e => e.LoaiPhieu)
                    .HasMaxLength(50)
                    .HasColumnName("loaiPhieu");
                entity.Property(e => e.MaNhanVien).HasColumnName("maNhanVien");
                entity.Property(e => e.MaTrungTam).HasColumnName("maTrungTam");
                entity.Property(e => e.NgayTao)
                    .HasMaxLength(20)
                    .HasColumnName("ngayTao");
                entity.Property(e => e.NgayThanhToan)
                    .HasMaxLength(20)
                    .HasColumnName("ngayThanhToan");
                entity.Property(e => e.NgayXoa)
                    .HasMaxLength(20)
                    .HasColumnName("ngayXoa");
                entity.Property(e => e.NguoiXoa)
                    .HasMaxLength(50)
                    .HasColumnName("nguoiXoa");
                entity.Property(e => e.TongTien)
                    .HasMaxLength(15)
                    .HasColumnName("tongTien");
                entity.Property(e => e.TrangThai)
                    .HasMaxLength(100)
                    .HasColumnName("trangThai");

                entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.PhieuThuChis)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK__PhieuThuC__maNha__797309D9");

                entity.HasOne(d => d.MaTrungTamNavigation).WithMany(p => p.PhieuThuChis)
                    .HasForeignKey(d => d.MaTrungTam)
                    .HasConstraintName("FK__PhieuThuC__maTru__7A672E12");
            });

            builder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSanPham).HasName("PK__SanPham__5B439C430F49C885");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSanPham).HasColumnName("maSanPham");
                entity.Property(e => e.Gia)
                    .HasMaxLength(15)
                    .HasColumnName("gia");
                entity.Property(e => e.HanSuDung)
                    .HasMaxLength(10)
                    .HasColumnName("hanSuDung");
                entity.Property(e => e.LoaiSanPham)
                    .HasMaxLength(50)
                    .HasColumnName("loaiSanPham");
                entity.Property(e => e.MaNhaCungCap).HasColumnName("maNhaCungCap");
                entity.Property(e => e.MaTrungTam).HasColumnName("maTrungTam");
                entity.Property(e => e.NgayXoa)
                    .HasMaxLength(20)
                    .HasColumnName("ngayXoa");
                entity.Property(e => e.NguoiXoa)
                    .HasMaxLength(50)
                    .HasColumnName("nguoiXoa");
                entity.Property(e => e.TenSanPham)
                    .HasMaxLength(255)
                    .HasColumnName("tenSanPham");
                entity.Property(e => e.ThongTin)
                    .HasMaxLength(1000)
                    .HasColumnName("thongTin");

                entity.HasOne(d => d.MaNhaCungCapNavigation).WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaNhaCungCap)
                    .HasConstraintName("FK__SanPham__maNhaCu__7B5B524B");

                entity.HasOne(d => d.MaTrungTamNavigation).WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaTrungTam)
                    .HasConstraintName("FK__SanPham__maTrung__7C4F7684");
            });

            builder.Entity<SuDungDichVu>(entity =>
            {
                entity.HasKey(e => e.MaSuDungDichVu).HasName("PK__SuDungDi__0AA1672D8F7D692D");

                entity.ToTable("SuDungDichVu");

                entity.Property(e => e.MaSuDungDichVu).HasColumnName("maSuDungDichVu");
                entity.Property(e => e.MaDichVu).HasColumnName("maDichVu");
                entity.Property(e => e.MaHocSinh).HasColumnName("maHocSinh");
                entity.Property(e => e.MaTrungTam).HasColumnName("maTrungTam");
                entity.Property(e => e.NgayBatDau)
                    .HasMaxLength(20)
                    .HasColumnName("ngayBatDau");
                entity.Property(e => e.NgayKetThuc)
                    .HasMaxLength(20)
                    .HasColumnName("ngayKetThuc");
                entity.Property(e => e.NgayXoa)
                    .HasMaxLength(20)
                    .HasColumnName("ngayXoa");
                entity.Property(e => e.NguoiXoa)
                    .HasMaxLength(50)
                    .HasColumnName("nguoiXoa");
                entity.Property(e => e.TenSuDungDichVu)
                    .HasMaxLength(255)
                    .HasColumnName("tenSuDungDichVu");
                entity.Property(e => e.TrangThai)
                    .HasMaxLength(50)
                    .HasColumnName("trangThai");

                entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.SuDungDichVus)
                    .HasForeignKey(d => d.MaDichVu)
                    .HasConstraintName("FK__SuDungDic__maDic__7D439ABD");

                entity.HasOne(d => d.MaHocSinhNavigation).WithMany(p => p.SuDungDichVus)
                    .HasForeignKey(d => d.MaHocSinh)
                    .HasConstraintName("FK__SuDungDic__maHoc__7E37BEF6");

                entity.HasOne(d => d.MaTrungTamNavigation).WithMany(p => p.SuDungDichVus)
                    .HasForeignKey(d => d.MaTrungTam)
                    .HasConstraintName("FK__SuDungDic__maTru__7F2BE32F");
            });

            builder.Entity<TrungTam>(entity =>
            {
                entity.HasKey(e => e.MaTrungTam).HasName("PK__TrungTam__7F957C446E0AF71B");

                entity.ToTable("TrungTam");

                entity.Property(e => e.MaTrungTam).HasColumnName("maTrungTam");
                entity.Property(e => e.DiaChi)
                    .HasMaxLength(255)
                    .HasColumnName("diaChi");
                entity.Property(e => e.DienTich)
                    .HasMaxLength(20)
                    .HasColumnName("dienTich");
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");
                entity.Property(e => e.MaSoThue)
                    .HasMaxLength(255)
                    .HasColumnName("maSoThue");
                entity.Property(e => e.NganHang)
                    .HasMaxLength(255)
                    .HasColumnName("nganHang");
                entity.Property(e => e.NgayXoa)
                    .HasMaxLength(20)
                    .HasColumnName("ngayXoa");
                entity.Property(e => e.NguoiXoa)
                    .HasMaxLength(50)
                    .HasColumnName("nguoiXoa");
                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(11)
                    .HasColumnName("soDienThoai");
                entity.Property(e => e.SoTaiKhoan)
                    .HasMaxLength(20)
                    .HasColumnName("soTaiKhoan");
                entity.Property(e => e.TenTrungTam)
                    .HasMaxLength(255)
                    .HasColumnName("tenTrungTam");
            });
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                 new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                 new IdentityRole() { Name = "Quản lý trung tâm", ConcurrencyStamp = "2", NormalizedName = "Quản lý trung tâm" },
                 new IdentityRole() { Name = "Giáo viên", ConcurrencyStamp = "3", NormalizedName = "Giáo viên" },
                 new IdentityRole() { Name = "Thu ngân", ConcurrencyStamp = "4", NormalizedName = "Thu ngân" },
                 new IdentityRole() { Name = "Đầu bếp", ConcurrencyStamp = "5", NormalizedName = "Đầu bếp" }
                );
        }
    }
}


//migrationBuilder.CreateTable(
//                name: "AspNetUsers",
//                columns: table => new
//                {
//                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
//                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    RefreshTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
//                    Khoa = table.Column<bool>(type: "bit", nullable: false),
//                    MaTrungTam = table.Column<int>(type: "int", nullable: false),
//                    NgayCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    NgayTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    NgayXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
//                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
//                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
//                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
//                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
//                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
//                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
//                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
//                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
//                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_AspNetUsers_TrungTam_MaTrungTam",
//                        column: x => x.MaTrungTam,
//                        principalTable: "TrungTam",
//                        principalColumn: "maTrungTam");
//                });