using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InterfacesData
{
    public interface IChiTietThuChi
    {
        Task<ICollection<ChiTietThuChi>> Search(ChiTietThuChi item);
        Task<ICollection<ChiTietThuChi>> SearchByPhieuThuChiId(int id);
        Task<bool> Create(ChiTietThuChi item);
        Task<bool> Update(ChiTietThuChi item);
        Task<bool> Delete(int id,string nguoiXoa, string ngayXoa);
        Task<bool> CheckId(int id);
        Task<bool> Save();
    }
}
