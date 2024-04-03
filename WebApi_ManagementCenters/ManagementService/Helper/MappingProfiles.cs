using AutoMapper;
using Data.Dtos;
using Data.Models;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<TrungTam, TrungTamDto>();
            CreateMap<SuDungDichVu, SuDungDichVuDto>();
            CreateMap<SanPham, SanPhamDto>();
            CreateMap<PhieuThuChi, PhieuThuChiDto>();
            CreateMap<NhanVien, NhanVienDto>();
            CreateMap<NhaCungCap, NhaCungCapDto>();
            CreateMap<MonHoc, MonHocDto>();
            CreateMap<LoSanPham, LoSanPhamDto>();
            CreateMap<Lop, LopDto>();
            CreateMap<KetQua, KetQuaDto>();
            CreateMap<HocSinh, HocSinhDto>();
            CreateMap<DichVu, DichVuDto>();
            CreateMap<ChiTietThuChi, ChiTietThuChiDto>();


            CreateMap<TrungTamDto, TrungTam>();
            CreateMap<SuDungDichVuDto, SuDungDichVu>();
            CreateMap<SanPhamDto, SanPham>();
            CreateMap<PhieuThuChiDto, PhieuThuChi>();
            CreateMap<NhanVienDto, NhanVien>();
            CreateMap<NhaCungCapDto, NhaCungCap>();
            CreateMap<MonHocDto, MonHoc>();
            CreateMap<LoSanPhamDto, LoSanPham>();
            CreateMap<LopDto, Lop>();
            CreateMap<KetQuaDto, KetQua>();
            CreateMap<HocSinhDto, HocSinh>();
            CreateMap<DichVuDto, DichVu>();
            CreateMap<ChiTietThuChiDto, ChiTietThuChi>();
        }
    }
}
