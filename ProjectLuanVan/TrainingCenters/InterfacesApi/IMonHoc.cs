using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface IMonHoc
    {
        Task<object> LoadingDataTableView(MonHoc item, int skip, int take, string tk);
        Task<ICollection<MonHoc>> Search(MonHoc item, string tk);
        Task<List<MonHocMN>> SearchName(MonHoc item, string tk);
        Task<int> SearchCount(MonHoc item, string tk);
        Task<ICollection<MonHoc>> GetAll(string tk);
        Task<MonHoc> GetById(int id, string tk);
        Task<bool> Create(MonHoc item, string tk);
        Task<bool> Update(MonHoc item, string tk);
        Task<bool> Delete(int id, string nguoiXoa, string tk);
        Task<bool> CheckId(int id, string tk);
        
    }
}
