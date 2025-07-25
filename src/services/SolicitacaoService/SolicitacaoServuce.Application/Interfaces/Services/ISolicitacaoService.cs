using SolicitacaoService.Application.DTO;

namespace SolicitacaoService.Application.Interfaces.Services
{
    public interface ISolicitacaoService
    {
        Task<SolicitacaoResponseDto> CriarSolicitacaoAsync(Guid clienteId, SolicitacaoRequestDto request);
        Task<IEnumerable<SolicitacaoResponseDto>> ObterPorCliente(Guid clienteId);
    }
}
