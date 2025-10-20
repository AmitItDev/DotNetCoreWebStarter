
using DotNetCoreWebStarter.Core.Models.Login;

namespace DotNetCoreWebStarter.Core.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}
