using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InterfacesData
{
    public interface ILoSanPham
    {
        object LoadingDataTableView(LoSanPham item, int skip, int take);
        Task<ICollection<LoSanPham>> Search(LoSanPham item);
        Task<List<object>> SearchName(LoSanPham item);
        Task<int> SearchCount(LoSanPham item);
        Task<ICollection<LoSanPham>> GetAll();
        Task<LoSanPham> GetById(int id);
        Task<bool> Create(LoSanPham item);
        Task<bool> Update(LoSanPham item);
        Task<bool> Delete(int id, string nguoiXoa, string ngayXoa);
        Task<bool> CheckId(int id);
        Task<bool> Save();
    }
}
