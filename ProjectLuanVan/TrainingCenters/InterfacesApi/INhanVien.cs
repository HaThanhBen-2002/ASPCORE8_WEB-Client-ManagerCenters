using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface INhanVien
    {
        Task<object> LoadingDataTableView(NhanVien item, int skip, int take, string tk);
        Task<ICollection<NhanVien>> Search(NhanVien item, string tk);
        Task<List<NhanVienMN>> SearchName(NhanVien item, string tk);
        Task<int> SearchCount(NhanVien item, string tk);
        Task<ICollection<NhanVien>> GetAll(string tk);
        Task<NhanVien> GetById(int id, string tk);
        Task<bool> Create(NhanVien item, string tk);
        Task<bool> Update(NhanVien item, string tk);
        Task<bool> Delete(int id, string nguoiXoa, string tk);
        Task<bool> CheckId(int id, string tk);
        
    }
}
