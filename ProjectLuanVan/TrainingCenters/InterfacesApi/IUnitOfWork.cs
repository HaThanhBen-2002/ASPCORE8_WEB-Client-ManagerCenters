namespace TrainingCenters.InterfacesApi
{
    public interface IUnitOfWork
    {
        public ITrungTam TrungTam { get; set; }
        public ISuDungDichVu SuDungDichVu { get; set; }
        public ISanPham SanPham { get; set; }
        public IPhieuThuChi PhieuThuChi { get; set; }
        public INhanVien NhanVien { get; set; }
        public INhaCungCap NhaCungCap { get; set; }
        public IMonHoc MonHoc { get; set; }
        public ILoSanPham LoSanPham { get; set; }
        public ILop Lop { get; set; }
        public IKetQua KetQua { get; set; }
        public IHocSinh HocSinh { get; set; }
        public IDichVu DichVu { get; set; }
        public IChiTietThuChi ChiTietThuChi { get; set; }
        public ISendEmail SendEmail { get; set; }
        public IXacThuc XacThuc { get; set; }
    }
}
