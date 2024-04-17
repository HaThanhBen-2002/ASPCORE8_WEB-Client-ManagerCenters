using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface ISuDungDichVu
    {
        Task<ResponseDI<object>> LoadingDataTableView(SuDungDichVu item, int skip, int take, string tk);
        Task<ResponseDI<ICollection<SuDungDichVu>>> Search(SuDungDichVu item, string tk);
        Task<ResponseDI<List<SuDungDichVuMN>>> SearchName(SuDungDichVu item, string tk);
        Task<ResponseDI<int>> SearchCount(SuDungDichVu item, string tk);
        Task<ResponseDI<ICollection<SuDungDichVu>>> GetAll(string tk);
        Task<ResponseDI<SuDungDichVu>> GetById(int id, string tk);
        Task<ResponseDI<bool>> Create(SuDungDichVu item, string tk);
        Task<ResponseDI<bool>> Update(SuDungDichVu item, string tk);
        Task<ResponseDI<bool>> Delete(int id, string nguoiXoa, string tk);
        Task<ResponseDI<bool>> CheckId(int id, string tk);
    }

}
