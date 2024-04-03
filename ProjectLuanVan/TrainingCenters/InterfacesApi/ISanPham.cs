using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface ISanPham
    {
        Task<object> LoadingDataTableView(SanPham item, int skip, int take);
        Task<ICollection<SanPham>> Search(SanPham item);
        Task<List<SanPhamMN>> SearchName(SanPham item);
        Task<int> SearchCount(SanPham item);
        Task<ICollection<SanPham>> GetAll();
        Task<SanPham> GetById(int id);
        Task<bool> Create(SanPham item);
        Task<bool> Update(SanPham item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
        
    }
}
