using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface IKetQua
    {
        Task<ResponseDI<ICollection<KetQua>>> GetAll(string tk);
        Task<ResponseDI<object>> LoadingDataTableView(KetQua item, int skip, int take, string tk);
        Task<ResponseDI<ICollection<KetQua>>> Search(KetQua item, string tk);
        Task<ResponseDI<List<KetQuaMN>>> SearchName(KetQua item, string tk);
        Task<ResponseDI<int>> SearchCount(KetQua item, string tk);
        Task<ResponseDI<KetQua>> GetById(int id, string tk);
        Task<ResponseDI<bool>> Create(KetQua item, string tk);
        Task<ResponseDI<bool>> Update(KetQua item, string tk);
        Task<ResponseDI<bool>> Delete(int id, string nguoiXoa, string tk);
        Task<ResponseDI<bool>> CheckId(int id, string tk);
    }

}
