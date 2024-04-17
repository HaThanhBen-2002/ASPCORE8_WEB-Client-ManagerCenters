using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;
namespace TrainingCenters.InterfacesApi
{
    public interface INhaCungCap
    {
        Task<ResponseDI<object>> LoadingDataTableView(NhaCungCap item, int skip, int take, string tk);
        Task<ResponseDI<ICollection<NhaCungCap>>> Search(NhaCungCap item, string tk);
        Task<ResponseDI<List<NhaCungCapMN>>> SearchName(NhaCungCap item, string tk);
        Task<ResponseDI<int>> SearchCount(NhaCungCap item, string tk);
        Task<ResponseDI<ICollection<NhaCungCap>>> GetAll(string tk);
        Task<ResponseDI<NhaCungCap>> GetById(int id, string tk);
        Task<ResponseDI<bool>> Create(NhaCungCap item, string tk);
        Task<ResponseDI<bool>> Update(NhaCungCap item, string tk);
        Task<ResponseDI<bool>> Delete(int id, string nguoiXoa, string tk);
        Task<ResponseDI<bool>> CheckId(int id, string tk);
    }

}
