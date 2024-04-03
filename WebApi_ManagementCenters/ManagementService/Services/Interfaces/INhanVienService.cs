using Data.Dtos;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Services.Interfaces
{
    public interface INhanVienService
    {
        object LoadingDataTableView(NhanVienDto item, int skip, int take);
        Task<ICollection<NhanVienDto>> Search(NhanVienDto item);
        Task<List<object>> SearchName(NhanVienDto item);
        Task<int> SearchCount(NhanVienDto item);
        Task<ICollection<NhanVienDto>> GetAll();
        Task<NhanVienDto> GetById(int id);
        Task<bool> Create(NhanVienDto item);
        Task<bool> Update(NhanVienDto item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
    }
}
