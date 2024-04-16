using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;
namespace TrainingCenters.InterfacesApi
{
    public interface ILoSanPham
    {
        Task<object> LoadingDataTableView(LoSanPham item, int skip, int take, string tk);
        Task<ICollection<LoSanPham>> Search(LoSanPham item, string tk);
        Task<List<LoSanPhamMN>> SearchName(LoSanPham item, string tk);
        Task<int> SearchCount(LoSanPham item, string tk);
        Task<ICollection<LoSanPham>> GetAll(string tk);
        Task<LoSanPham> GetById(int id, string tk);
        Task<bool> Create(LoSanPham item, string tk);
        Task<bool> Update(LoSanPham item, string tk);
        Task<bool> Delete(int id, string nguoiXoa, string tk);
        Task<bool> CheckId(int id, string tk);
        
    }
}
