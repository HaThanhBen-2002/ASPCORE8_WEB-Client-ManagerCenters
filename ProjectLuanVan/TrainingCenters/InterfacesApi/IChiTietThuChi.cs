
using TrainingCenters.Models;

namespace TrainingCenters.InterfacesApi
{
    public interface IChiTietThuChi
    {
        Task<ICollection<ChiTietThuChi>> Search(ChiTietThuChi item, string tk);
        Task<ICollection<ChiTietThuChi>> SearchByPhieuThuChiId(int id, string tk);
        Task<bool> Create(ChiTietThuChi item, string tk);
        Task<bool> Update(ChiTietThuChi item, string tk);
        Task<bool> Delete(int id,string nguoiXoa, string tk);
        Task<bool> CheckId(int id, string tk);
    }
}
