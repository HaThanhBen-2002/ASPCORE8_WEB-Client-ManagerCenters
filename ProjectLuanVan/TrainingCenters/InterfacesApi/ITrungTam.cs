using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;
namespace TrainingCenters.InterfacesApi
{
    public interface ITrungTam
    {
        Task<object> LoadingDataTableView(TrungTam item, int skip, int take, string tk);
        Task<ICollection<TrungTam>> Search(TrungTam item, string tk);
        Task<List<TrungTamMN>> SearchName(TrungTam item, string tk);
        Task<int> SearchCount(TrungTam item, string tk);
        Task<ICollection<TrungTam>> GetAll(string tk);
        Task<TrungTam> GetById(int id, string tk);
        Task<bool> Create(TrungTam item, string tk);
        Task<bool> Update(TrungTam item, string tk);
        Task<bool> Delete(int id, string nguoiXoa, string tk);
        Task<bool> CheckId(int id, string tk);
        
    }
}
