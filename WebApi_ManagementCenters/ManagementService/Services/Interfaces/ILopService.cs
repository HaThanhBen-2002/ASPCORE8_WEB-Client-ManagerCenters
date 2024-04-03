using Data.Dtos;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Services.Interfaces
{
    public interface ILopService
    {
        object LoadingDataTableView(LopDto item, int skip, int take);
        Task<ICollection<LopDto>> Search(LopDto item);
        Task<List<object>> SearchName(LopDto item);
        Task<int> SearchCount(LopDto item);
        Task<ICollection<LopDto>> GetAll();
        Task<LopDto> GetById(int id);
        Task<bool> Create(LopDto item);
        Task<bool> Update(LopDto item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
    }
}
