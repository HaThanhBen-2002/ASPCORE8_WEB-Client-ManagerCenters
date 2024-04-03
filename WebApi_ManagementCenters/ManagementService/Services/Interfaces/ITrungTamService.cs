using Data.Dtos;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Services.Interfaces
{
    public interface ITrungTamService
    {
        object LoadingDataTableView(TrungTamDto item, int skip, int take);
        Task<ICollection<TrungTamDto>> Search(TrungTamDto item);
        Task<List<object>> SearchName(TrungTamDto item);
        Task<int> SearchCount(TrungTamDto item);
        Task<ICollection<TrungTamDto>> GetAll();
        Task<TrungTamDto> GetById(int id);
        Task<bool> Create(TrungTamDto item);
        Task<bool> Update(TrungTamDto item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
    }
}
