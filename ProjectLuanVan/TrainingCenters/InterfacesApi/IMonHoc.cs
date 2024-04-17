using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface IMonHoc
    {
        Task<ResponseDI<object>> LoadingDataTableView(MonHoc item, int skip, int take, string tk);
        Task<ResponseDI<ICollection<MonHoc>>> Search(MonHoc item, string tk);
        Task<ResponseDI<List<MonHocMN>>> SearchName(MonHoc item, string tk);
        Task<ResponseDI<int>> SearchCount(MonHoc item, string tk);
        Task<ResponseDI<ICollection<MonHoc>>> GetAll(string tk);
        Task<ResponseDI<MonHoc>> GetById(int id, string tk);
        Task<ResponseDI<bool>> Create(MonHoc item, string tk);
        Task<ResponseDI<bool>> Update(MonHoc item, string tk);
        Task<ResponseDI<bool>> Delete(int id, string nguoiXoa, string tk);
        Task<ResponseDI<bool>> CheckId(int id, string tk);
    }

}
