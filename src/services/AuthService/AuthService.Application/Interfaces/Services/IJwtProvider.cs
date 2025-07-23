using AuthService.Domain.Entities;

namespace AuthService.Application.Interfaces.Services
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
