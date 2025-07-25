using SolicitacaoService.Application.DTO;

namespace SolicitacaoService.Application.Interfaces.Services
{
    public interface IMensagemSolicitacaoService
    {
        Task<MensagemSolicitacaoResponseDto> AddMensagemAsync(Guid solicitacaoId, Guid autorId, string autorRole, MensagemSolicitacaoRequestDto request);
        Task<IEnumerable<MensagemSolicitacaoResponseDto>> GetAllAsync(Guid solicitacaoid);
    }
}
