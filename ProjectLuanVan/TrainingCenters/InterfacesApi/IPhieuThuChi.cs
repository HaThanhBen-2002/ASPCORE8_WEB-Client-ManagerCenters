using TrainingCenters.Models;
namespace TrainingCenters.InterfacesApi
{
    public interface IPhieuThuChi
    {
        Task<ResponseDI<object>> LoadingDataTableView(PhieuThuChi item, int skip, int take, string tk);
        Task<ResponseDI<ICollection<PhieuThuChi>>> Search(PhieuThuChi item, string tk);
        Task<ResponseDI<double>> SearchTongTien(PhieuThuChi item, string tk);
        Task<ResponseDI<int>> SearchCount(PhieuThuChi item, string tk);
        Task<ResponseDI<ICollection<PhieuThuChi>>> GetAll(string tk);
        Task<ResponseDI<PhieuThuChi>> GetById(int id, string tk);
        Task<ResponseDI<bool>> Create(PhieuThuChi item, string tk);
        Task<ResponseDI<bool>> Update(PhieuThuChi item, string tk);
        Task<ResponseDI<bool>> Delete(int id, string nguoiXoa, string tk);
        Task<ResponseDI<bool>> CheckId(int id, string tk);
    }

}
