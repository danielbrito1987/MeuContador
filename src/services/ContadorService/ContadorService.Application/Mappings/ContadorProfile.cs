using AutoMapper;
using ContadorService.Application.DTOs;
using ContadorService.Domain.Entities;

namespace ContadorService.Application.Mappings
{
    public class ContadorProfile : Profile
    {
        public ContadorProfile()
        {
            CreateMap<Contador, ContadorResponseDto>().ReverseMap();
            CreateMap<ContadorDto, Contador>().ReverseMap();
        }
    }
}
