using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;
namespace TrainingCenters.InterfacesApi
{
    public interface ITrungTam
    {
        Task<ResponseDI<object>> LoadingDataTableView(TrungTam item, int skip, int take, string tk);
        Task<ResponseDI<ICollection<TrungTam>>> Search(TrungTam item, string tk);
        Task<ResponseDI<List<TrungTamMN>>> SearchName(TrungTam item, string tk);
        Task<ResponseDI<int>> SearchCount(TrungTam item, string tk);
        Task<ResponseDI<ICollection<TrungTam>>> GetAll(string tk);
        Task<ResponseDI<TrungTam>> GetById(int id, string tk);
        Task<ResponseDI<bool>> Create(TrungTam item, string tk);
        Task<ResponseDI<bool>> Update(TrungTam item, string tk);
        Task<ResponseDI<bool>> Delete(int id, string nguoiXoa, string tk);
        Task<ResponseDI<bool>> CheckId(int id, string tk);
    }

}
