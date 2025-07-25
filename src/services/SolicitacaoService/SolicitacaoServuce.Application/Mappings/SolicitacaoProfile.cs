using AutoMapper;
using SolicitacaoService.Domain.Entities;
using SolicitacaoService.Application.DTO;

namespace SolicitacaoService.Application.Mappings
{
    public class SolicitacaoProfile : Profile
    {
        public SolicitacaoProfile()
        {
            CreateMap<SolicitacaoResponseDto, Solicitacao>().ReverseMap();
            CreateMap<SolicitacaoRequestDto, Solicitacao>().ReverseMap();

            CreateMap<MensagemSolicitacaoResponseDto, MensagemSolicitacao>().ReverseMap();
            CreateMap<MensagemSolicitacaoRequestDto, MensagemSolicitacao>().ReverseMap();
        }
    }
}
