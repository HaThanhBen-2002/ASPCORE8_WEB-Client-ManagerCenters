using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InterfacesData
{
    public interface IPhieuThuChi
    {
        object LoadingDataTableView(PhieuThuChi item, int skip, int take);
        Task<ICollection<PhieuThuChi>> Search(PhieuThuChi item);
        Task<double> SearchTongTien(PhieuThuChi item);
        Task<int> SearchCount(PhieuThuChi item);
        Task<ICollection<PhieuThuChi>> GetAll();
        Task<PhieuThuChi> GetById(int id);
        Task<bool> Create(PhieuThuChi item);
        Task<bool> Update(PhieuThuChi item);
        Task<bool> Delete(int id, string nguoiXoa, string ngayXoa);
        Task<bool> CheckId(int id);
        Task<bool> Save();
    }
}
