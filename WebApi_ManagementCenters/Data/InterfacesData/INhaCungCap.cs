using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InterfacesData
{
    public interface INhaCungCap
    {
        object LoadingDataTableView(NhaCungCap item, int skip, int take);
        Task<ICollection<NhaCungCap>> Search(NhaCungCap item);
        Task<List<object>> SearchName(NhaCungCap item);
        Task<int> SearchCount(NhaCungCap item);
        Task<ICollection<NhaCungCap>> GetAll();
        Task<NhaCungCap> GetById(int id);
        Task<bool> Create(NhaCungCap item);
        Task<bool> Update(NhaCungCap item);
        Task<bool> Delete(int id, string nguoiXoa, string ngayXoa);
        Task<bool> CheckId(int id);
        Task<bool> Save();
    }
}
