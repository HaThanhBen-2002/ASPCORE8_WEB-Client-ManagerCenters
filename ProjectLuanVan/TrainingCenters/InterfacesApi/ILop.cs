using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;
namespace TrainingCenters.InterfacesApi
{
    public interface ILop
    {
        Task<ResponseDI<object>> LoadingDataTableView(Lop item, int skip, int take, string tk);
        Task<ResponseDI<ICollection<Lop>>> Search(Lop item, string tk);
        Task<ResponseDI<List<LopMN>>> SearchName(Lop item, string tk);
        Task<ResponseDI<int>> SearchCount(Lop item, string tk);
        Task<ResponseDI<ICollection<Lop>>> GetAll(string tk);
        Task<ResponseDI<Lop>> GetById(int id, string tk);
        Task<ResponseDI<bool>> Create(Lop item, string tk);
        Task<ResponseDI<bool>> Update(Lop item, string tk);
        Task<ResponseDI<bool>> Delete(int id, string nguoiXoa, string tk);
        Task<ResponseDI<bool>> CheckId(int id, string tk);
    }

}
