using Data.Dtos;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Services.Interfaces
{
    public interface IKetQuaService
    {
        Task<ICollection<KetQuaDto>> GetAll();
        object LoadingDataTableView(KetQuaDto item, int skip, int take);
        Task<ICollection<KetQuaDto>> Search(KetQuaDto item);
        Task<List<object>> SearchName(KetQuaDto item);
        Task<int> SearchCount(KetQuaDto item);
        Task<KetQuaDto> GetById(int id);
        Task<bool> Create(KetQuaDto item);
        Task<bool> Update(KetQuaDto item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
    }
}
