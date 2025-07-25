using Microsoft.EntityFrameworkCore;
using SolicitacaoService.Domain.Entities;
using SolicitacaoService.Infraestructure.Context;
using SolicitacaoService.Application.Interfaces.Repositories;

namespace SolicitacaoService.Infraestructure.Repositories
{
    public class SolicitacaoRepository : ISolicitacaoRepository
    {
        private readonly SolicitacaoDbContext _context;

        public SolicitacaoRepository(SolicitacaoDbContext context)
        {
            _context = context;
        }

        public async Task AddSolicitacao(Solicitacao solicitacao)
        {
            _context.Solicitacoes.Add(solicitacao);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Solicitacao>> GetByClienteId(Guid clienteId)
        {
            return await _context.Solicitacoes.Where(x => x.ClienteId == clienteId).ToListAsync();
        }
    }
}
