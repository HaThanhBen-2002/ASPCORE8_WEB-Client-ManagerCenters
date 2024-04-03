using Data.Dtos;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Services.Interfaces
{
    public interface ILoSanPhamService
    {
        object LoadingDataTableView(LoSanPhamDto item, int skip, int take);
        Task<ICollection<LoSanPhamDto>> Search(LoSanPhamDto item);
        Task<List<object>> SearchName(LoSanPhamDto item);
        Task<int> SearchCount(LoSanPhamDto item);
        Task<ICollection<LoSanPhamDto>> GetAll();
        Task<LoSanPhamDto> GetById(int id);
        Task<bool> Create(LoSanPhamDto item);
        Task<bool> Update(LoSanPhamDto item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
    }
}
