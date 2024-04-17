using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Extensions.Options;
using TrainingCenters.ConnectApi;
using TrainingCenters.Models.ModelMN;
using TrainingCenters.Models.Email;
using System.Net.Http.Headers;
namespace TrainingCenters.RepositoryApi
{
    public class SendEmailRepon : ISendEmail
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public SendEmailRepon(HttpClient httpClient, IOptions<TrainingCenters.ConnectApi.ConnectApi> connectionStrings)
        {
            _httpClient = httpClient;
            _apiUrl = connectionStrings?.Value?.StringConnectAPI ?? throw new ArgumentNullException(nameof(connectionStrings));
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<ResponseDI<bool>> SendEmailText(Message message, string accessToken)
        {
            var responseModel = new ResponseDI<bool>();
            try
            {
                var apiUrl = $"{_apiUrl}/api/SendEmail/SendEmailText";
                if (!string.IsNullOrEmpty(accessToken))
                {
                    // Thêm accessToken vào header của HttpClient
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
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
    }
}
