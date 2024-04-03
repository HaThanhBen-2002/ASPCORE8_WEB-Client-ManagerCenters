using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Data.InterfacesData
{
    public interface ILop
    {
        object LoadingDataTableView(Lop item, int skip, int take);
        Task<ICollection<Lop>> Search(Lop item);
        Task<List<object>> SearchName(Lop item);
        Task<int> SearchCount(Lop item);
        Task<ICollection<Lop>> GetAll();
        Task<Lop> GetById(int id);
        Task<bool> Create(Lop item);
        Task<bool> Update(Lop item);
        Task<bool> Delete(int id, string nguoiXoa, string ngayXoa);
        Task<bool> CheckId(int id);
        Task<bool> Save();
    }
}
