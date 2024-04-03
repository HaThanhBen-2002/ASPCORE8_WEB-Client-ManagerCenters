
using TrainingCenters.Models;

namespace TrainingCenters.InterfacesApi
{
    public interface IChiTietThuChi
    {
        Task<ICollection<ChiTietThuChi>> Search(ChiTietThuChi item);
        Task<ICollection<ChiTietThuChi>> SearchByPhieuThuChiId(int id);
        Task<bool> Create(ChiTietThuChi item);
        Task<bool> Update(ChiTietThuChi item);
        Task<bool> Delete(int id,string nguoiXoa);
        Task<bool> CheckId(int id);
    }
}
