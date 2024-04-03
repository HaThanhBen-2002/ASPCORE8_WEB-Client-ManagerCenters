using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;
namespace TrainingCenters.InterfacesApi
{
    public interface INhaCungCap
    {
        Task<object> LoadingDataTableView(NhaCungCap item, int skip, int take);
        Task<ICollection<NhaCungCap>> Search(NhaCungCap item);
        Task<List<NhaCungCapMN>> SearchName(NhaCungCap item);
        Task<int> SearchCount(NhaCungCap item);
        Task<ICollection<NhaCungCap>> GetAll();
        Task<NhaCungCap> GetById(int id);
        Task<bool> Create(NhaCungCap item);
        Task<bool> Update(NhaCungCap item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
        
    }
}
