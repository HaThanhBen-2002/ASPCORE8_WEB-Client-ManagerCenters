using Data.Dtos;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Services.Interfaces
{
    public interface IPhieuThuChiService
    {
        object LoadingDataTableView(PhieuThuChiDto item, int skip, int take);
        Task<ICollection<PhieuThuChiDto>> Search(PhieuThuChiDto item);
        Task<double> SearchTongTien(PhieuThuChiDto item);
        Task<int> SearchCount(PhieuThuChiDto item);
        Task<ICollection<PhieuThuChiDto>> GetAll();
        Task<PhieuThuChiDto> GetById(int id);
        Task<bool> Create(PhieuThuChiDto item);
        Task<bool> Update(PhieuThuChiDto item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
    }
}
