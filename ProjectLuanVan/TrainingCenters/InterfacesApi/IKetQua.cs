using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface IKetQua
    {
        Task<ICollection<KetQua>> GetAll();
        Task<object> LoadingDataTableView(KetQua item, int skip, int take);
        Task<ICollection<KetQua>> Search(KetQua item);
        Task<List<KetQuaMN>> SearchName(KetQua item);
        Task<int> SearchCount(KetQua item);
        Task<KetQua> GetById(int id);
        Task<bool> Create(KetQua item);
        Task<bool> Update(KetQua item);
        Task<bool> Delete(int id,string nguoiXoa);
        Task<bool> CheckId(int id);
        
    }
}
