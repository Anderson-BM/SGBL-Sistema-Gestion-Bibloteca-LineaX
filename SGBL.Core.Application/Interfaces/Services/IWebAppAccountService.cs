using   SGBL.Core.Application.Dtos.Account;

namespace SGBL.Core.Application.Interfaces.Services
{
    public interface IWebAppAccountService : IBaseAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest registerRequest, string origin);
        Task SignOutAsync();
    }
}