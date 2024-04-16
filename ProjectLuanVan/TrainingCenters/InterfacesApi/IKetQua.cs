using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface IKetQua
    {
        Task<ICollection<KetQua>> GetAll(string tk);
        Task<object> LoadingDataTableView(KetQua item, int skip, int take, string tk);
        Task<ICollection<KetQua>> Search(KetQua item, string tk);
        Task<List<KetQuaMN>> SearchName(KetQua item, string tk);
        Task<int> SearchCount(KetQua item, string tk);
        Task<KetQua> GetById(int id, string tk);
        Task<bool> Create(KetQua item, string tk);
        Task<bool> Update(KetQua item, string tk);
        Task<bool> Delete(int id,string nguoiXoa, string tk);
        Task<bool> CheckId(int id, string tk);
        
    }
}
