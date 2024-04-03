using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface IMonHoc
    {
        Task<object> LoadingDataTableView(MonHoc item, int skip, int take);
        Task<ICollection<MonHoc>> Search(MonHoc item);
        Task<List<MonHocMN>> SearchName(MonHoc item);
        Task<int> SearchCount(MonHoc item);
        Task<ICollection<MonHoc>> GetAll();
        Task<MonHoc> GetById(int id);
        Task<bool> Create(MonHoc item);
        Task<bool> Update(MonHoc item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
        
    }
}
