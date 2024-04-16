
using TrainingCenters.Models;
using TrainingCenters.Models.ModeIMN;

namespace TrainingCenters.InterfacesApi
{
    public interface IDichVu
    {
        Task<ICollection<DichVu>> GetAll(string tk);
        Task<DichVu> GetById(int id, string tk);
        Task<object> LoadingDataTableView(DichVu item, int skip, int take, string tk);
        Task<ICollection<DichVu>> Search(DichVu item, string tk);
        Task<List<DichVuMN>> SearchName(DichVu item, string tk);
        Task<int> SearchCount(DichVu item, string tk);
        Task<bool> Create(DichVu item, string tk);
        Task<bool> Update(DichVu item, string tk);
        Task<bool> Delete(int id, string nguoiXoa, string tk);
        Task<bool> CheckId(int id, string tk);
        
    }
}
