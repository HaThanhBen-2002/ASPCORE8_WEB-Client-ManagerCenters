using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InterfacesData
{
    public interface ISuDungDichVu
    {
        object LoadingDataTableView(SuDungDichVu item, int skip, int take);
        Task<ICollection<SuDungDichVu>> Search(SuDungDichVu item);
        Task<List<object>> SearchName(SuDungDichVu item);
        Task<int> SearchCount(SuDungDichVu item);
        Task<ICollection<SuDungDichVu>> GetAll();
        Task<SuDungDichVu> GetById(int id);
        Task<bool> Create(SuDungDichVu item);
        Task<bool> Update(SuDungDichVu item);
        Task<bool> Delete(int id, string nguoiXoa, string ngayXoa);
        Task<bool> CheckId(int id);
        Task<bool> Save();
    }
}
