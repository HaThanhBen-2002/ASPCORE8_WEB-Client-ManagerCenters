using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InterfacesData
{
    public interface IDichVu
    {
        Task<ICollection<DichVu>> GetAll();
        Task<DichVu> GetById(int id);
        object LoadingDataTableView(DichVu item, int skip, int take);
        Task<ICollection<DichVu>> Search(DichVu item);
        Task<List<object>> SearchName(DichVu item);
        Task<int> SearchCount(DichVu item);
        Task<bool> Create(DichVu item);
        Task<bool> Update(DichVu item);
        Task<bool> Delete(int id, string nguoiXoa, string ngayXoa);
        Task<bool> CheckId(int id);
        Task<bool> Save();
    }
}
