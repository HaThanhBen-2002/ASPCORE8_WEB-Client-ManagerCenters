using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
namespace TrainingCenters.RepositoryApi
{
    public class ChiTietThuChiRepon : IChiTietThuChi
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public ChiTietThuChiRepon(HttpClient httpClient, IOptions<TrainingCenters.ConnectApi.ConnectApi> connectionStrings)
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
                var apiUrl = $"{_apiUrl}/api/ChiTietThuChi/CheckId?id={id}";
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

        public async Task<ResponseDI<bool>> Create(ChiTietThuChi item, string accessToken)
        {
            var responseModel = new ResponseDI<bool>();

            try
            {
                var apiUrl = $"{_apiUrl}/api/ChiTietThuChi/Create";
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
                var apiUrl = $"{_apiUrl}/api/ChiTietThuChi/Delete?id={id}&nguoiXoa={nguoiXoa}"; // Điền đường dẫn API tại đây
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

        public async Task<ResponseDI<ICollection<ChiTietThuChi>>> Search(ChiTietThuChi item, string accessToken)
        {
            var responseModel = new ResponseDI<ICollection<ChiTietThuChi>>();

            try
            {
                var apiUrl = $"{_apiUrl}/api/ChiTietThuChi/Search";
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
                    var values = JsonConvert.DeserializeObject<ICollection<ChiTietThuChi>>(content1);
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

        public async Task<ResponseDI<bool>> Update(ChiTietThuChi item, string accessToken)
        {
            var responseModel = new ResponseDI<bool>();
            try
            {
                var apiUrl = $"{_apiUrl}/api/ChiTietThuChi/Update";
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

        public async Task<ResponseDI<ICollection<ChiTietThuChi>>> SearchByPhieuThuChiId(int id, string accessToken)
        {
            var responseModel = new ResponseDI<ICollection<ChiTietThuChi>>();
            try
            {
                var apiUrl = $"{_apiUrl}/api/ChiTietThuChi/SearchByPhieuThuChiId?id={id}";
                if (!string.IsNullOrEmpty(accessToken))
                {
                    // Thêm accessToken vào header của HttpClient
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ICollection<ChiTietThuChi>>(content1);
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

    }
}
