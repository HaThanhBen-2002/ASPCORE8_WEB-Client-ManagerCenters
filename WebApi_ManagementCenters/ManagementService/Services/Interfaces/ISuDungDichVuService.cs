using Data.Dtos;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Services.Interfaces
{
    public interface ISuDungDichVuService
    {
        object LoadingDataTableView(SuDungDichVuDto item, int skip, int take);
        Task<ICollection<SuDungDichVuDto>> Search(SuDungDichVuDto item);
        Task<List<object>> SearchName(SuDungDichVuDto item);
        Task<int> SearchCount(SuDungDichVuDto item);
        Task<ICollection<SuDungDichVuDto>> GetAll();
        Task<SuDungDichVuDto> GetById(int id);
        Task<bool> Create(SuDungDichVuDto item);
        Task<bool> Update(SuDungDichVuDto item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
    }
}
