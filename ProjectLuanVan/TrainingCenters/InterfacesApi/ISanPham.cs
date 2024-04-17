using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface ISanPham
    {
        Task<ResponseDI<object>> LoadingDataTableView(SanPham item, int skip, int take, string tk);
        Task<ResponseDI<ICollection<SanPham>>> Search(SanPham item, string tk);
        Task<ResponseDI<List<SanPhamMN>>> SearchName(SanPham item, string tk);
        Task<ResponseDI<int>> SearchCount(SanPham item, string tk);
        Task<ResponseDI<ICollection<SanPham>>> GetAll(string tk);
        Task<ResponseDI<SanPham>> GetById(int id, string tk);
        Task<ResponseDI<bool>> Create(SanPham item, string tk);
        Task<ResponseDI<bool>> Update(SanPham item, string tk);
        Task<ResponseDI<bool>> Delete(int id, string nguoiXoa, string tk);
        Task<ResponseDI<bool>> CheckId(int id, string tk);
    }

}
