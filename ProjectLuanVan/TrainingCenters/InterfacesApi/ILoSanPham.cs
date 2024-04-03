using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;
namespace TrainingCenters.InterfacesApi
{
    public interface ILoSanPham
    {
        Task<object> LoadingDataTableView(LoSanPham item, int skip, int take);
        Task<ICollection<LoSanPham>> Search(LoSanPham item);
        Task<List<LoSanPhamMN>> SearchName(LoSanPham item);
        Task<int> SearchCount(LoSanPham item);
        Task<ICollection<LoSanPham>> GetAll();
        Task<LoSanPham> GetById(int id);
        Task<bool> Create(LoSanPham item);
        Task<bool> Update(LoSanPham item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
        
    }
}
