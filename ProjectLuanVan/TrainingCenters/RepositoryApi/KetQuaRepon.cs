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
    public class KetQuaRepon: IKetQua
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public KetQuaRepon(HttpClient httpClient, IOptions<TrainingCenters.ConnectApi.ConnectApi> connectionStrings)
        {
            _httpClient = httpClient = new HttpClient();
            _apiUrl = connectionStrings.Value.StringConnectAPI;
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<bool> CheckId(int id)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/KetQua/CheckId?id={id}";

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

        public async Task<bool> Create(KetQua item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/KetQua/Create";

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
                var apiUrl = $"{_apiUrl}/api/KetQua/Delete?id={id}&nguoiXoa={nguoiXoa}"; // Điền đường dẫn API tại đây
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

        public async Task<ICollection<KetQua>> Search(KetQua item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/KetQua/Search";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ICollection<KetQua>>(content1);
                    return values;
                }
                else
                {
                    return new List<KetQua>();
                }
            }
            catch (Exception ex)
            {
                return new List<KetQua>();
            }
        }

        public async Task<bool> Update(KetQua item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/KetQua/Update";

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

        public async Task<ICollection<KetQua>> GetAll()
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/KetQua/GetAll";

                // Chuyển dữ liệu thành JSON
                var response = await _httpClient.GetAsync(apiUrl);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ICollection<KetQua>>(content1);
                    return values;
                }
                else
                {
                    return new List<KetQua>();
                }
            }
            catch (Exception ex)
            {
                return new List<KetQua>();
            }
        }

        public async Task<KetQua> GetById(int id)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/KetQua/GetById?id={id}";

                // Chuyển dữ liệu thành JSON
                var response = await _httpClient.GetAsync(apiUrl);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<KetQua>(jsonResponse);
                    return responseObject;
                }
                else
                {
                    return new KetQua();
                }
            }
            catch (Exception ex)
            {
                return new KetQua();
            }
        }

        public async Task<object> LoadingDataTableView(KetQua item, int skip, int take)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/KetQua/LoadingDataTableView?skip={skip}&take={take}";

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
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<KetQuaMN>> SearchName(KetQua item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/KetQua/SearchName";

                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var objects = JsonConvert.DeserializeObject<List<KetQuaMN>>(content1);
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

        public async Task<int> SearchCount(KetQua item)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/KetQua/SearchCount";

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
