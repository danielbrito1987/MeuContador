using SolicitacaoService.Domain.Entities;

namespace SolicitacaoService.Application.Interfaces.Repositories
{
    public interface IMensagemSolicitacaoRepository
    {
        Task AddMensagemSolicitacao(MensagemSolicitacao request);
        Task<IEnumerable<MensagemSolicitacao>> GetAllAsync(Guid solicitacaoid);
    }
}
