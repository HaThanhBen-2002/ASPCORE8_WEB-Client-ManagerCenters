using Data.Models.ModelView;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Dtos;

namespace ManagementService.Services.Interfaces
{
    public interface IHocSinhService
    {
        Task<ICollection<HocSinhDto>> GetAll();
        Task<HocSinhDto> GetById(int id);
        Task<HocSinhView> GetHocSinhView(int id);
        object LoadingDataTableView(HocSinhDto item, int skip, int take);
        Task<ICollection<HocSinhDto>> Search(HocSinhDto item);
        Task<List<object>> SearchName(HocSinhDto item);
        Task<int> SearchCount(HocSinhDto item);
        Task<bool> Create(HocSinhDto item);
        Task<bool> Update(HocSinhDto item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
    }
}
