
using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface IHocSinh
    {
        Task<ICollection<HocSinh>> GetAll(string tk);
        Task<HocSinh> GetById(int id, string tk);
        Task<HocSinhView> GetHocSinhView(int id, string tk);
        Task<object> LoadingDataTableView(HocSinh item, int skip, int take, string tk);
        Task<ICollection<HocSinh>> Search(HocSinh item, string tk);
        Task<List<HocSinhMN>> SearchName(HocSinh item, string tk);
        Task<int> SearchCount(HocSinh item, string tk);
        Task<bool> Create(HocSinh item, string tk);
        Task<bool> Update(HocSinh item, string tk);
        Task<bool> Delete(int id, string nguoiXoa, string tk);
        Task<bool> CheckId(int id, string tk);
        
    }
}
