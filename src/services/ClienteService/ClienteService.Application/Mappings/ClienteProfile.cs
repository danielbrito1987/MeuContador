using AutoMapper;
using ClienteService.Application.DTO;
using ClienteService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteService.Application.Mappings
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteDto, Cliente>().ReverseMap();
            CreateMap<ClienteRequest, Cliente>().ReverseMap();
        }
    }
}
