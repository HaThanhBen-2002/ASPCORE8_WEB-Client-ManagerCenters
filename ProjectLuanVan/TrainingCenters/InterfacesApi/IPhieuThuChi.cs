using TrainingCenters.Models;
namespace TrainingCenters.InterfacesApi
{
    public interface IPhieuThuChi
    {
        Task<object> LoadingDataTableView(PhieuThuChi item, int skip, int take, string tk);
        Task<ICollection<PhieuThuChi>> Search(PhieuThuChi item, string tk);
        Task<double> SearchTongTien(PhieuThuChi item, string tk);
        Task<int> SearchCount(PhieuThuChi item, string tk);
        Task<ICollection<PhieuThuChi>> GetAll(string tk);
        Task<PhieuThuChi> GetById(int id, string tk);
        Task<bool> Create(PhieuThuChi item, string tk);
        Task<bool> Update(PhieuThuChi item, string tk);
        Task<bool> Delete(int id, string nguoiXoa, string tk);
        Task<bool> CheckId(int id, string tk);
        
    }
}
