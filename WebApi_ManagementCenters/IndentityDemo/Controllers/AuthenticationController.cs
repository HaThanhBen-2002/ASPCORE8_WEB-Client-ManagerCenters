using IndentityDemo.Models;
using ManagementService.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using ManagementService.Models;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ManagementService.Models.Authentication.ResetPassword;
using ManagementService.Models.Authentication.Login;
using ManagementService.Models.Authentication.SignUp;
using NuGet.Common;
using ManagementData.Models;
using NuGet.Protocol.Plugins;
using ManagementService.Models.Authentication.User;

namespace IndentityDemo.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IUserManagement _user;
        public AuthenticationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signManager,
            RoleManager<IdentityRole> roleManager,IConfiguration configuration, IEmailService emailService, IUserManagement user)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _emailService = emailService;
            _signManager = signManager;
            _user = user;
        }

        [HttpPost]
        //Đăng ký tài khoản với Username là một Email Address
        //Cộng thêm tham số là một Role quyền người dùng
        //Mật khẩu đăng ký phải bao gồm ký tự đặc biệt, chứ cái IN và thường, số 
        //Email phải chưa từng được đăng ký trong hệ thống
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            var tokenResponse = await _user.CreateUserWithTokenAsync(registerUser);
            if (tokenResponse.IsSuccess && tokenResponse.Response != null)
            {
                await _user.AssignRoleToUserAsync(registerUser.Roles,tokenResponse.Response.User);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { tokenResponse.Response.Token, email = registerUser.Email }, Request.Scheme);
                var message = new ManagementService.Models.Message(new string[] { registerUser.Email }, "Email xác nhận BenBen", confirmationLink);
                _emailService.SendEmail(message);
                return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = $"Xác thực email thành công", IsSuccess=true });
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response { Status = "Failed", Message = tokenResponse.Message, IsSuccess = false });
        }


        [HttpGet("ConfirmEmail")]
        // Xác nhận email khi đăng ký Account
        // Gửi đến email đăng ký một email với link xác nhận
        // User click link để xác nhận đăng ký Account thành công
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    ViewData["Status"] = true;
                    return View();
                }
            }
            ViewData["Status"] = false;
            return View();
        }


        public async Task<IActionResult> Login()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        // Login với paramater là LoginModel gồm Username and Password
        // Login success return authToken + 3 giờ
        public async Task<IActionResult> Login(ManagementService.Models.Authentication.Login.LoginModel loginModel)
        {
            var loginResponse = await _user.GetOtpByLoginAsync(loginModel);
            if (loginResponse.Response != null)
            {
                //Checking the user
                var user = loginResponse.Response.User;
                // Xác thực 2 yếu tố
                if (user.TwoFactorEnabled)
                {
                    // Gửi OTP qua email
                    var message = new ManagementService.Models.Message(new string[] { user.Email }, "OTP xác nhận BENBEN", loginResponse.Response.Token);
                    _emailService.SendEmail(message);

                    return StatusCode(StatusCodes.Status200OK,
                    new Response {IsSuccess = loginResponse.IsSuccess, Status = "Success", Message = $"OTP đã được gửi đến Email {user.Email}" });
                }
                //Checking the password
                if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
                {
                    var serviceResponse = await _user.GetJwtTokenAsync(user);
                    return Ok(serviceResponse);
                }
            }

            return Unauthorized();

        }
        [HttpPost]
        public async Task<IActionResult> LoginWithOTP(string code, string username)
        {
            var jwt = await _user.LoginUserWithJWTokenAsync(code, username);
            if (jwt.IsSuccess)
            {
                return Ok(jwt);
            }
            return StatusCode(StatusCodes.Status404NotFound,
                new Response { Status = "Success", Message = "Mã code không đúng" });
        }

        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var forgotPasswordlink = Url.Action(nameof(ResetPassword), "Authentication", new { token, email = user.Email, }, Request.Scheme);
                var message = new ManagementService.Models.Message(new string[] { user.Email }, "Quên mật khẩu BENBEN", forgotPasswordlink);
                _emailService.SendEmail(message);

                return StatusCode(StatusCodes.Status200OK,
                new Response { Status = "Success", Message = $"Hệ thống đã gửi đến Email {user.Email}" });
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                new Response { Status = "Error", Message = $"Hệ thống không thể gửi thông tin đến Email của bạn" });
        }

        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };
            ViewData["Token"] = token;
            ViewData["Email"] = email;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user != null)
            {
                var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
                if (!resetPassResult.Succeeded)
                {
                    foreach(var error in resetPassResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return Ok(ModelState);
                }
                return StatusCode(StatusCodes.Status200OK, new Response
                {
                    Status = "Success",
                    Message = "Đổi mật khẩu thành công"
                });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new Response
            {
                Status = "Error",
                Message = "Đổi mật khẩu thất bại"
            });
        }


        [HttpPost]
        public async Task<IActionResult> RefreshToken(LoginResponse tokens)
        {
            var jwt = await _user.RenewAccessTokenAsync(tokens);
            if (jwt.IsSuccess)
            {
                return Ok(jwt);
            }
            return StatusCode(StatusCodes.Status404NotFound,
                new Response { Status = "Success", Message = $"Invalid Code" });
        }

        [HttpGet]
        // Test send email
        public IActionResult TestEmail()
        {
            var message = new ManagementService.Models.Message(new string[] {"mavuongkiki2002@gmail.com"}, "Be Thoại", "Bé thoại yêu của Ba Bền");
            _emailService.SendEmail(message);
            return StatusCode(StatusCodes.Status200OK, new Response
            {
                Status = "Success",
                Message = "Gửi email thành công"
            });
        }
    }
}
