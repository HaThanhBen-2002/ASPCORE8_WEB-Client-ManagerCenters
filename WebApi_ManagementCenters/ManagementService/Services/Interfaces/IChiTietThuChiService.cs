using Data.Dtos;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Services.Interfaces
{
    public interface IChiTietThuChiService
    {
        Task<ICollection<ChiTietThuChiDto>> Search(ChiTietThuChiDto item);
        Task<ICollection<ChiTietThuChiDto>> SearchByPhieuThuChiId(int id);
        Task<bool> Create(ChiTietThuChiDto item);
        Task<bool> Update(ChiTietThuChiDto item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
    }
}
