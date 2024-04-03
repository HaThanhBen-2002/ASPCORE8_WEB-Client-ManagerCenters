using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InterfacesData
{
    public interface IMonHoc
    {
        object LoadingDataTableView(MonHoc item, int skip, int take);
        Task<ICollection<MonHoc>> Search(MonHoc item);
        Task<List<object>> SearchName(MonHoc item);
        Task<int> SearchCount(MonHoc item);
        Task<ICollection<MonHoc>> GetAll();
        Task<MonHoc> GetById(int id);
        Task<bool> Create(MonHoc item);
        Task<bool> Update(MonHoc item);
        Task<bool> Delete(int id, string nguoiXoa, string ngayXoa);
        Task<bool> CheckId(int id);
        Task<bool> Save();
    }
}
