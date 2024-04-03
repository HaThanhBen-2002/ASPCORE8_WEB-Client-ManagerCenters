
using TrainingCenters.Models;
using TrainingCenters.Models.ModeIMN;

namespace TrainingCenters.InterfacesApi
{
    public interface IDichVu
    {
        Task<ICollection<DichVu>> GetAll();
        Task<DichVu> GetById(int id);
        Task<object> LoadingDataTableView(DichVu item, int skip, int take);
        Task<ICollection<DichVu>> Search(DichVu item);
        Task<List<DichVuMN>> SearchName(DichVu item);
        Task<int> SearchCount(DichVu item);
        Task<bool> Create(DichVu item);
        Task<bool> Update(DichVu item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
        
    }
}
