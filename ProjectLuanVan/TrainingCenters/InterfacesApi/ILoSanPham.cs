using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;
namespace TrainingCenters.InterfacesApi
{
    public interface ILoSanPham
    {
        Task<ResponseDI<object>> LoadingDataTableView(LoSanPham item, int skip, int take, string tk);
        Task<ResponseDI<ICollection<LoSanPham>>> Search(LoSanPham item, string tk);
        Task<ResponseDI<List<LoSanPhamMN>>> SearchName(LoSanPham item, string tk);
        Task<ResponseDI<int>> SearchCount(LoSanPham item, string tk);
        Task<ResponseDI<ICollection<LoSanPham>>> GetAll(string tk);
        Task<ResponseDI<LoSanPham>> GetById(int id, string tk);
        Task<ResponseDI<bool>> Create(LoSanPham item, string tk);
        Task<ResponseDI<bool>> Update(LoSanPham item, string tk);
        Task<ResponseDI<bool>> Delete(int id, string nguoiXoa, string tk);
        Task<ResponseDI<bool>> CheckId(int id, string tk);
    }

}
