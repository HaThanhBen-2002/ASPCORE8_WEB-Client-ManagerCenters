using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;
namespace TrainingCenters.InterfacesApi
{
    public interface ILop
    {
        Task<object> LoadingDataTableView(Lop item, int skip, int take, string tk);
        Task<ICollection<Lop>> Search(Lop item, string tk);
        Task<List<LopMN>> SearchName(Lop item, string tk);
        Task<int> SearchCount(Lop item, string tk);
        Task<ICollection<Lop>> GetAll( string tk);
        Task<Lop> GetById(int id, string tk);
        Task<bool> Create(Lop item, string tk);
        Task<bool> Update(Lop item, string tk);
        Task<bool> Delete(int id, string nguoiXoa, string tk);
        Task<bool> CheckId(int id, string tk);
        
    }
}
