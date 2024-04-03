using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface ISuDungDichVu
    {
        Task<object> LoadingDataTableView(SuDungDichVu item, int skip, int take);
        Task<ICollection<SuDungDichVu>> Search(SuDungDichVu item);
        Task<List<SuDungDichVuMN>> SearchName(SuDungDichVu item);
        Task<int> SearchCount(SuDungDichVu item);
        Task<ICollection<SuDungDichVu>> GetAll();
        Task<SuDungDichVu> GetById(int id);
        Task<bool> Create(SuDungDichVu item);
        Task<bool> Update(SuDungDichVu item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
        
    }
}
