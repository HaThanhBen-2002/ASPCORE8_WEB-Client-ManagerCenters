using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InterfacesData
{
    public interface INhanVien
    {
        object LoadingDataTableView(NhanVien item, int skip, int take);
        Task<ICollection<NhanVien>> Search(NhanVien item);
        Task<List<object>> SearchName(NhanVien item);
        Task<int> SearchCount(NhanVien item);
        Task<ICollection<NhanVien>> GetAll();
        Task<NhanVien> GetById(int id);
        Task<bool> Create(NhanVien item);
        Task<bool> Update(NhanVien item);
        Task<bool> Delete(int id, string nguoiXoa, string ngayXoa);
        Task<bool> CheckId(int id);
        Task<bool> Save();
    }
}
