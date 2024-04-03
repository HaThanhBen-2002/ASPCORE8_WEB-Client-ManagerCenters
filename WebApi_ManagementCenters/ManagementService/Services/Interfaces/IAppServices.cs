using Data.InterfacesData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Services.Interfaces
{
    public interface IAppServices
    {
        public ITrungTamService TrungTam { get; set; }
        public ISuDungDichVuService SuDungDichVu { get; set; }
        public ISanPhamService SanPham { get; set; }
        public IPhieuThuChiService PhieuThuChi { get; set; }
        public INhanVienService NhanVien { get; set; }
        public INhaCungCapService NhaCungCap { get; set; }
        public IMonHocService MonHoc { get; set; }
        public ILoSanPhamService LoSanPham { get; set; }
        public ILopService Lop { get; set; }
        public IKetQuaService KetQua { get; set; }
        public IHocSinhService HocSinh { get; set; }
        public IDichVuService DichVu { get; set; }
        public IChiTietThuChiService ChiTietThuChi { get; set; }
    }
}
