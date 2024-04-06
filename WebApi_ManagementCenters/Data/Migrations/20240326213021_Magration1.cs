using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Magration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrungTam",
                columns: table => new
                {
                    maTrungTam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenTrungTam = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    diaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    maSoThue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    soDienThoai = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    dienTich = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nganHang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    soTaiKhoan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ngayXoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TrungTam__7F957C446E0AF71B", x => x.maTrungTam);
                });
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                            name: "AspNetUsers",
                            columns: table => new
                            {
                                Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                                RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                RefreshTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                                Khoa = table.Column<bool>(type: "bit", nullable: false),
                                MaTrungTam = table.Column<int>(type: "int", nullable: false),
                                NgayCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                NgayTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                NgayXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                                NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                                Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                                NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                                EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                                PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                                TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                                LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                                LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                                AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                                table.ForeignKey(
                                    name: "FK_AspNetUsers_TrungTam_MaTrungTam",
                                    column: x => x.MaTrungTam,
                                    principalTable: "TrungTam",
                                    principalColumn: "maTrungTam");
                            });

            migrationBuilder.CreateTable(
                name: "DichVu",
                columns: table => new
                {
                    maDichVu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenDichVu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    thongTin = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    gia = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ngayXoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    post = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DichVu__80F48B09A0BEC9A7", x => x.maDichVu);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    maMonHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenMonHoc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    gia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    thongTin = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ngayXoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MonHoc__990DDC6B53DEDC66", x => x.maMonHoc);
                });

            

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    maNhaCungCap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenNhaCungCap = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    gioiThieu = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    soDienThoai = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    nganHang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    soTaiKhoan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    maSoThue = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    maTrungTam = table.Column<int>(type: "int", nullable: true),
                    ngayXoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhaCungC__D0B4D6DE148B1F68", x => x.maNhaCungCap);
                    table.ForeignKey(
                        name: "FK__NhaCungCa__maTru__76969D2E",
                        column: x => x.maTrungTam,
                        principalTable: "TrungTam",
                        principalColumn: "maTrungTam");
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    maNhanVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenNhanVien = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CCCD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ngaySinh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    gioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    diaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    soDienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    thongTin = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    hinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maTrungTam = table.Column<int>(type: "int", nullable: true),
                    maTaiKhoan = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    loaiNhanVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phongBan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    luong = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    nganHang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    soTaiKhoan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    danToc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tonGiao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ngayXoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaTaiKhoanNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhanVien__BDDEF20D1863E7B9", x => x.maNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanVien_AspNetUsers_MaTaiKhoanNavigationId",
                        column: x => x.MaTaiKhoanNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__NhanVien__maTrun__787EE5A0",
                        column: x => x.maTrungTam,
                        principalTable: "TrungTam",
                        principalColumn: "maTrungTam");
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    maSanPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    thongTin = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    loaiSanPham = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    hanSuDung = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    maNhaCungCap = table.Column<int>(type: "int", nullable: true),
                    maTrungTam = table.Column<int>(type: "int", nullable: true),
                    gia = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ngayXoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SanPham__5B439C430F49C885", x => x.maSanPham);
                    table.ForeignKey(
                        name: "FK__SanPham__maNhaCu__7B5B524B",
                        column: x => x.maNhaCungCap,
                        principalTable: "NhaCungCap",
                        principalColumn: "maNhaCungCap");
                    table.ForeignKey(
                        name: "FK__SanPham__maTrung__7C4F7684",
                        column: x => x.maTrungTam,
                        principalTable: "TrungTam",
                        principalColumn: "maTrungTam");
                });

            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    maLop = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenLop = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    maNhanVien = table.Column<int>(type: "int", nullable: true),
                    maTrungTam = table.Column<int>(type: "int", nullable: true),
                    namHoc = table.Column<int>(type: "int", nullable: true),
                    hocPhi = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    lichHoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    thongTin = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ngayBatDau = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ngayKetThuc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ngayXoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lop__261ECAE3BB44420E", x => x.maLop);
                    table.ForeignKey(
                        name: "FK__Lop__maNhanVien__71D1E811",
                        column: x => x.maNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "maNhanVien");
                    table.ForeignKey(
                        name: "FK__Lop__maTrungTam__72C60C4A",
                        column: x => x.maTrungTam,
                        principalTable: "TrungTam",
                        principalColumn: "maTrungTam");
                });

            migrationBuilder.CreateTable(
                name: "PhieuThuChi",
                columns: table => new
                {
                    maPhieu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ngayTao = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    codeHoaDon = table.Column<string>(type: "char(23)", maxLength: 23, nullable: true),
                    ngayThanhToan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    loaiPhieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tongTien = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ghiChu = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    maTrungTam = table.Column<int>(type: "int", nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    hinhThucThanhToan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    maNhanVien = table.Column<int>(type: "int", nullable: true),
                    ngayXoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PhieuThu__49A5B11F02F2C7D1", x => x.maPhieu);
                    table.ForeignKey(
                        name: "FK__PhieuThuC__maNha__797309D9",
                        column: x => x.maNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "maNhanVien");
                    table.ForeignKey(
                        name: "FK__PhieuThuC__maTru__7A672E12",
                        column: x => x.maTrungTam,
                        principalTable: "TrungTam",
                        principalColumn: "maTrungTam");
                });

            migrationBuilder.CreateTable(
                name: "LoSanPham",
                columns: table => new
                {
                    maLoSanPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenLoSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    maSanPham = table.Column<int>(type: "int", nullable: true),
                    soLuong = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    donVi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ngayNhap = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ngayHetHan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    maNhanVien = table.Column<int>(type: "int", nullable: true),
                    maTrungTam = table.Column<int>(type: "int", nullable: true),
                    ghiChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ngayXoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LoSanPha__17801A8BD327A917", x => x.maLoSanPham);
                    table.ForeignKey(
                        name: "FK__LoSanPham__maNha__73BA3083",
                        column: x => x.maNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "maNhanVien");
                    table.ForeignKey(
                        name: "FK__LoSanPham__maSan__74AE54BC",
                        column: x => x.maSanPham,
                        principalTable: "SanPham",
                        principalColumn: "maSanPham");
                    table.ForeignKey(
                        name: "FK__LoSanPham__maTru__75A278F5",
                        column: x => x.maTrungTam,
                        principalTable: "TrungTam",
                        principalColumn: "maTrungTam");
                });

            migrationBuilder.CreateTable(
                name: "HocSinh",
                columns: table => new
                {
                    maHocSinh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenHocSinh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ngaySinh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    gioiTinh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    maLop = table.Column<int>(type: "int", nullable: true),
                    maTrungTam = table.Column<int>(type: "int", nullable: true),
                    thongTin = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    hinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ngayXoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    chieuCao = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    canNang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    tinhTrangRang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    tinhTrangMat = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BMI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    tinhTrangTamLy = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    chucNangCoThe = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    danhGiaSucKhoe = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CCCDCha = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CCCDMe = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    tenCha = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    tenMe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ngaySinhCha = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ngaySinhMe = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    soDienThoaiCha = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    soDienThoaiMe = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    emailCha = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    emailMe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ngheNghiepCha = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ngheNghiepMe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HocSinh__B9EB19743168849F", x => x.maHocSinh);
                    table.ForeignKey(
                        name: "FK__HocSinh__maLop__6C190EBB",
                        column: x => x.maLop,
                        principalTable: "Lop",
                        principalColumn: "maLop");
                    table.ForeignKey(
                        name: "FK__HocSinh__maTrung__6D0D32F4",
                        column: x => x.maTrungTam,
                        principalTable: "TrungTam",
                        principalColumn: "maTrungTam");
                });

            migrationBuilder.CreateTable(
                name: "chiTietThuChi",
                columns: table => new
                {
                    maChiTiet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenChiTiet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    donVi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    soLuong = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    tongTien = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    maPhieu = table.Column<int>(type: "int", nullable: true),
                    ngayXoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__chiTietT__9996488817FF50DE", x => x.maChiTiet);
                    table.ForeignKey(
                        name: "FK__chiTietTh__maPhi__6B24EA82",
                        column: x => x.maPhieu,
                        principalTable: "PhieuThuChi",
                        principalColumn: "maPhieu");
                });

            migrationBuilder.CreateTable(
                name: "KetQua",
                columns: table => new
                {
                    maKetQua = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenKetQua = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    maHocSinh = table.Column<int>(type: "int", nullable: true),
                    maMonHoc = table.Column<int>(type: "int", nullable: true),
                    diem = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    xepLoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ngayKiemTra = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    maNhanVien = table.Column<int>(type: "int", nullable: true),
                    maTrungTam = table.Column<int>(type: "int", nullable: true),
                    ngayXoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KetQua__A2FDF9D61CD040EC", x => x.maKetQua);
                    table.ForeignKey(
                        name: "FK__KetQua__maHocSin__6E01572D",
                        column: x => x.maHocSinh,
                        principalTable: "HocSinh",
                        principalColumn: "maHocSinh");
                    table.ForeignKey(
                        name: "FK__KetQua__maMonHoc__6EF57B66",
                        column: x => x.maMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "maMonHoc");
                    table.ForeignKey(
                        name: "FK__KetQua__maNhanVi__6FE99F9F",
                        column: x => x.maNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "maNhanVien");
                    table.ForeignKey(
                        name: "FK__KetQua__maTrungT__70DDC3D8",
                        column: x => x.maTrungTam,
                        principalTable: "TrungTam",
                        principalColumn: "maTrungTam");
                });

            migrationBuilder.CreateTable(
                name: "SuDungDichVu",
                columns: table => new
                {
                    maSuDungDichVu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenSuDungDichVu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    maDichVu = table.Column<int>(type: "int", nullable: true),
                    maHocSinh = table.Column<int>(type: "int", nullable: true),
                    maTrungTam = table.Column<int>(type: "int", nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ngayBatDau = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ngayKetThuc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ngayXoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SuDungDi__0AA1672D8F7D692D", x => x.maSuDungDichVu);
                    table.ForeignKey(
                        name: "FK__SuDungDic__maDic__7D439ABD",
                        column: x => x.maDichVu,
                        principalTable: "DichVu",
                        principalColumn: "maDichVu");
                    table.ForeignKey(
                        name: "FK__SuDungDic__maHoc__7E37BEF6",
                        column: x => x.maHocSinh,
                        principalTable: "HocSinh",
                        principalColumn: "maHocSinh");
                    table.ForeignKey(
                        name: "FK__SuDungDic__maTru__7F2BE32F",
                        column: x => x.maTrungTam,
                        principalTable: "TrungTam",
                        principalColumn: "maTrungTam");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b59904a-3cdb-4c62-af58-fce68dc36cd0", "4", "Thu ngân", "Thu ngân" },
                    { "69588984-3bd9-4526-9aea-98fd0a2e122e", "1", "Admin", "Admin" },
                    { "74407c4c-fd6c-4265-8963-660301fe42ff", "3", "Giáo viên", "Giáo viên" },
                    { "77987efa-50f6-488c-a5bd-5cbae27509ba", "5", "Đầu bếp", "Đầu bếp" },
                    { "cf2b7b31-03e0-49c9-9d3b-7b02af83153c", "2", "Quản lý trung tâm", "Quản lý trung tâm" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietThuChi_maPhieu",
                table: "chiTietThuChi",
                column: "maPhieu");

            migrationBuilder.CreateIndex(
                name: "IX_HocSinh_maLop",
                table: "HocSinh",
                column: "maLop");

            migrationBuilder.CreateIndex(
                name: "IX_HocSinh_maTrungTam",
                table: "HocSinh",
                column: "maTrungTam");

            migrationBuilder.CreateIndex(
                name: "IX_KetQua_maHocSinh",
                table: "KetQua",
                column: "maHocSinh");

            migrationBuilder.CreateIndex(
                name: "IX_KetQua_maMonHoc",
                table: "KetQua",
                column: "maMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_KetQua_maNhanVien",
                table: "KetQua",
                column: "maNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_KetQua_maTrungTam",
                table: "KetQua",
                column: "maTrungTam");

            migrationBuilder.CreateIndex(
                name: "IX_Lop_maNhanVien",
                table: "Lop",
                column: "maNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_Lop_maTrungTam",
                table: "Lop",
                column: "maTrungTam");

            migrationBuilder.CreateIndex(
                name: "IX_LoSanPham_maNhanVien",
                table: "LoSanPham",
                column: "maNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_LoSanPham_maSanPham",
                table: "LoSanPham",
                column: "maSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_LoSanPham_maTrungTam",
                table: "LoSanPham",
                column: "maTrungTam");

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCap_maTrungTam",
                table: "NhaCungCap",
                column: "maTrungTam");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaTaiKhoanNavigationId",
                table: "NhanVien",
                column: "MaTaiKhoanNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_maTrungTam",
                table: "NhanVien",
                column: "maTrungTam");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThuChi_maNhanVien",
                table: "PhieuThuChi",
                column: "maNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThuChi_maTrungTam",
                table: "PhieuThuChi",
                column: "maTrungTam");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_maNhaCungCap",
                table: "SanPham",
                column: "maNhaCungCap");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_maTrungTam",
                table: "SanPham",
                column: "maTrungTam");

            migrationBuilder.CreateIndex(
                name: "IX_SuDungDichVu_maDichVu",
                table: "SuDungDichVu",
                column: "maDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_SuDungDichVu_maHocSinh",
                table: "SuDungDichVu",
                column: "maHocSinh");

            migrationBuilder.CreateIndex(
                name: "IX_SuDungDichVu_maTrungTam",
                table: "SuDungDichVu",
                column: "maTrungTam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "chiTietThuChi");

            migrationBuilder.DropTable(
                name: "KetQua");

            migrationBuilder.DropTable(
                name: "LoSanPham");

            migrationBuilder.DropTable(
                name: "SuDungDichVu");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PhieuThuChi");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "DichVu");

            migrationBuilder.DropTable(
                name: "HocSinh");

            migrationBuilder.DropTable(
                name: "NhaCungCap");

            migrationBuilder.DropTable(
                name: "Lop");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TrungTam");
        }
    }
}
