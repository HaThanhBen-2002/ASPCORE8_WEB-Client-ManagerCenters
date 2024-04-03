using Data.Dtos;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Services.Interfaces
{
    public interface ISanPhamService
    {
        object LoadingDataTableView(SanPhamDto item, int skip, int take);
        Task<ICollection<SanPhamDto>> Search(SanPhamDto item);
        Task<List<object>> SearchName(SanPhamDto item);
        Task<int> SearchCount(SanPhamDto item);
        Task<ICollection<SanPhamDto>> GetAll();
        Task<SanPhamDto> GetById(int id);
        Task<bool> Create(SanPhamDto item);
        Task<bool> Update(SanPhamDto item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
    }
}
