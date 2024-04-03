using Data.Models;
using Data.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InterfacesData
{
    public interface IHocSinh
    {
        Task<ICollection<HocSinh>> GetAll();
        Task<HocSinh> GetById(int id);
        Task<HocSinhView> GetHocSinhView(int id);
        object LoadingDataTableView(HocSinh item, int skip, int take);
        Task<ICollection<HocSinh>> Search(HocSinh item);
        Task<List<object>> SearchName(HocSinh item);
        Task<int> SearchCount(HocSinh item);
        Task<bool> Create(HocSinh item);
        Task<bool> Update(HocSinh item);
        Task<bool> Delete(int id, string nguoiXoa, string ngayXoa);
        Task<bool> CheckId(int id);
        Task<bool> Save();
    }
}
