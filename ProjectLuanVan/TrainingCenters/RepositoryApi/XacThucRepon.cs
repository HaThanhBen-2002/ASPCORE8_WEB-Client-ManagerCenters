﻿using TrainingCenters.InterfacesApi;
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
using ManagementService.Models.Authentication.User;
using ManagementService.Models.Authentication.SignUp;
using ManagementService.Models.Authentication.Login;
using TrainingCenters.Models.Auth;
using System.Web;
namespace TrainingCenters.RepositoryApi
{
    public class XacThucRepon : IXacThuc
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public XacThucRepon(HttpClient httpClient, IOptions<TrainingCenters.ConnectApi.ConnectApi> connectionStrings)
        {
            _httpClient = httpClient;
            _apiUrl = connectionStrings?.Value?.StringConnectAPI ?? throw new ArgumentNullException(nameof(connectionStrings));
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }
        public async Task<ApiResponsePro<LoginResponse>> CapNhatToken(LoginResponse tokens)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/Authentication/CapNhat-Token";

                var content = new StringContent(JsonConvert.SerializeObject(tokens), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ApiResponsePro<LoginResponse>>(jsonResponse);
                    if (responseObject != null)
                    {
                        return responseObject;
                    }
                    return new ApiResponsePro<LoginResponse>()
                    {
                        IsSuccess = false,
                        Message = "Lỗi Dăng Nhập Null"

                    };
                }
                else
                {
                    return new ApiResponsePro<LoginResponse>()
                    {
                        IsSuccess = false,
                        Message = "Lỗi Gọi Api"

                    };
                }
            }
            catch
            {
                return new ApiResponsePro<LoginResponse>()
                {
                    IsSuccess = false,
                    Message = "Lỗi Cập Nhật Token"

                };
            }
        }

        public async Task<bool> DangKy(RegisterUser item, string linkReturn)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/Authentication/DangKy?linkReturn={linkReturn}";

                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    if (responseObject != null)
                    {
                        if (responseObject != null) { return responseObject.IsSuccess; }
                        return false;
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
        // xông
        public async Task<ApiResponsePro<LoginResponse>> DangNhap(LoginModel item)
        {
            try
            {
                item.Username = item.Username.Trim();
                item.Password = item.Password.Trim();

                var apiUrl = $"{_apiUrl}/api/Authentication/DangNhap";
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);

                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ApiResponsePro<LoginResponse>>(jsonResponse);
                    if (responseObject != null)
                    {
                        return responseObject;
                    }
                    return new ApiResponsePro<LoginResponse>()
                    {
                        IsSuccess = false,
                        Message = "Lỗi Dăng Nhập Null"

                    };
                }
                else
                {
                    return new ApiResponsePro<LoginResponse>()
                    {
                        IsSuccess = false,
                        Message = "Lỗi Gọi Api"

                    };
                }
            }
            catch
            {
                return new ApiResponsePro<LoginResponse>()
                {
                    IsSuccess = false,
                    Message = "Lỗi Đăng Nhập"

                };
            }
        }

        // xông
        public async Task<bool> DoiMatKhau(ResetPassword resetPassword)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/Authentication/DoiMatKhau";

                var content = new StringContent(JsonConvert.SerializeObject(resetPassword), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    if (responseObject != null)
                    {
                        if (responseObject != null) { return responseObject.IsSuccess; }
                        return false;
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

        // xông
        public async Task<bool> QuenMatKhau(string email, string linkReturn)
        {
            try
            {
                var apiUrl = $"{_apiUrl}/api/Authentication/QuenMatKhau?email={email}&linkReturn={linkReturn}";
                var content = new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                // Kiểm tra mã trạng thái HTTP để xác định xem yêu cầu đã thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    if (responseObject != null)
                    {
                        if (responseObject != null) { return responseObject.IsSuccess; }
                        return false;
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
    }
}