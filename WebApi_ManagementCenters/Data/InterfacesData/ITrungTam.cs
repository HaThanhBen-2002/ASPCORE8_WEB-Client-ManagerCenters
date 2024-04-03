using Data.Models;
namespace Data.InterfacesData
{
    public interface ITrungTam
    {
        object LoadingDataTableView(TrungTam item, int skip, int take);
        Task<ICollection<TrungTam>> Search(TrungTam item);
        Task<List<object>> SearchName(TrungTam item);
        Task<int> SearchCount(TrungTam item);
        Task<ICollection<TrungTam>> GetAll();
        Task<TrungTam> GetById(int id);
        Task<bool> Create(TrungTam item);
        Task<bool> Update(TrungTam item);
        Task<bool> Delete(int id, string nguoiXoa, string ngayXoa);
        Task<bool> CheckId(int id);
        Task<bool> Save();
    }
}
