
using TrainingCenters.Models;

namespace TrainingCenters.InterfacesApi
{
    public interface IChiTietThuChi
    {
        Task<ResponseDI<ICollection<ChiTietThuChi>>> Search(ChiTietThuChi item, string tk);
        Task<ResponseDI<ICollection<ChiTietThuChi>>> SearchByPhieuThuChiId(int id, string tk);
        Task<ResponseDI<bool>> Create(ChiTietThuChi item, string tk);
        Task<ResponseDI<bool>> Update(ChiTietThuChi item, string tk);
        Task<ResponseDI<bool>> Delete(int id, string nguoiXoa, string tk);
        Task<ResponseDI<bool>> CheckId(int id, string tk);
    }

}
