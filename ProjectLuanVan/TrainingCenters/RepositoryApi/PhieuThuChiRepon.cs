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
namespace TrainingCenters.RepositoryApi
{
    public class PhieuThuChiRepon: IPhieuThuChi
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public PhieuThuChiRepon(HttpClient httpClient, IOptions<TrainingCenters.ConnectApi.ConnectApi> connectionStrings)
        {
            _httpClient = httpClient = new HttpClient();
            _apiUrl = connectionStrings.Value.StringConnectAPI;
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<bool> CheckId(int id)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/CheckId?id={id}";

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

        public async Task<bool> Create(PhieuThuChi item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/Create";

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
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/Delete?id={id}&nguoiXoa={nguoiXoa}"; // Điền đường dẫn API tại đây
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

        public async Task<ICollection<PhieuThuChi>> Search(PhieuThuChi item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/Search";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ICollection<PhieuThuChi>>(content1);
                    return values;
                }
                else
                {
                    return new List<PhieuThuChi>();
                }
            }
            catch (Exception ex)
            {
                return new List<PhieuThuChi>();
            }
        }

        public async Task<bool> Update(PhieuThuChi item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/Update";

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

        public async Task<ICollection<PhieuThuChi>> GetAll()
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/GetAll";

                // Chuyển dữ liệu thành JSON
                var response = await _httpClient.GetAsync(apiUrl);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ICollection<PhieuThuChi>>(content1);
                    return values;
                }
                else
                {
                    return new List<PhieuThuChi>();
                }
            }
            catch (Exception ex)
            {
                return new List<PhieuThuChi>();
            }
        }

        public async Task<PhieuThuChi> GetById(int id)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/GetById?id={id}";

                // Chuyển dữ liệu thành JSON
                var response = await _httpClient.GetAsync(apiUrl);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<PhieuThuChi>(jsonResponse);
                    return responseObject;
                }
                else
                {
                    return new PhieuThuChi();
                }
            }
            catch (Exception ex)
            {
                return new PhieuThuChi();
            }
        }

        public async Task<object> LoadingDataTableView(PhieuThuChi item, int skip, int take)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/LoadingDataTableView?skip={skip}&take={take}";

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

        public async Task<int> SearchTongTien(PhieuThuChi item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/SearchTongTien";

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

        public async Task<int> SearchCount(PhieuThuChi item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/SearchCount";

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
