using Data.InterfacesData;
using Data.Models;

namespace Data.RepositoryData
{
    public class UnitOfWorkRepon :IUnitOfWork
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


        private ApplicationDbContext _context;
        public UnitOfWorkRepon(ApplicationDbContext context)
        {
            _context = context;

            TrungTam = new TrungTamRepon(_context);
            SuDungDichVu = new SuDungDichVuRepon(_context);
            SanPham = new SanPhamRepon(_context);
            PhieuThuChi = new PhieuThuChiRepon(_context);
            NhanVien = new NhanVienRepon(_context);
            NhaCungCap = new NhaCungCapRepon(_context);
            MonHoc = new MonHocRepon(_context);
            LoSanPham = new LoSanPhamRepon(_context);
            Lop = new LopRepon(_context);
            KetQua = new KetQuaRepon(_context);
            HocSinh = new HocSinhRepon(_context);
            DichVu = new DichVuRepon(_context);
            ChiTietThuChi = new ChiTietThuChiRepon(_context);
        }
    }
}
