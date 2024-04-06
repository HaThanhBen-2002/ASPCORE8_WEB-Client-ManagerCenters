using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
namespace TrainingCenters.RepositoryApi
{
    public class ChiTietThuChiRepon : IChiTietThuChi
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public ChiTietThuChiRepon(HttpClient httpClient, IOptions<TrainingCenters.ConnectApi.ConnectApi> connectionStrings)
        {
            _httpClient = httpClient = new HttpClient();
            _apiUrl = connectionStrings?.Value?.StringConnectAPI ?? throw new ArgumentNullException(nameof(connectionStrings));
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }
        
        public async Task<bool> CheckId(int id)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/ChiTietThuChi/CheckId?id={id}";

                // Chuyển dữ liệu thành JSON
                var response = await _httpClient.GetAsync(apiUrl);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    if(responseObject != null){ return responseObject.IsSuccess;} return false;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Create(ChiTietThuChi item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/ChiTietThuChi/Create";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    if(responseObject != null){ return responseObject.IsSuccess;} return false;
                }
                else
                {
                    return false; 
                }
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id, string nguoiXoa)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/ChiTietThuChi/Delete?id={id}&nguoiXoa={nguoiXoa}"; // Điền đường dẫn API tại đây
                var response = await _httpClient.DeleteAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    if(responseObject != null){ return responseObject.IsSuccess;} return false;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            
        }

        public async Task<ICollection<ChiTietThuChi>> Search(ChiTietThuChi item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/ChiTietThuChi/Search";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ICollection<ChiTietThuChi>>(content1);
                    if (values != null)
                    {
                        
                    }
                    return [];
                }
                else
                {
                    return new List<ChiTietThuChi>(); 
                }
            }
            catch 
            {
                return new List<ChiTietThuChi>();
            }
        }
         
        public async Task<ICollection<ChiTietThuChi>> SearchByPhieuThuChiId(int id)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/ChiTietThuChi/SearchByPhieuThuChi";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ICollection<ChiTietThuChi>>(content1);
                    if (values != null)
                    {
                        return values;
                    }
                    return [];
                }
                else
                {
                    return new List<ChiTietThuChi>();
                }
            }
            catch 
            {
                return new List<ChiTietThuChi>();
            }
        }

        public async Task<bool> Update(ChiTietThuChi item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/ChiTietThuChi/Update";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    if(responseObject != null){ return responseObject.IsSuccess;} return false;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }
    }
}
