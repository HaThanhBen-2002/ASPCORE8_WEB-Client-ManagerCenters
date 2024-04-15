using TrainingCenters.Models;
namespace TrainingCenters.InterfacesApi
{
    public interface IPhieuThuChi
    {
        Task<object> LoadingDataTableView(PhieuThuChi item, int skip, int take);
        Task<ICollection<PhieuThuChi>> Search(PhieuThuChi item);
        Task<double> SearchTongTien(PhieuThuChi item);
        Task<int> SearchCount(PhieuThuChi item);
        Task<ICollection<PhieuThuChi>> GetAll();
        Task<PhieuThuChi> GetById(int id);
        Task<bool> Create(PhieuThuChi item);
        Task<bool> Update(PhieuThuChi item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
        
    }
}
