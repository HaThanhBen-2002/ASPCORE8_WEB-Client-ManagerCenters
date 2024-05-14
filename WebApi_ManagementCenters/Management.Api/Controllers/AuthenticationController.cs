using ManagementApi.Models;
using Data.Models;
using ManagementService.Models;
using ManagementService.Models.Authentication.Login;
using ManagementService.Models.Authentication.SignUp;
using ManagementService.Models.Authentication.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using ManagementService.Models.Authentication.ResetPassword;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
namespace ManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IUserManagement _user;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IEmailService emailService,
            IUserManagement user)
        {
            _userManager = userManager;
            _emailService = emailService;
            _user = user;
            _signInManager = signInManager;
        }


        [Authorize(Roles = "Quản lý trung tâm,Admin")]
        [HttpPost]
        [Route("DangKy")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string linkReturn)
        {

            var tokenResponse = await _user.CreateUserWithTokenAsync(registerUser);
            if (tokenResponse.IsSuccess && tokenResponse.Response != null)
            {
                await _user.AssignRoleToUserAsync(registerUser.Roles, tokenResponse.Response.User);

                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { tokenResponse.Response.Token, email = registerUser.Email, linkReturn = linkReturn}, Request.Scheme);

                var message = new ManagementService.Models.Message(new string[] { registerUser.Email! }, "Xác nhận email BENBEN", confirmationLink!);
                var responseMsg = _emailService.SendEmail(message);
                return StatusCode(StatusCodes.Status200OK,
                        new Response { IsSuccess = true, Message = $"{tokenResponse.Message} {responseMsg}" });

            }

            return StatusCode(StatusCodes.Status500InternalServerError,
                  new Response { Message = tokenResponse.Message, IsSuccess = false });
        }

        [HttpPost]
        [Route("GetByEmail")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _user.GetByEmail(email);
            return Ok(user);
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email, string linkReturn)
        {
            var user = await _userManager.FindByEmailAsync(email);
            //var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return Redirect(linkReturn);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                       new Response { Status = "Error", Message = "This User Doesnot exist!" });
        }

        [HttpPost]
        [Route("DangNhap")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            // Lưu thông tin vào Claims
            var user1 = await _userManager.FindByNameAsync(loginModel.Username);
            if (user1 != null)
            {
                await _signInManager.SignOutAsync();
                var n = await _signInManager.PasswordSignInAsync(user1, loginModel.Password, false, true);
                var loginOtpResponse = await _user.GetOtpByLoginAsync(loginModel, n);
                if (loginOtpResponse.IsSuccess)
                {
                    var jwt = await _user.LoginUserWithJWTokenAsync(loginModel.Username, n);
                    if (jwt.IsSuccess)
                    {
                        return Ok(jwt);
                    }

                    #region 2FA
                    // var token = await _userManager.GenerateTwoFactorTokenAsync(user1, "Email");
                    // loginOtpResponse.Response.Token = token;
                    //if (loginOtpResponse.Response != null)
                    //{
                    //    var user = loginOtpResponse.Response.User;
                    //    // Login 2 bước
                    //    if (user.TwoFactorEnabled)
                    //    {
                    //        var message = new Message(new string[] { user.Email! }, "Mã OTP BENBEN", token);
                    //        _emailService.SendEmail(message);

                    //        return StatusCode(StatusCodes.Status200OK,
                    //         new Response { IsSuccess = loginOtpResponse.IsSuccess, Status = "Success", Message = loginOtpResponse.Message });
                    //    }
                    //    // Login bằng mật khẩu
                    //    if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
                    //    {
                    //        var serviceResponse = await _user.GetJwtTokenAsync(user);
                    //        return Ok(serviceResponse);

                    //    }
                    //}
                    //return StatusCode(StatusCodes.Status200OK,
                    //          new Response { IsSuccess = false, Status = "Success", Message = loginOtpResponse.Message });
                    #endregion
                }
                return StatusCode(StatusCodes.Status200OK,
                              new Response { IsSuccess = false, Status = "Success", Message = loginOtpResponse.Message });

            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                      new Response { IsSuccess = false, Status = "404", Message = "Tài khoản không tồn tại" });

            }
        }

        //[HttpGet]
        //[Route("DangNhap-2FA")]
        //public async Task<IActionResult> LoginWithOTP(string code, string userName)
        //{
        //    var signIn = await _signInManager.TwoFactorSignInAsync("Email", code, false, false);
        //    var jwt = await _user.LoginUserWithJWTokenAsync(userName, signIn);
        //    if (jwt.IsSuccess)
        //    {
        //        return Ok(jwt);
        //    }
        //    return StatusCode(StatusCodes.Status200OK,
        //        new Response {IsSuccess= jwt.IsSuccess, Status = "Success", Message = jwt.Message });
        //}

        [HttpPost]
        [Route("CapNhat-Token")]
        public async Task<IActionResult> RefreshToken(LoginResponse tokens)
        {
            var jwt = await _user.RenewAccessTokenAsync(tokens);
            if (jwt.IsSuccess)
            {
                return Ok(jwt);
            }
            return StatusCode(StatusCodes.Status404NotFound,
                new Response { IsSuccess=false, Status = "Success", Message = $"Không thể cập nhật Token" });
        }

        //[HttpPost]
        //[Route("QuenMatKhau")]
        //public async Task<IActionResult> ForgotPassword(string email, string action, string controller)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);
        //    if (user != null)
        //    {
        //        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //        var forgotPasswordlink = Url.Action(nameof(action), controller, new { token= token, email = user.Email, }, Request.Scheme);
        //        var message = new ManagementService.Models.Message(new string[] { user.Email }, "Quên mật khẩu BENBEN", forgotPasswordlink);
        //        _emailService.SendEmail(message);

        //        return StatusCode(StatusCodes.Status200OK,
        //        new Response {IsSuccess= true, Status = "Success", Message = $"Hệ thống đã gửi đến Email {user.Email}" });;
        //    }
        //    return StatusCode(StatusCodes.Status400BadRequest,
        //        new Response {IsSuccess=false, Status = "Error", Message = $"Hệ thống không thể gửi thông tin đến Email của bạn" });
        //}

        [HttpPost]
        [Route("QuenMatKhau")]
        public async Task<IActionResult> ForgotPassword(string email, string linkReturn)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                // Sử dụng UriBuilder để tạo đường dẫn URL mới
                var uriBuilder = new UriBuilder(linkReturn)
                {
                    Query = $"token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(user.Email)}"
                };

                var forgotPasswordlink = uriBuilder.ToString();

                var message = new ManagementService.Models.Message(new string[] { user.Email }, "Quên mật khẩu BENBEN", forgotPasswordlink);
                _emailService.SendEmail(message);

                return StatusCode(StatusCodes.Status200OK,
                    new Response { IsSuccess = true, Status = "Success", Message = $"Hệ thống đã gửi đến Email {user.Email}" });
            }

            return StatusCode(StatusCodes.Status400BadRequest,
                new Response { IsSuccess = false, Status = "Error", Message = $"Hệ thống không thể gửi thông tin đến Email của bạn" });
        }



        [HttpPost]
        [Route("DoiMatKhau")]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user != null)
            {
                var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
                if (!resetPassResult.Succeeded)
                {
                    foreach (var error in resetPassResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return Ok(ModelState);
                }
                return StatusCode(StatusCodes.Status200OK, new Response
                {
                    IsSuccess = true,
                    Status = "Success",
                    Message = "Đổi mật khẩu thành công"
                });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new Response
            {
                IsSuccess = false,
                Status = "Error",
                Message = "Đổi mật khẩu thất bại"
            });
        }

        [HttpPost]
        [Route("MoKhoaTaiKhoan")]
        public async Task<IActionResult> UnlockAccount(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                // Đặt ngày khóa về null để mở khóa tài khoản
                var unlockResult = await _userManager.SetLockoutEndDateAsync(user, null);

                if (!unlockResult.Succeeded)
                {
                    foreach (var error in unlockResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return Ok(ModelState);
                }

                return StatusCode(StatusCodes.Status200OK, new Response
                {
                    IsSuccess = true,
                    Status = "Success",
                    Message = "Mở khóa tài khoản thành công"
                });
            }

            return StatusCode(StatusCodes.Status400BadRequest, new Response
            {
                IsSuccess = false,
                Status = "Error",
                Message = "Mở khóa tài khoản thất bại"
            });
        }

    }
}
