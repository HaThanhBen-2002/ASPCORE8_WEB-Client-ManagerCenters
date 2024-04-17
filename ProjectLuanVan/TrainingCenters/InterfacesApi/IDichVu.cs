
using Azure;
using TrainingCenters.Models;
using TrainingCenters.Models.ModeIMN;

namespace TrainingCenters.InterfacesApi
{
    public interface IDichVu
    {
        Task<ResponseDI<ICollection<DichVu>>> GetAll(string tk);
        Task<ResponseDI<DichVu>> GetById(int id, string tk);
        Task<ResponseDI<object>> LoadingDataTableView(DichVu item, int skip, int take, string tk);
        Task<ResponseDI<ICollection<DichVu>>> Search(DichVu item, string tk);
        Task<ResponseDI<List<DichVuMN>>> SearchName(DichVu item, string tk);
        Task<ResponseDI<int>> SearchCount(DichVu item, string tk);
        Task<ResponseDI<bool>> Create(DichVu item, string tk);
        Task<ResponseDI<bool>> Update(DichVu item, string tk);
        Task<ResponseDI<bool>> Delete(int id, string nguoiXoa, string tk);
        Task<ResponseDI<bool>> CheckId(int id, string tk);
    }
}
