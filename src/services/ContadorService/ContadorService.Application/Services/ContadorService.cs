using AutoMapper;
using ContadorService.Application.DTOs;
using ContadorService.Application.Interfaces;
using ContadorService.Application.Interfaces.Services;
using ContadorService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContadorService.Application.Services
{
    public class ContadorService : IContadorService
    {
        private readonly IContadorRepository _contadorRepository;
        private readonly IMapper _mapper;

        public ContadorService(IContadorRepository contadorRepository, IMapper mapper)
        {
            _contadorRepository = contadorRepository;
            _mapper = mapper;
        }

        public async Task<ContadorResponseDto> CreateAsync(ContadorDto dto)
        {
            var contador = _mapper.Map<Contador>(dto);
            await _contadorRepository.CreateAsync(contador);

            return _mapper.Map<ContadorResponseDto>(contador);
        }

        public async Task<List<ContadorResponseDto>> GetAllAsync()
        {
            return _mapper.Map<List<ContadorResponseDto>>(await _contadorRepository.GetAllAsync());
        }
    }
}
