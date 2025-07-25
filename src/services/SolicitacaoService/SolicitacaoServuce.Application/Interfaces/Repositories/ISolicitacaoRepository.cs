using SolicitacaoService.Domain.Entities;

namespace SolicitacaoService.Application.Interfaces.Repositories
{
    public interface ISolicitacaoRepository
    {
        Task AddSolicitacao(Solicitacao solicitacao);
        Task<IEnumerable<Solicitacao>> GetByClienteId(Guid clienteId);
    }
}
