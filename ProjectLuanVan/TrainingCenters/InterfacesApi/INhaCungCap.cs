using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;
namespace TrainingCenters.InterfacesApi
{
    public interface INhaCungCap
    {
        Task<object> LoadingDataTableView(NhaCungCap item, int skip, int take, string tk);
        Task<ICollection<NhaCungCap>> Search(NhaCungCap item, string tk);
        Task<List<NhaCungCapMN>> SearchName(NhaCungCap item, string tk);
        Task<int> SearchCount(NhaCungCap item, string tk);
        Task<ICollection<NhaCungCap>> GetAll(string tk);
        Task<NhaCungCap> GetById(int id, string tk);
        Task<bool> Create(NhaCungCap item, string tk);
        Task<bool> Update(NhaCungCap item, string tk);
        Task<bool> Delete(int id, string nguoiXoa, string tk);
        Task<bool> CheckId(int id, string tk);
        
    }
}
