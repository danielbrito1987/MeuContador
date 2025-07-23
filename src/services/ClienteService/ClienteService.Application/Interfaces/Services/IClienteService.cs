using ClienteService.Application.DTO;

namespace ClienteService.Application.Interfaces.Services
{
    public interface IClienteService
    {
        Task<IList<ClienteDto>> GetAllAsync();
        Task<ClienteDto> AddClienteAsync(ClienteRequest cliente);
        Task<ClienteDto?> GetById(Guid id);
        Task<ClienteDto?> GetByEmail(string email);
    }
}
