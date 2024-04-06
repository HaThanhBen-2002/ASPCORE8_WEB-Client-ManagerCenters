﻿using Data.Models;
using ManagementService.Models;
using ManagementService.Models.Authentication.Login;
using ManagementService.Models.Authentication.ResetPassword;
using ManagementService.Models.Authentication.SignUp;
using ManagementService.Models.Authentication.User;
using Microsoft.AspNetCore.Identity;

namespace ManagementService.Services.Interfaces
{
    public interface IUserManagement
    {
        Task<ApiResponse<CreateUserResponse>> CreateUserWithTokenAsync(RegisterUser registerUser);
        Task<ApiResponse<List<string>>> AssignRoleToUserAsync(List<string> roles, ApplicationUser user);
        Task<ApiResponse<LoginOtpResponse>> GetOtpByLoginAsync(LoginModel loginModel);
        Task<ApiResponse<LoginResponse>> GetJwtTokenAsync(ApplicationUser user);
        Task<ApiResponse<LoginResponse>> LoginUserWithJWTokenAsync(string otp, string userName);
        Task<ApiResponse<LoginResponse>> RenewAccessTokenAsync(LoginResponse tokens);
    }
}