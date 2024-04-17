using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface INhanVien
    {
        Task<ResponseDI<object>> LoadingDataTableView(NhanVien item, int skip, int take, string tk);
        Task<ResponseDI<ICollection<NhanVien>>> Search(NhanVien item, string tk);
        Task<ResponseDI<List<NhanVienMN>>> SearchName(NhanVien item, string tk);
        Task<ResponseDI<int>> SearchCount(NhanVien item, string tk);
        Task<ResponseDI<ICollection<NhanVien>>> GetAll(string tk);
        Task<ResponseDI<NhanVien>> GetById(int id, string tk);
        Task<ResponseDI<bool>> Create(NhanVien item, string tk);
        Task<ResponseDI<bool>> Update(NhanVien item, string tk);
        Task<ResponseDI<bool>> Delete(int id, string nguoiXoa, string tk);
        Task<ResponseDI<bool>> CheckId(int id, string tk);
    }

}
