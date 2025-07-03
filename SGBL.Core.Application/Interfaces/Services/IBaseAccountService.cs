using SGBL.Core.Application.Dtos.Account;

namespace SGBL.Core.Application.Interfaces.Services
{
    public interface IBaseAccountService
    {     
        Task<string> ConfirmAccountAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
        Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest request, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request);      
    }
}