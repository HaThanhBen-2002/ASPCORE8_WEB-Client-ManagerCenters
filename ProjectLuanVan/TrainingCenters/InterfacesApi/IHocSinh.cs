
using TrainingCenters.Models;
using TrainingCenters.Models.ModelMN;

namespace TrainingCenters.InterfacesApi
{
    public interface IHocSinh
    {
        Task<ICollection<HocSinh>> GetAll();
        Task<HocSinh> GetById(int id);
        Task<HocSinhView> GetHocSinhView(int id);
        Task<object> LoadingDataTableView(HocSinh item, int skip, int take);
        Task<ICollection<HocSinh>> Search(HocSinh item);
        Task<List<HocSinhMN>> SearchName(HocSinh item);
        Task<int> SearchCount(HocSinh item);
        Task<bool> Create(HocSinh item);
        Task<bool> Update(HocSinh item);
        Task<bool> Delete(int id, string nguoiXoa);
        Task<bool> CheckId(int id);
        
    }
}
