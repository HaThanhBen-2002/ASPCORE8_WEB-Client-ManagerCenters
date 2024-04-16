using ManagementService.Models.Authentication.Login;
using ManagementService.Models.Authentication.SignUp;
using ManagementService.Models.Authentication.User;
using TrainingCenters.Models;
using TrainingCenters.Models.Auth;
using TrainingCenters.Models.ModelMN;
namespace TrainingCenters.InterfacesApi
{
    public interface IXacThuc
    {
        Task<bool> DangKy(RegisterUser item, string linkReturn);
        Task<ApiResponse> DangNhap(LoginModel item);
        Task<ApiResponse> DangNhapOtp(string code, string userName);
        Task<bool> CapNhatToken(LoginResponse tokens);
        Task<bool> QuenMatKhau(string email, string linkReturn);
        Task<bool> DoiMatKhau(ResetPassword resetPassword);
    }
}
