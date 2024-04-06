IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [TrungTam] (
        [maTrungTam] int NOT NULL IDENTITY,
        [tenTrungTam] nvarchar(255) NULL,
        [diaChi] nvarchar(255) NULL,
        [email] nvarchar(255) NULL,
        [maSoThue] nvarchar(255) NULL,
        [soDienThoai] nvarchar(11) NULL,
        [dienTich] nvarchar(20) NULL,
        [nganHang] nvarchar(255) NULL,
        [soTaiKhoan] nvarchar(20) NULL,
        [ngayXoa] nvarchar(20) NULL,
        [nguoiXoa] nvarchar(50) NULL,
        CONSTRAINT [PK__TrungTam__7F957C446E0AF71B] PRIMARY KEY ([maTrungTam])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [RefreshToken] nvarchar(max) NULL,
        [RefreshTokenExpiry] datetime2 NULL,
        [Khoa] bit NOT NULL,
        [MaTrungTam] int NOT NULL,
        [NgayCapNhat] nvarchar(max) NOT NULL,
        [NgayTao] nvarchar(max) NOT NULL,
        [NgayXoa] nvarchar(max) NULL,
        [NguoiXoa] nvarchar(max) NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUsers_TrungTam_MaTrungTam] FOREIGN KEY ([MaTrungTam]) REFERENCES [TrungTam] ([maTrungTam])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [DichVu] (
        [maDichVu] int NOT NULL IDENTITY,
        [tenDichVu] nvarchar(255) NULL,
        [thongTin] nvarchar(1000) NULL,
        [gia] nvarchar(15) NULL,
        [ngayXoa] nvarchar(20) NULL,
        [nguoiXoa] nvarchar(50) NULL,
        [post] nvarchar(max) NULL,
        CONSTRAINT [PK__DichVu__80F48B09A0BEC9A7] PRIMARY KEY ([maDichVu])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [MonHoc] (
        [maMonHoc] int NOT NULL IDENTITY,
        [tenMonHoc] nvarchar(255) NULL,
        [gia] nvarchar(20) NULL,
        [thongTin] nvarchar(1000) NULL,
        [ngayXoa] nvarchar(20) NULL,
        [nguoiXoa] nvarchar(50) NULL,
        CONSTRAINT [PK__MonHoc__990DDC6B53DEDC66] PRIMARY KEY ([maMonHoc])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [NhaCungCap] (
        [maNhaCungCap] int NOT NULL IDENTITY,
        [tenNhaCungCap] nvarchar(255) NULL,
        [gioiThieu] nvarchar(1000) NULL,
        [email] nvarchar(255) NULL,
        [soDienThoai] nvarchar(11) NULL,
        [nganHang] nvarchar(255) NULL,
        [soTaiKhoan] nvarchar(20) NULL,
        [maSoThue] nvarchar(15) NULL,
        [maTrungTam] int NULL,
        [ngayXoa] nvarchar(20) NULL,
        [nguoiXoa] nvarchar(50) NULL,
        CONSTRAINT [PK__NhaCungC__D0B4D6DE148B1F68] PRIMARY KEY ([maNhaCungCap]),
        CONSTRAINT [FK__NhaCungCa__maTru__76969D2E] FOREIGN KEY ([maTrungTam]) REFERENCES [TrungTam] ([maTrungTam])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [NhanVien] (
        [maNhanVien] int NOT NULL IDENTITY,
        [tenNhanVien] nvarchar(255) NULL,
        [CCCD] nvarchar(20) NULL,
        [ngaySinh] nvarchar(20) NULL,
        [gioiTinh] nvarchar(10) NULL,
        [diaChi] nvarchar(255) NULL,
        [soDienThoai] nvarchar(20) NULL,
        [email] nvarchar(255) NULL,
        [thongTin] nvarchar(1000) NULL,
        [hinhAnh] nvarchar(max) NULL,
        [maTrungTam] int NULL,
        [maTaiKhoan] nvarchar(450) NULL,
        [loaiNhanVien] nvarchar(50) NULL,
        [phongBan] nvarchar(50) NULL,
        [luong] nvarchar(15) NULL,
        [nganHang] nvarchar(255) NULL,
        [soTaiKhoan] nvarchar(20) NULL,
        [danToc] nvarchar(50) NULL,
        [tonGiao] nvarchar(50) NULL,
        [ngayXoa] nvarchar(20) NULL,
        [nguoiXoa] nvarchar(50) NULL,
        [MaTaiKhoanNavigationId] nvarchar(450) NULL,
        CONSTRAINT [PK__NhanVien__BDDEF20D1863E7B9] PRIMARY KEY ([maNhanVien]),
        CONSTRAINT [FK_NhanVien_AspNetUsers_MaTaiKhoanNavigationId] FOREIGN KEY ([MaTaiKhoanNavigationId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK__NhanVien__maTrun__787EE5A0] FOREIGN KEY ([maTrungTam]) REFERENCES [TrungTam] ([maTrungTam])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [SanPham] (
        [maSanPham] int NOT NULL IDENTITY,
        [tenSanPham] nvarchar(255) NULL,
        [thongTin] nvarchar(1000) NULL,
        [loaiSanPham] nvarchar(50) NULL,
        [hanSuDung] nvarchar(10) NULL,
        [maNhaCungCap] int NULL,
        [maTrungTam] int NULL,
        [gia] nvarchar(15) NULL,
        [ngayXoa] nvarchar(20) NULL,
        [nguoiXoa] nvarchar(50) NULL,
        CONSTRAINT [PK__SanPham__5B439C430F49C885] PRIMARY KEY ([maSanPham]),
        CONSTRAINT [FK__SanPham__maNhaCu__7B5B524B] FOREIGN KEY ([maNhaCungCap]) REFERENCES [NhaCungCap] ([maNhaCungCap]),
        CONSTRAINT [FK__SanPham__maTrung__7C4F7684] FOREIGN KEY ([maTrungTam]) REFERENCES [TrungTam] ([maTrungTam])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [Lop] (
        [maLop] int NOT NULL IDENTITY,
        [tenLop] nvarchar(255) NULL,
        [maNhanVien] int NULL,
        [maTrungTam] int NULL,
        [namHoc] int NULL,
        [hocPhi] nvarchar(15) NULL,
        [lichHoc] nvarchar(100) NULL,
        [thongTin] nvarchar(1000) NULL,
        [ngayBatDau] nvarchar(20) NULL,
        [ngayKetThuc] nvarchar(20) NULL,
        [ngayXoa] nvarchar(20) NULL,
        [nguoiXoa] nvarchar(50) NULL,
        CONSTRAINT [PK__Lop__261ECAE3BB44420E] PRIMARY KEY ([maLop]),
        CONSTRAINT [FK__Lop__maNhanVien__71D1E811] FOREIGN KEY ([maNhanVien]) REFERENCES [NhanVien] ([maNhanVien]),
        CONSTRAINT [FK__Lop__maTrungTam__72C60C4A] FOREIGN KEY ([maTrungTam]) REFERENCES [TrungTam] ([maTrungTam])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [PhieuThuChi] (
        [maPhieu] int NOT NULL IDENTITY,
        [ngayTao] nvarchar(20) NULL,
        [codeHoaDon] char(23) NULL,
        [ngayThanhToan] nvarchar(20) NULL,
        [loaiPhieu] nvarchar(50) NULL,
        [tongTien] nvarchar(15) NULL,
        [ghiChu] nvarchar(1000) NULL,
        [maTrungTam] int NULL,
        [trangThai] nvarchar(100) NULL,
        [hinhThucThanhToan] nvarchar(100) NULL,
        [maNhanVien] int NULL,
        [ngayXoa] nvarchar(20) NULL,
        [nguoiXoa] nvarchar(50) NULL,
        CONSTRAINT [PK__PhieuThu__49A5B11F02F2C7D1] PRIMARY KEY ([maPhieu]),
        CONSTRAINT [FK__PhieuThuC__maNha__797309D9] FOREIGN KEY ([maNhanVien]) REFERENCES [NhanVien] ([maNhanVien]),
        CONSTRAINT [FK__PhieuThuC__maTru__7A672E12] FOREIGN KEY ([maTrungTam]) REFERENCES [TrungTam] ([maTrungTam])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [LoSanPham] (
        [maLoSanPham] int NOT NULL IDENTITY,
        [tenLoSanPham] nvarchar(255) NULL,
        [trangThai] nvarchar(50) NULL,
        [maSanPham] int NULL,
        [soLuong] nvarchar(10) NULL,
        [donVi] nvarchar(10) NULL,
        [ngayNhap] nvarchar(20) NULL,
        [ngayHetHan] nvarchar(20) NULL,
        [maNhanVien] int NULL,
        [maTrungTam] int NULL,
        [ghiChu] nvarchar(255) NULL,
        [ngayXoa] nvarchar(20) NULL,
        [nguoiXoa] nvarchar(50) NULL,
        CONSTRAINT [PK__LoSanPha__17801A8BD327A917] PRIMARY KEY ([maLoSanPham]),
        CONSTRAINT [FK__LoSanPham__maNha__73BA3083] FOREIGN KEY ([maNhanVien]) REFERENCES [NhanVien] ([maNhanVien]),
        CONSTRAINT [FK__LoSanPham__maSan__74AE54BC] FOREIGN KEY ([maSanPham]) REFERENCES [SanPham] ([maSanPham]),
        CONSTRAINT [FK__LoSanPham__maTru__75A278F5] FOREIGN KEY ([maTrungTam]) REFERENCES [TrungTam] ([maTrungTam])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [HocSinh] (
        [maHocSinh] int NOT NULL IDENTITY,
        [tenHocSinh] nvarchar(255) NULL,
        [ngaySinh] nvarchar(20) NULL,
        [gioiTinh] nvarchar(20) NULL,
        [maLop] int NULL,
        [maTrungTam] int NULL,
        [thongTin] nvarchar(1000) NULL,
        [hinhAnh] nvarchar(max) NULL,
        [diaChi] nvarchar(255) NULL,
        [ngayXoa] nvarchar(20) NULL,
        [nguoiXoa] nvarchar(50) NULL,
        [chieuCao] nvarchar(20) NULL,
        [canNang] nvarchar(20) NULL,
        [tinhTrangRang] nvarchar(255) NULL,
        [tinhTrangMat] nvarchar(255) NULL,
        [BMI] nvarchar(10) NULL,
        [tinhTrangTamLy] nvarchar(500) NULL,
        [chucNangCoThe] nvarchar(500) NULL,
        [danhGiaSucKhoe] nvarchar(1000) NULL,
        [CCCDCha] nvarchar(20) NULL,
        [CCCDMe] nvarchar(20) NULL,
        [tenCha] nvarchar(255) NULL,
        [tenMe] nvarchar(255) NULL,
        [ngaySinhCha] nvarchar(20) NULL,
        [ngaySinhMe] nvarchar(20) NULL,
        [soDienThoaiCha] nvarchar(11) NULL,
        [soDienThoaiMe] nvarchar(11) NULL,
        [emailCha] nvarchar(255) NULL,
        [emailMe] nvarchar(255) NULL,
        [ngheNghiepCha] nvarchar(255) NULL,
        [ngheNghiepMe] nvarchar(255) NULL,
        CONSTRAINT [PK__HocSinh__B9EB19743168849F] PRIMARY KEY ([maHocSinh]),
        CONSTRAINT [FK__HocSinh__maLop__6C190EBB] FOREIGN KEY ([maLop]) REFERENCES [Lop] ([maLop]),
        CONSTRAINT [FK__HocSinh__maTrung__6D0D32F4] FOREIGN KEY ([maTrungTam]) REFERENCES [TrungTam] ([maTrungTam])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [chiTietThuChi] (
        [maChiTiet] int NOT NULL IDENTITY,
        [tenChiTiet] nvarchar(255) NULL,
        [donVi] nvarchar(50) NULL,
        [soLuong] nvarchar(10) NULL,
        [tongTien] nvarchar(10) NULL,
        [maPhieu] int NULL,
        [ngayXoa] nvarchar(20) NULL,
        [nguoiXoa] nvarchar(50) NULL,
        CONSTRAINT [PK__chiTietT__9996488817FF50DE] PRIMARY KEY ([maChiTiet]),
        CONSTRAINT [FK__chiTietTh__maPhi__6B24EA82] FOREIGN KEY ([maPhieu]) REFERENCES [PhieuThuChi] ([maPhieu])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [KetQua] (
        [maKetQua] int NOT NULL IDENTITY,
        [tenKetQua] nvarchar(255) NULL,
        [maHocSinh] int NULL,
        [maMonHoc] int NULL,
        [diem] nvarchar(5) NULL,
        [xepLoai] nvarchar(20) NULL,
        [ngayKiemTra] nvarchar(20) NULL,
        [trangThai] nvarchar(50) NULL,
        [maNhanVien] int NULL,
        [maTrungTam] int NULL,
        [ngayXoa] nvarchar(20) NULL,
        [nguoiXoa] nvarchar(50) NULL,
        CONSTRAINT [PK__KetQua__A2FDF9D61CD040EC] PRIMARY KEY ([maKetQua]),
        CONSTRAINT [FK__KetQua__maHocSin__6E01572D] FOREIGN KEY ([maHocSinh]) REFERENCES [HocSinh] ([maHocSinh]),
        CONSTRAINT [FK__KetQua__maMonHoc__6EF57B66] FOREIGN KEY ([maMonHoc]) REFERENCES [MonHoc] ([maMonHoc]),
        CONSTRAINT [FK__KetQua__maNhanVi__6FE99F9F] FOREIGN KEY ([maNhanVien]) REFERENCES [NhanVien] ([maNhanVien]),
        CONSTRAINT [FK__KetQua__maTrungT__70DDC3D8] FOREIGN KEY ([maTrungTam]) REFERENCES [TrungTam] ([maTrungTam])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE TABLE [SuDungDichVu] (
        [maSuDungDichVu] int NOT NULL IDENTITY,
        [tenSuDungDichVu] nvarchar(255) NULL,
        [maDichVu] int NULL,
        [maHocSinh] int NULL,
        [maTrungTam] int NULL,
        [trangThai] nvarchar(50) NULL,
        [ngayBatDau] nvarchar(20) NULL,
        [ngayKetThuc] nvarchar(20) NULL,
        [ngayXoa] nvarchar(20) NULL,
        [nguoiXoa] nvarchar(50) NULL,
        CONSTRAINT [PK__SuDungDi__0AA1672D8F7D692D] PRIMARY KEY ([maSuDungDichVu]),
        CONSTRAINT [FK__SuDungDic__maDic__7D439ABD] FOREIGN KEY ([maDichVu]) REFERENCES [DichVu] ([maDichVu]),
        CONSTRAINT [FK__SuDungDic__maHoc__7E37BEF6] FOREIGN KEY ([maHocSinh]) REFERENCES [HocSinh] ([maHocSinh]),
        CONSTRAINT [FK__SuDungDic__maTru__7F2BE32F] FOREIGN KEY ([maTrungTam]) REFERENCES [TrungTam] ([maTrungTam])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N''1b59904a-3cdb-4c62-af58-fce68dc36cd0'', N''4'', N''Thu ngân'', N''Thu ngân''),
    (N''69588984-3bd9-4526-9aea-98fd0a2e122e'', N''1'', N''Admin'', N''Admin''),
    (N''74407c4c-fd6c-4265-8963-660301fe42ff'', N''3'', N''Giáo viên'', N''Giáo viên''),
    (N''77987efa-50f6-488c-a5bd-5cbae27509ba'', N''5'', N''Đầu bếp'', N''Đầu bếp''),
    (N''cf2b7b31-03e0-49c9-9d3b-7b02af83153c'', N''2'', N''Quản lý trung tâm'', N''Quản lý trung tâm'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_chiTietThuChi_maPhieu] ON [chiTietThuChi] ([maPhieu]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_HocSinh_maLop] ON [HocSinh] ([maLop]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_HocSinh_maTrungTam] ON [HocSinh] ([maTrungTam]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_KetQua_maHocSinh] ON [KetQua] ([maHocSinh]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_KetQua_maMonHoc] ON [KetQua] ([maMonHoc]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_KetQua_maNhanVien] ON [KetQua] ([maNhanVien]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_KetQua_maTrungTam] ON [KetQua] ([maTrungTam]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_Lop_maNhanVien] ON [Lop] ([maNhanVien]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_Lop_maTrungTam] ON [Lop] ([maTrungTam]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_LoSanPham_maNhanVien] ON [LoSanPham] ([maNhanVien]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_LoSanPham_maSanPham] ON [LoSanPham] ([maSanPham]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_LoSanPham_maTrungTam] ON [LoSanPham] ([maTrungTam]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_NhaCungCap_maTrungTam] ON [NhaCungCap] ([maTrungTam]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_NhanVien_MaTaiKhoanNavigationId] ON [NhanVien] ([MaTaiKhoanNavigationId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_NhanVien_maTrungTam] ON [NhanVien] ([maTrungTam]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_PhieuThuChi_maNhanVien] ON [PhieuThuChi] ([maNhanVien]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_PhieuThuChi_maTrungTam] ON [PhieuThuChi] ([maTrungTam]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_SanPham_maNhaCungCap] ON [SanPham] ([maNhaCungCap]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_SanPham_maTrungTam] ON [SanPham] ([maTrungTam]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_SuDungDichVu_maDichVu] ON [SuDungDichVu] ([maDichVu]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_SuDungDichVu_maHocSinh] ON [SuDungDichVu] ([maHocSinh]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    CREATE INDEX [IX_SuDungDichVu_maTrungTam] ON [SuDungDichVu] ([maTrungTam]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240326213021_Magration1'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240326213021_Magration1', N'8.0.3');
END;
GO

COMMIT;
GO

