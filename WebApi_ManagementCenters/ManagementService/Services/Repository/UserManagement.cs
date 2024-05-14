using Azure;
using Data.Models;
using ManagementService.Models;
using ManagementService.Models.Authentication.Login;
using ManagementService.Models.Authentication.SignUp;
using ManagementService.Models.Authentication.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Common;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static ManagementService.Support.Support;
using ManagementService.Services.Interfaces;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ManagementService.Services.Repository
{
    public class UserManagement : IUserManagement
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserManagement(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;

        }

        public async Task<ApiResponse<List<string>>> AssignRoleToUserAsync(List<string> roles, ApplicationUser user)
        {
            var assignedRole = new List<string>();
            foreach (var role in roles)
            {
                if (await _roleManager.RoleExistsAsync(role))
                {
                    if (!await _userManager.IsInRoleAsync(user, role))
                    {
                        await _userManager.AddToRoleAsync(user, role);
                        assignedRole.Add(role);
                    }
                }
            }

            return new ApiResponse<List<string>>
            {
                IsSuccess = true,
                StatusCode = 200,
                Message = "Roles has been assigned"
            ,
                Response = assignedRole
            };
        }
        public async Task<ApiResponse<CreateUserResponse>> CreateUserWithTokenAsync(RegisterUser registerUser)
        {
            //Check User Exist 
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExist != null)
            {
                return new ApiResponse<CreateUserResponse> { IsSuccess = false, StatusCode = 403, Message = "Email đã được sử dụng!" };
            }

            ApplicationUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Email,
                Khoa = false,
                NgayTao = GetCurrentDateTime(),
                NgayCapNhat = GetCurrentDateTime(),
                MaTrungTam = registerUser.MaTrungTam,
                TwoFactorEnabled = false
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                return new ApiResponse<CreateUserResponse> { Response = new CreateUserResponse() { User = user, Token = token }, IsSuccess = true, StatusCode = 201, Message = "User Created" };

            }
            else
            {
                return new ApiResponse<CreateUserResponse> { IsSuccess = false, StatusCode = 500, Message = "User Failed to Create" };

            }

        }
        //public async Task<ApiResponse<LoginOtpResponse>> GetOtpByLoginAsync(LoginModel loginModel)
        //{
        //    var user = await _userManager.FindByNameAsync(loginModel.Username);
        //    if (user != null)
        //    {
        //        await _signInManager.SignOutAsync();
        //        var n = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, true);
        //        if (n.RequiresTwoFactor!= true)
        //        {
        //            return new ApiResponse<LoginOtpResponse>
        //            {
        //                IsSuccess = false,
        //                StatusCode = 404,
        //                Message = $"Mật khẩu không đúng"
        //            };
        //        }
        //        if (user.TwoFactorEnabled)
        //        {
        //            var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
        //            return new ApiResponse<LoginOtpResponse>
        //            {
        //                Response = new LoginOtpResponse()
        //                {
        //                    User = user,
        //                    Token = token,
        //                    IsTwoFactorEnable = user.TwoFactorEnabled
        //                },
        //                IsSuccess = true,
        //                StatusCode = 200,
        //                Message = $"OTP send to the email {user.Email}"
        //            };

        //        }
        //        else
        //        {
        //            return new ApiResponse<LoginOtpResponse>
        //            {
        //                Response = new LoginOtpResponse()
        //                {
        //                    User = user,
        //                    Token = string.Empty,
        //                    IsTwoFactorEnable = user.TwoFactorEnabled
        //                },
        //                IsSuccess = true,
        //                StatusCode = 200,
        //                Message = $"2FA is not enabled"
        //            };
        //        }
        //    }
        //    else
        //    {
        //        return new ApiResponse<LoginOtpResponse>
        //        {
        //            IsSuccess = false,
        //            StatusCode = 404,
        //            Message = $"User doesnot exist."
        //        };
        //    }
        //}
        public async Task<ApiResponse<LoginOtpResponse>> GetOtpByLoginAsync(LoginModel loginModel, SignInResult n)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user != null)
            {
                
                if (n.IsLockedOut)
                {
                    return new ApiResponse<LoginOtpResponse>
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Message = $"Tài khoản của bạn đã bị khóa 5 phút"
                    };
                }
                if (n.Succeeded == true)
                {
                    return new ApiResponse<LoginOtpResponse>
                    {
                        Response = new LoginOtpResponse()
                        {
                            User = user,
                            Token = string.Empty,
                            IsTwoFactorEnable = user.TwoFactorEnabled
                        },
                        IsSuccess = true,
                        StatusCode = 200,
                        Message = $"Đăng nhập thành công"
                    };
                }
                if (user.TwoFactorEnabled)
                {
                   
                    return new ApiResponse<LoginOtpResponse>
                    {
                        Response = new LoginOtpResponse()
                        {
                            User = user,
                            Token = "",
                            IsTwoFactorEnable = user.TwoFactorEnabled
                        },
                        IsSuccess = true,
                        StatusCode = 200,
                        Message = $"OTP đã được gửi đến {user.Email}"
                    };
                }
                else
                {
                    return new ApiResponse<LoginOtpResponse>
                    {
                        Response = new LoginOtpResponse()
                        {
                            User = user,
                            Token = string.Empty,
                            IsTwoFactorEnable = user.TwoFactorEnabled
                        },
                        IsSuccess = false,
                        StatusCode = 200,
                        Message = $"Sai mật khẩu"
                    };
                }
            }
            else
            {
                return new ApiResponse<LoginOtpResponse>
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = $"Tài khoản không tồn tại"
                };
            }
        }

        public async Task<ApiResponse<LoginResponse>> GetJwtTokenAsync(ApplicationUser user)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var jwtToken = GetToken(authClaims); //access token
            var refreshToken = GenerateRefreshToken();
            _ = int.TryParse(_configuration["JWT:RefreshTokenValidity"], out int refreshTokenValidity);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(refreshTokenValidity);

            await _userManager.UpdateAsync(user);

            return new ApiResponse<LoginResponse>
            {
                Response = new LoginResponse()
                {
                    AccessToken = new TokenType()
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                        ExpiryTokenDate = jwtToken.ValidTo
                    },
                    RefreshToken = new TokenType()
                    {
                        Token = user.RefreshToken,
                        ExpiryTokenDate = (DateTime)user.RefreshTokenExpiry
                    },
                    Role = userRoles[0]
                },

                IsSuccess = true,
                StatusCode = 200,
                Message = $"Đăng nhập thành công"
            };
        }
        public async Task<ApiResponse<LoginResponse>> LoginUserWithJWTokenAsync(string userName, SignInResult signIn)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (signIn.Succeeded)
            {
                if (user != null)
                {
                    return await GetJwtTokenAsync(user);
                }
            }
            return new ApiResponse<LoginResponse>()
            {
                Response = new LoginResponse()
                {

                },
                IsSuccess = false,
                StatusCode = 400,
                Message = $"Mật khẩu không đúng"
            };
        }
        public async Task<ApiResponse<LoginResponse>> RenewAccessTokenAsync(LoginResponse tokens)
        {
            var accessToken = tokens.AccessToken;
            var refreshToken = tokens.RefreshToken;
            var principal = GetClaimsPrincipal(accessToken.Token);
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);
            if (refreshToken.Token != user.RefreshToken && refreshToken.ExpiryTokenDate <= DateTime.Now)
            {
                return new ApiResponse<LoginResponse>
                {

                    IsSuccess = false,
                    StatusCode = 400,
                    Message = $"Token không hợp lệ"
                };
            }
            var response = await GetJwtTokenAsync(user);
            return response;
        }

        #region PrivateMethods
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);
            var expirationTimeUtc = DateTime.UtcNow.AddMinutes(tokenValidityInMinutes);
            var localTimeZone = TimeZoneInfo.Local;
            var expirationTimeInLocalTimeZone = TimeZoneInfo.ConvertTimeFromUtc(expirationTimeUtc, localTimeZone);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: expirationTimeInLocalTimeZone,
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            var range = RandomNumberGenerator.Create();
            range.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private ClaimsPrincipal GetClaimsPrincipal(string accessToken)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out SecurityToken securityToken);

            return principal;

        }

        public async Task<ApiResponse<RegisterUser>> GetByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            List<string> userRoles = (List<string>)await _userManager.GetRolesAsync(user);
            RegisterUser valueReturn = new RegisterUser();
            valueReturn.Email = user.UserName;
            valueReturn.MaTrungTam = user.MaTrungTam;
            valueReturn.Password = user.PasswordHash;
            valueReturn.Roles = userRoles;
            if (user == null || userRoles == null)
            {
                return new ApiResponse<RegisterUser>()
                {
                    Response = new RegisterUser(),
                    IsSuccess = false,
                    StatusCode = 200,
                    Message = $"Lấy thông tin tài khoản thất bại"
                };
            }

            return new ApiResponse<RegisterUser>()
            {
                Response = valueReturn,
                IsSuccess = true,
                StatusCode = 200,
                Message = $"Lấy thông tin tài khoản thành công"
            };
        }
        #endregion

    }
}
