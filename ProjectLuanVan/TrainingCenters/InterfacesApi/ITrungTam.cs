using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;
namespace TrainingCenters.InterfacesApi
{
    public interface ITrungTam
    {
        Task<object> LoadingDataTableView(TrungTam item, int skip, int take);
        Task<ICollection<TrungTam>> Search(TrungTam item);
        Task<List<TrungTamMN>> SearchName(TrungTam item);
        Task<int> SearchCount(TrungTam item);
        Task<ICollection<TrungTam>> GetAll();
        Task<TrungTam> GetById(int id);
        Task<bool> Create(TrungTam item);
        Task<bool> Update(TrungTam item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
        
    }
}
