using Data.Dtos;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Services.Interfaces
{
    public interface INhaCungCapService
    {
        object LoadingDataTableView(NhaCungCapDto item, int skip, int take);
        Task<ICollection<NhaCungCapDto>> Search(NhaCungCapDto item);
        Task<List<object>> SearchName(NhaCungCapDto item);
        Task<int> SearchCount(NhaCungCapDto item);
        Task<ICollection<NhaCungCapDto>> GetAll();
        Task<NhaCungCapDto> GetById(int id);
        Task<bool> Create(NhaCungCapDto item);
        Task<bool> Update(NhaCungCapDto item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
    }
}
