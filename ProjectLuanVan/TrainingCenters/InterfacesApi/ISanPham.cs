using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface ISanPham
    {
        Task<object> LoadingDataTableView(SanPham item, int skip, int take, string tk);
        Task<ICollection<SanPham>> Search(SanPham item, string tk);
        Task<List<SanPhamMN>> SearchName(SanPham item, string tk);
        Task<int> SearchCount(SanPham item, string tk);
        Task<ICollection<SanPham>> GetAll(string tk);
        Task<SanPham> GetById(int id, string tk);
        Task<bool> Create(SanPham item, string tk);
        Task<bool> Update(SanPham item, string tk);
        Task<bool> Delete(int id, string nguoiXoa, string tk);
        Task<bool> CheckId(int id, string tk);
        
    }
}
