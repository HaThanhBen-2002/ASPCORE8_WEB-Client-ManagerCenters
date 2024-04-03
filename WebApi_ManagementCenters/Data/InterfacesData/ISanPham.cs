using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InterfacesData
{
    public interface ISanPham
    {
        object LoadingDataTableView(SanPham item, int skip, int take);
        Task<ICollection<SanPham>> Search(SanPham item);
        Task<List<object>> SearchName(SanPham item);
        Task<int> SearchCount(SanPham item);
        Task<ICollection<SanPham>> GetAll();
        Task<SanPham> GetById(int id);
        Task<bool> Create(SanPham item);
        Task<bool> Update(SanPham item);
        Task<bool> Delete(int id, string nguoiXoa, string ngayXoa);
        Task<bool> CheckId(int id);
        Task<bool> Save();
    }
}
