using AutoMapper;
using Data.InterfacesData;
using Data.Models;
using Data.RepositoryData;
using ManagementService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Services.Repository
{
    public class AppServices : IAppServices
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

        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AppServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            TrungTam = new TrungTamService(_unitOfWork, _mapper);
            SuDungDichVu = new SuDungDichVuService(_unitOfWork, _mapper);
            SanPham = new SanPhamService(_unitOfWork, _mapper);
            PhieuThuChi = new PhieuThuChiService(_unitOfWork, _mapper);
            NhanVien = new NhanVienService(_unitOfWork, _mapper);
            NhaCungCap = new NhaCungCapService(_unitOfWork, _mapper);
            MonHoc = new MonHocService(_unitOfWork, _mapper);
            LoSanPham = new LoSanPhamService(_unitOfWork, _mapper);
            Lop = new LopService(_unitOfWork, _mapper);
            KetQua = new KetQuaService(_unitOfWork, _mapper);
            HocSinh = new HocSinhService(_unitOfWork, _mapper);
            DichVu = new DichVuService(_unitOfWork, _mapper);
            ChiTietThuChi = new ChiTietThuChiService(_unitOfWork, _mapper);
        }
    }
}
