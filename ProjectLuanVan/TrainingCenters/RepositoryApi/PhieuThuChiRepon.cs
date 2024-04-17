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
using System.Net.Http.Headers;
using TrainingCenters.Models.ModeIMN;
namespace TrainingCenters.RepositoryApi
{
    public class PhieuThuChiRepon: IPhieuThuChi
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public PhieuThuChiRepon(HttpClient httpClient, IOptions<TrainingCenters.ConnectApi.ConnectApi> connectionStrings)
        {
            _httpClient = httpClient;
            _apiUrl = connectionStrings?.Value?.StringConnectAPI ?? throw new ArgumentNullException(nameof(connectionStrings));
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }


        public async Task<ResponseDI<bool>> CheckId(int id, string accessToken)
        {
            var responseModel = new ResponseDI<bool>();
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/CheckId?id={id}";
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
                    if (responseObject != null)
                    {
                        responseModel.IsSuccess = true;
                        responseModel.Message = "Thành công";
                        responseModel.Data = responseObject.IsSuccess;
                    }
                    else
                    {
                        responseModel.IsSuccess = false;
                        responseModel.Message = "Chuyển đổi dữ liệu thất bại";
                    }
                }
                else
                {
                    responseModel.IsSuccess = false;
                    responseModel.Message = "Authorization";
                }
            }
            catch
            {
                responseModel.IsSuccess = false;
                responseModel.Message = $"Lỗi Try_C";
            }
            return responseModel;
        }

        public async Task<ResponseDI<bool>> Create(PhieuThuChi item, string accessToken)
        {
            var responseModel = new ResponseDI<bool>();

            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/Create";
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
                    if (responseObject != null)
                    {
                        responseModel.IsSuccess = true;
                        responseModel.Message = "Thành công";
                        responseModel.Data = responseObject.IsSuccess;
                    }
                    else
                    {
                        responseModel.IsSuccess = false;
                        responseModel.Message = "Chuyển đổi dữ liệu thất bại";
                    }
                }
                else
                {
                    responseModel.IsSuccess = false;
                    responseModel.Message = "Authorization";
                }
            }
            catch
            {
                responseModel.IsSuccess = false;
                responseModel.Message = $"Lỗi Try_C";
            }
            return responseModel;
        }

        public async Task<ResponseDI<bool>> Delete(int id, string nguoiXoa, string accessToken)
        {
            var responseModel = new ResponseDI<bool>();
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/Delete?id={id}&nguoiXoa={nguoiXoa}"; // Điền đường dẫn API tại đây
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
                    if (responseObject != null)
                    {
                        responseModel.IsSuccess = true;
                        responseModel.Message = "Thành công";
                        responseModel.Data = responseObject.IsSuccess;
                    }
                    else
                    {
                        responseModel.IsSuccess = false;
                        responseModel.Message = "Chuyển đổi dữ liệu thất bại";
                    }
                }
                else
                {
                    responseModel.IsSuccess = false;
                    responseModel.Message = "Authorization";
                }
            }
            catch
            {
                responseModel.IsSuccess = false;
                responseModel.Message = $"Lỗi Try_C";
            }
            return responseModel;
        }

        public async Task<ResponseDI<ICollection<PhieuThuChi>>> Search(PhieuThuChi item, string accessToken)
        {
            var responseModel = new ResponseDI<ICollection<PhieuThuChi>>();

            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/Search";
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
                    var values = JsonConvert.DeserializeObject<ICollection<PhieuThuChi>>(content1);
                    if (values != null)
                    {
                        responseModel.IsSuccess = true;
                        responseModel.Message = "Thành công";
                        responseModel.Data = values;
                    }
                    else
                    {
                        responseModel.IsSuccess = false;
                        responseModel.Message = "Chuyển đổi dữ liệu thất bại";
                    }
                }
                else
                {
                    responseModel.IsSuccess = false;
                    responseModel.Message = "Authorization";
                }
            }
            catch
            {
                responseModel.IsSuccess = false;
                responseModel.Message = $"Lỗi Try_C";
            }
            return responseModel;
        }

        public async Task<ResponseDI<bool>> Update(PhieuThuChi item, string accessToken)
        {
            var responseModel = new ResponseDI<bool>();
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/Update";
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
                    if (responseObject != null)
                    {
                        responseModel.IsSuccess = true;
                        responseModel.Message = "Thành công";
                        responseModel.Data = responseObject.IsSuccess;
                    }
                    else
                    {
                        responseModel.IsSuccess = false;
                        responseModel.Message = "Chuyển đổi dữ liệu thất bại";
                    }
                }
                else
                {
                    responseModel.IsSuccess = false;
                    responseModel.Message = "Authorization";
                }
            }
            catch
            {
                responseModel.IsSuccess = false;
                responseModel.Message = $"Lỗi Try_C";
            }
            return responseModel;
        }

        public async Task<ResponseDI<ICollection<PhieuThuChi>>> GetAll(string accessToken)
        {
            var responseModel = new ResponseDI<ICollection<PhieuThuChi>>();
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/GetAll";
                // Đọc accessToken từ HttpContext.Items
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
                    var values = JsonConvert.DeserializeObject<ICollection<PhieuThuChi>>(content1);
                    if (values != null)
                    {
                        responseModel.IsSuccess = true;
                        responseModel.Message = "Thành công";
                        responseModel.Data = values;
                    }
                    else
                    {
                        responseModel.IsSuccess = false;
                        responseModel.Message = "Chuyển đổi dữ liệu thất bại";
                    }
                }
                else
                {
                    responseModel.IsSuccess = false;
                    responseModel.Message = "Authorization";
                }
            }
            catch
            {
                responseModel.IsSuccess = false;
                responseModel.Message = $"Lỗi Try_C";
            }
            return responseModel;
        }

        public async Task<ResponseDI<PhieuThuChi>> GetById(int id, string accessToken)
        {
            var responseModel = new ResponseDI<PhieuThuChi>();
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/GetById?id={id}";
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
                    var responseObject = JsonConvert.DeserializeObject<PhieuThuChi>(jsonResponse);
                    if (responseObject != null)
                    {
                        responseModel.IsSuccess = true;
                        responseModel.Message = "Thành công";
                        responseModel.Data = responseObject;
                    }
                    else
                    {
                        responseModel.IsSuccess = false;
                        responseModel.Message = "Chuyển đổi dữ liệu thất bại";
                    }
                }
                else
                {
                    responseModel.IsSuccess = false;
                    responseModel.Message = "Authorization";
                }
            }
            catch
            {
                responseModel.IsSuccess = false;
                responseModel.Message = $"Lỗi Try_C";
            }
            return responseModel;
        }

        public async Task<ResponseDI<object>> LoadingDataTableView(PhieuThuChi item, int skip, int take, string accessToken)
        {
            var responseModel = new ResponseDI<object>();
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/LoadingDataTableView?skip={skip}&take={take}";
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
                    if (content1 != null)
                    {
                        responseModel.IsSuccess = true;
                        responseModel.Message = "Thành công";
                        responseModel.Data = content1;
                    }
                    else
                    {
                        responseModel.IsSuccess = false;
                        responseModel.Message = "Chuyển đổi dữ liệu thất bại";
                    }
                }
                else
                {
                    responseModel.IsSuccess = false;
                    responseModel.Message = "Authorization";
                }
            }
            catch
            {
                responseModel.IsSuccess = false;
                responseModel.Message = $"Lỗi Try_C";
            }
            return responseModel;
        }

        public async Task<ResponseDI<int>> SearchCount(PhieuThuChi item, string accessToken)
        {
            var responseModel = new ResponseDI<int>();
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/SearchCount";
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
                    if (content1 != null)
                    {
                        responseModel.IsSuccess = true;
                        responseModel.Message = "Thành công";
                        responseModel.Data = Convert.ToInt32(content1);
                    }
                    else
                    {
                        responseModel.IsSuccess = false;
                        responseModel.Message = "Chuyển đổi dữ liệu thất bại";
                    }
                }
                else
                {
                    responseModel.IsSuccess = false;
                    responseModel.Message = "Authorization";
                }
            }
            catch
            {
                responseModel.IsSuccess = false;
                responseModel.Message = $"Lỗi Try_C";
            }
            return responseModel;
        }

        public async Task<ResponseDI<double>> SearchTongTien(PhieuThuChi item, string accessToken)
        {
            var responseModel = new ResponseDI<double>();
            try
            {
                var apiUrl = $"{_apiUrl}/api/PhieuThuChi/SearchTongTien";
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
                    if (content1 != null)
                    {
                        responseModel.IsSuccess = true;
                        responseModel.Message = "Thành công";
                        responseModel.Data = Convert.ToDouble(content1);
                    }
                    else
                    {
                        responseModel.IsSuccess = false;
                        responseModel.Message = "Chuyển đổi dữ liệu thất bại";
                    }
                }
                else
                {
                    responseModel.IsSuccess = false;
                    responseModel.Message = "Authorization";
                }
            }
            catch
            {
                responseModel.IsSuccess = false;
                responseModel.Message = $"Lỗi Try_C";
            }
            return responseModel;
        }
    }
}
