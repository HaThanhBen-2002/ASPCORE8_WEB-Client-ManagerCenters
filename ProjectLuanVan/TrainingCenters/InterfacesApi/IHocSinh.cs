
using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface IHocSinh
    {
        Task<ResponseDI<ICollection<HocSinh>>> GetAll(string tk);
        Task<ResponseDI<HocSinh>> GetById(int id, string tk);
        Task<ResponseDI<HocSinhView>> GetHocSinhView(int id, string tk);
        Task<ResponseDI<object>> LoadingDataTableView(HocSinh item, int skip, int take, string tk);
        Task<ResponseDI<ICollection<HocSinh>>> Search(HocSinh item, string tk);
        Task<ResponseDI<List<HocSinhMN>>> SearchName(HocSinh item, string tk);
        Task<ResponseDI<int>> SearchCount(HocSinh item, string tk);
        Task<ResponseDI<bool>> Create(HocSinh item, string tk);
        Task<ResponseDI<bool>> Update(HocSinh item, string tk);
        Task<ResponseDI<bool>> Delete(int id, string nguoiXoa, string tk);
        Task<ResponseDI<bool>> CheckId(int id, string tk);
    }

}
