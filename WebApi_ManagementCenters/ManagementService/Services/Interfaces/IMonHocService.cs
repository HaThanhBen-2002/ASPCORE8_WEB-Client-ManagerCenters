using Data.Dtos;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Services.Interfaces
{
    public interface IMonHocService
    {
        object LoadingDataTableView(MonHocDto item, int skip, int take);
        Task<ICollection<MonHocDto>> Search(MonHocDto item);
        Task<List<object>> SearchName(MonHocDto item);
        Task<int> SearchCount(MonHocDto item);
        Task<ICollection<MonHocDto>> GetAll();
        Task<MonHocDto> GetById(int id);
        Task<bool> Create(MonHocDto item);
        Task<bool> Update(MonHocDto item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
    }
}
