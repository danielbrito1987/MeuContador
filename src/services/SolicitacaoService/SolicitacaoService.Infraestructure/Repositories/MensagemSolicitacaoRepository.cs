using Microsoft.EntityFrameworkCore;
using SolicitacaoService.Application.DTO;
using SolicitacaoService.Application.Interfaces.Repositories;
using SolicitacaoService.Domain.Entities;
using SolicitacaoService.Infraestructure.Context;

namespace SolicitacaoService.Infraestructure.Repositories
{
    public class MensagemSolicitacaoRepository : IMensagemSolicitacaoRepository
    {
        private readonly SolicitacaoDbContext _context;

        public MensagemSolicitacaoRepository(SolicitacaoDbContext context)
        {
            _context = context;
        }

        public async Task AddMensagemSolicitacao(MensagemSolicitacao request)
        {
            var solicitacao = await _context.Solicitacoes.FindAsync(request.SolicitacaoId);
            if (solicitacao is null)
                throw new Exception("Solicitação não encontrada!");

            _context.MensagensSolicitacao.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MensagemSolicitacao>> GetAllAsync(Guid solicitacaoid)
        {
            return await _context.MensagensSolicitacao
                .Where(x => x.SolicitacaoId == solicitacaoid)
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();
        }
    }
}
