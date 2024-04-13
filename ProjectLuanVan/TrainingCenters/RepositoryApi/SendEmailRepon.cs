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
namespace TrainingCenters.RepositoryApi
{
    public class SendEmailRepon : ISendEmail
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public SendEmailRepon(HttpClient httpClient, IOptions<TrainingCenters.ConnectApi.ConnectApi> connectionStrings)
        {
            _httpClient = httpClient = new HttpClient();
            _apiUrl = connectionStrings?.Value?.StringConnectAPI ?? throw new ArgumentNullException(nameof(connectionStrings));
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<bool> SendEmailText(Message message)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/SendEmail/SendEmailText";
                // Chuyển dữ liệu thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    if (responseObject != null) { return responseObject.IsSuccess; }
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
    }
}
