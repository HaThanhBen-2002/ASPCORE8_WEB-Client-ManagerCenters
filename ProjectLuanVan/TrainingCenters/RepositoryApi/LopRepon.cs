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
using System.Net.Http.Headers;
namespace TrainingCenters.RepositoryApi
{
    public class LopRepon: ILop
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public LopRepon(HttpClient httpClient, IOptions<TrainingCenters.ConnectApi.ConnectApi> connectionStrings)
        {
            _httpClient = httpClient;
            _apiUrl = connectionStrings?.Value?.StringConnectAPI ?? throw new ArgumentNullException(nameof(connectionStrings));
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<bool> CheckId(int id, string accessToken)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/Lop/CheckId?id={id}";
                if (!string.IsNullOrEmpty(accessToken))
                {
                    // Thêm accessToken vào header của HttpClient
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
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

        public async Task<bool> Create(Lop item, string accessToken)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/Lop/Create";
                if (!string.IsNullOrEmpty(accessToken))
                {
                    // Thêm accessToken vào header của HttpClient
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
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

        public async Task<bool> Delete(int id, string nguoiXoa, string accessToken)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/Lop/Delete?id={id}&nguoiXoa={nguoiXoa}"; // Điền đường dẫn API tại đây
                if (!string.IsNullOrEmpty(accessToken))
                {
                    // Thêm accessToken vào header của HttpClient
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
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

        public async Task<ICollection<Lop>> Search(Lop item, string accessToken)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/Lop/Search";
                if (!string.IsNullOrEmpty(accessToken))
                {
                    // Thêm accessToken vào header của HttpClient
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ICollection<Lop>>(content1);
                    if (values != null)
                    {
                        return values;
                    }
                    return new List<Lop>();
                }
                else
                {
                    return new List<Lop>();
                }
            }
            catch 
            {
                return new List<Lop>();
            }
        }

        public async Task<bool> Update(Lop item, string accessToken)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/Lop/Update";
                if (!string.IsNullOrEmpty(accessToken))
                {
                    // Thêm accessToken vào header của HttpClient
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
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

        public async Task<ICollection<Lop>> GetAll(string accessToken)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/Lop/GetAll";
                if (!string.IsNullOrEmpty(accessToken))
                {
                    // Thêm accessToken vào header của HttpClient
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                // Chuyển dữ liệu thành JSON
                var response = await _httpClient.GetAsync(apiUrl);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ICollection<Lop>>(content1);
                    if (values != null)
                    {
                        return values;
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

        public async Task<Lop> GetById(int id, string accessToken)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/Lop/GetById?id={id}";
                if (!string.IsNullOrEmpty(accessToken))
                {
                    // Thêm accessToken vào header của HttpClient
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                // Chuyển dữ liệu thành JSON
                var response = await _httpClient.GetAsync(apiUrl);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<Lop>(jsonResponse);
                    if (responseObject != null)
                    {
                        return responseObject;
                    }
                    return new Lop();
                }
                else
                {
                    return new Lop();
                }
            }
            catch 
            {
                return new Lop();
            }
        }

        public async Task<object> LoadingDataTableView(Lop item, int skip, int take, string accessToken)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/Lop/LoadingDataTableView?skip={skip}&take={take}";
                if (!string.IsNullOrEmpty(accessToken))
                {
                    // Thêm accessToken vào header của HttpClient
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
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

        public async Task<List<LopMN>> SearchName(Lop item, string accessToken)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/Lop/SearchName";
                if (!string.IsNullOrEmpty(accessToken))
                {
                    // Thêm accessToken vào header của HttpClient
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var objects = JsonConvert.DeserializeObject<List<LopMN>>(content1);
                    if (objects != null){return objects;}
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

        public async Task<int> SearchCount(Lop item, string accessToken)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/Lop/SearchCount";
                if (!string.IsNullOrEmpty(accessToken))
                {
                    // Thêm accessToken vào header của HttpClient
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
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
