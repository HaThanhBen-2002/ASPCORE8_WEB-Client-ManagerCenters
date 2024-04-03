using Data.Dtos;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Services.Interfaces
{
    public interface IDichVuService
    {
        Task<ICollection<DichVuDto>> GetAll();
        Task<DichVuDto> GetById(int id);
        object LoadingDataTableView(DichVuDto item, int skip, int take);
        Task<ICollection<DichVuDto>> Search(DichVuDto item);
        Task<List<object>> SearchName(DichVuDto item);
        Task<int> SearchCount(DichVuDto item);
        Task<bool> Create(DichVuDto item);
        Task<bool> Update(DichVuDto item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
    }
}
