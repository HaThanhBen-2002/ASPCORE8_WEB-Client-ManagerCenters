using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface ISuDungDichVu
    {
        Task<object> LoadingDataTableView(SuDungDichVu item, int skip, int take, string tk);
        Task<ICollection<SuDungDichVu>> Search(SuDungDichVu item, string tk);
        Task<List<SuDungDichVuMN>> SearchName(SuDungDichVu item, string tk);
        Task<int> SearchCount(SuDungDichVu item, string tk);
        Task<ICollection<SuDungDichVu>> GetAll( string tk);
        Task<SuDungDichVu> GetById(int id, string tk);
        Task<bool> Create(SuDungDichVu item, string tk);
        Task<bool> Update(SuDungDichVu item, string tk);
        Task<bool> Delete(int id, string nguoiXoa, string tk);
        Task<bool> CheckId(int id, string tk);
        
    }
}
