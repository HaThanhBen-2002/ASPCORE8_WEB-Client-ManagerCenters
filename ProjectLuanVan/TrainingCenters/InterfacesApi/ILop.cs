using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;
namespace TrainingCenters.InterfacesApi
{
    public interface ILop
    {
        Task<object> LoadingDataTableView(Lop item, int skip, int take);
        Task<ICollection<Lop>> Search(Lop item);
        Task<List<LopMN>> SearchName(Lop item);
        Task<int> SearchCount(Lop item);
        Task<ICollection<Lop>> GetAll();
        Task<Lop> GetById(int id);
        Task<bool> Create(Lop item);
        Task<bool> Update(Lop item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
        
    }
}
