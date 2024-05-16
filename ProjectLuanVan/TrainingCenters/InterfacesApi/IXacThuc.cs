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
        Task<ResponseDI<bool>> DangKy(RegisterUser item, string linkReturn, string accessToken);
        Task<ApiResponsePro<LoginResponse>> DangNhap(LoginModel item);
        Task<ApiResponsePro<RegisterUser>> GetByEmail(string email);
        Task<ApiResponsePro<LoginResponse>> CapNhatToken(LoginResponse tokens);
        Task<bool> QuenMatKhau(string email, string linkReturn);
        Task<bool> DoiMatKhau(ResetPassword resetPassword);
    }
}
