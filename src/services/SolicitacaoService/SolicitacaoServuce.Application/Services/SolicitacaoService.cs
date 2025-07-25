using AutoMapper;
using SolicitacaoService.Domain.Entities;
using SolicitacaoService.Application.DTO;
using SolicitacaoService.Application.Interfaces.Repositories;
using SolicitacaoService.Application.Interfaces.Services;

namespace SolicitacaoService.Application.Services
{
    public class SolicitacaoService : ISolicitacaoService
    {
        private readonly ISolicitacaoRepository _repository;
        private readonly IMapper _mapper;

        public SolicitacaoService(ISolicitacaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SolicitacaoResponseDto> CriarSolicitacaoAsync(Guid clienteId, SolicitacaoRequestDto request)
        {
            var solicitacao = _mapper.Map<Solicitacao>(request);
            solicitacao.ClienteId = clienteId;

            await _repository.AddSolicitacao(solicitacao);

            var dto = _mapper.Map<SolicitacaoResponseDto>(solicitacao);

            return dto;
        }

        public async Task<IEnumerable<SolicitacaoResponseDto>> ObterPorCliente(Guid clienteId)
        {
            return _mapper.Map<IEnumerable<SolicitacaoResponseDto>>(await _repository.GetByClienteId(clienteId));
        }
    }
}
