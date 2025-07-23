using AuthService.Application.DTO;

namespace AuthService.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(string email, string password);
    }
}
