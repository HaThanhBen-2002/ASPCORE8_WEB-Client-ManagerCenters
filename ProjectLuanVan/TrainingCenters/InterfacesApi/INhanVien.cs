using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface INhanVien
    {
        Task<object> LoadingDataTableView(NhanVien item, int skip, int take);
        Task<ICollection<NhanVien>> Search(NhanVien item);
        Task<List<NhanVienMN>> SearchName(NhanVien item);
        Task<int> SearchCount(NhanVien item);
        Task<ICollection<NhanVien>> GetAll();
        Task<NhanVien> GetById(int id);
        Task<bool> Create(NhanVien item);
        Task<bool> Update(NhanVien item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
        
    }
}
