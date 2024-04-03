using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InterfacesData
{
    public interface IKetQua
    {
        Task<ICollection<KetQua>> GetAll();
        object LoadingDataTableView(KetQua item, int skip, int take);
        Task<ICollection<KetQua>> Search(KetQua item);
        Task<List<object>> SearchName(KetQua item);
        Task<int> SearchCount(KetQua item);
        Task<KetQua> GetById(int id);
        Task<bool> Create(KetQua item);
        Task<bool> Update(KetQua item);
        Task<bool> Delete(int id,string nguoiXoa, string ngayXoa);
        Task<bool> CheckId(int id);
        Task<bool> Save();
    }
}
