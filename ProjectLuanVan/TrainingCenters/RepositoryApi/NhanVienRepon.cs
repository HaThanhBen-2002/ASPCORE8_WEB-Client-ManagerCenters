using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TrainingCenters.ConnectApi;
using TrainingCenters.Models.ModelMN;
namespace TrainingCenters.RepositoryApi
{
    public class NhanVienRepon: INhanVien
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public NhanVienRepon(HttpClient httpClient, IOptions<TrainingCenters.ConnectApi.ConnectApi> connectionStrings)
        {
            _httpClient = httpClient;
            _apiUrl = connectionStrings?.Value?.StringConnectAPI ?? throw new ArgumentNullException(nameof(connectionStrings));
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<bool> CheckId(int id)
        {
            try
            {

                var apiUrl = $"{_apiUrl}/api/NhanVien/CheckId?id={id}";

                // Chuyển dữ liệu thành JSON
                var response = await _httpClient.GetAsync(apiUrl);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    if (responseObject != null)
                    {
                        if(responseObject != null){ return responseObject.IsSuccess;} return false;
                    }
                    return false;
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

        public async Task<bool> Create(NhanVien item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/NhanVien/Create";

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
                var apiUrl = $"{_apiUrl}/api/NhanVien/Delete?id={id}&nguoiXoa={nguoiXoa}"; // Điền đường dẫn API tại đây
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

        public async Task<ICollection<NhanVien>> Search(NhanVien item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/NhanVien/Search";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ICollection<NhanVien>>(content1);
                    if (values != null)
                    {
                        return values;
                    }
                    return [];
                }
                else
                {
                    return new List<NhanVien>();
                }
            }
            catch 
            {
                return new List<NhanVien>();
            }
        }

        public async Task<bool> Update(NhanVien item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/NhanVien/Update";

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

        public async Task<ICollection<NhanVien>> GetAll()
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/NhanVien/GetAll";

                // Chuyển dữ liệu thành JSON
                var response = await _httpClient.GetAsync(apiUrl);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ICollection<NhanVien>>(content1);
                    if (values != null)
                    {
                        return values;
                    }
                    return [];
                }
                else
                {
                    return new List<NhanVien>();
                }
            }
            catch 
            {
                return new List<NhanVien>();
            }
        }

        public async Task<NhanVien> GetById(int id)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/NhanVien/GetById?id={id}";

                // Chuyển dữ liệu thành JSON
                var response = await _httpClient.GetAsync(apiUrl);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<NhanVien>(jsonResponse);
                    if (responseObject != null)
                    {
                        return responseObject;
                    }
                    return new NhanVien();
                }
                else
                {
                    return new NhanVien();
                }
            }
            catch 
            {
                return new NhanVien();
            }
        }

        public async Task<object> LoadingDataTableView(NhanVien item, int skip, int take)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/NhanVien/LoadingDataTableView?skip={skip}&take={take}";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    return content1;
                }
                else
                {
                    return new object();
                }
            }
            catch 
            {
                return new object();
            }
        }
        public async Task<List<NhanVienMN>> SearchName(NhanVien item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/NhanVien/SearchName";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var objects = JsonConvert.DeserializeObject<List<NhanVienMN>>(content1);
                    if (objects != null)
                    {
                        return objects;
                    }
                    return [];
                }
                else
                {
                    return [];
                }
            }
            catch 
            {
                return [];
            }
        }

        public async Task<int> SearchCount(NhanVien item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/NhanVien/SearchCount";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    return Convert.ToInt32(content1);
                }
                else
                {
                    return 0;
                }
            }
            catch 
            {
                return 0;
            }
        }
    }
}
