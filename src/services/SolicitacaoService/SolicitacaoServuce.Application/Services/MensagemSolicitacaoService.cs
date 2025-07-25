using AutoMapper;
using SolicitacaoService.Application.DTO;
using SolicitacaoService.Application.Interfaces.Repositories;
using SolicitacaoService.Application.Interfaces.Services;
using SolicitacaoService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitacaoService.Application.Services
{
    public class MensagemSolicitacaoService : IMensagemSolicitacaoService
    {
        private readonly IMensagemSolicitacaoRepository _repository;
        private readonly IMapper _mapper;

        public MensagemSolicitacaoService(IMensagemSolicitacaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MensagemSolicitacaoResponseDto> AddMensagemAsync(Guid solicitacaoId, Guid autorId, string autorRole, MensagemSolicitacaoRequestDto request)
        {
            var mensagem = _mapper.Map<MensagemSolicitacao>(request);
            mensagem.SolicitacaoId = solicitacaoId;
            mensagem.AutorId = autorId;
            mensagem.AutorRole = autorRole;

            await _repository.AddMensagemSolicitacao(mensagem);

            var dto = _mapper.Map<MensagemSolicitacaoResponseDto>(mensagem);

            return dto;
        }

        public async Task<IEnumerable<MensagemSolicitacaoResponseDto>> GetAllAsync(Guid solicitacaoid)
        {
            return _mapper.Map<IEnumerable<MensagemSolicitacaoResponseDto>>(await _repository.GetAllAsync(solicitacaoid));
        }
    }
}
