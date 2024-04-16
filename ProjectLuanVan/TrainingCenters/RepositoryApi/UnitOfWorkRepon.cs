using Azure.Core;
using Microsoft.Extensions.Options;
using TrainingCenters.ConnectApi;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.RepositoryApi
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
        public ISendEmail SendEmail { get; set; }
        public IXacThuc XacThuc { get; set; }

        private readonly HttpClient _httpClient;
        private readonly IOptions<TrainingCenters.ConnectApi.ConnectApi> _connectionStrings;
        public UnitOfWorkRepon(HttpClient httpClient, IOptions<TrainingCenters.ConnectApi.ConnectApi> connectionStrings)
        {
            _httpClient = httpClient;
            _connectionStrings = connectionStrings;
            _httpClient.Timeout = TimeSpan.FromSeconds(30);

            TrungTam = new TrungTamRepon(_httpClient,_connectionStrings);
            SendEmail = new SendEmailRepon(_httpClient,_connectionStrings);
            SuDungDichVu = new SuDungDichVuRepon(_httpClient, _connectionStrings);
            SanPham = new SanPhamRepon(_httpClient, _connectionStrings);
            PhieuThuChi = new PhieuThuChiRepon(_httpClient, _connectionStrings);
            NhanVien = new NhanVienRepon(_httpClient, _connectionStrings);
            NhaCungCap = new NhaCungCapRepon(_httpClient, _connectionStrings);
            MonHoc = new MonHocRepon(_httpClient, _connectionStrings);
            LoSanPham = new LoSanPhamRepon(_httpClient, _connectionStrings);
            Lop = new LopRepon(_httpClient, _connectionStrings);
            KetQua = new KetQuaRepon(_httpClient, _connectionStrings);
            HocSinh = new HocSinhRepon(_httpClient, _connectionStrings);
            DichVu = new DichVuRepon(_httpClient, _connectionStrings);
            ChiTietThuChi = new ChiTietThuChiRepon(_httpClient, _connectionStrings);
            XacThuc = new XacThucRepon(_httpClient,_connectionStrings);
        }
    }
}
