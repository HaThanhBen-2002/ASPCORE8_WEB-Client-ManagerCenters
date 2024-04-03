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
    public class SanPhamRepon: ISanPham
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public SanPhamRepon(HttpClient httpClient, IOptions<TrainingCenters.ConnectApi.ConnectApi> connectionStrings)
        {
            _httpClient = httpClient = new HttpClient();
            _apiUrl = connectionStrings.Value.StringConnectAPI;
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<bool> CheckId(int id)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/SanPham/CheckId?id={id}";

                // Chuyển dữ liệu thành JSON
                var response = await _httpClient.GetAsync(apiUrl);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    return responseObject.IsSuccess;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Create(SanPham item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/SanPham/Create";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    return responseObject.IsSuccess;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id, string nguoiXoa)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/SanPham/Delete?id={id}&nguoiXoa={nguoiXoa}"; // Điền đường dẫn API tại đây
                var response = await _httpClient.DeleteAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    return responseObject.IsSuccess;
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

        public async Task<ICollection<SanPham>> Search(SanPham item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/SanPham/Search";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ICollection<SanPham>>(content1);
                    return values;
                }
                else
                {
                    return new List<SanPham>();
                }
            }
            catch (Exception ex)
            {
                return new List<SanPham>();
            }
        }

        public async Task<bool> Update(SanPham item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/SanPham/Update";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    return responseObject.IsSuccess;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ICollection<SanPham>> GetAll()
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/SanPham/GetAll";

                // Chuyển dữ liệu thành JSON
                var response = await _httpClient.GetAsync(apiUrl);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ICollection<SanPham>>(content1);
                    return values;
                }
                else
                {
                    return new List<SanPham>();
                }
            }
            catch (Exception ex)
            {
                return new List<SanPham>();
            }
        }

        public async Task<SanPham> GetById(int id)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/SanPham/GetById?id={id}";

                // Chuyển dữ liệu thành JSON
                var response = await _httpClient.GetAsync(apiUrl);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<SanPham>(jsonResponse);
                    return responseObject;
                }
                else
                {
                    return new SanPham();
                }
            }
            catch (Exception ex)
            {
                return new SanPham();
            }
        }

        public async Task<object> LoadingDataTableView(SanPham item, int skip, int take)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/SanPham/LoadingDataTableView?skip={skip}&take={take}";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<SanPhamMN>> SearchName(SanPham item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/SanPham/SearchName";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var objects = JsonConvert.DeserializeObject<List<SanPhamMN>>(content1);
                    return objects;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> SearchCount(SanPham item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/SanPham/SearchCount";

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
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
