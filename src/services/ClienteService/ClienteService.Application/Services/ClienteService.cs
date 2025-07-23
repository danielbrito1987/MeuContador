using AutoMapper;
using ClienteService.Application.DTO;
using ClienteService.Application.Interfaces.Repositories;
using ClienteService.Application.Interfaces.Services;
using ClienteService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteService.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClienteDto> AddClienteAsync(ClienteRequest request)
        {
            var cliente = _mapper.Map<Cliente>(request);

            await _repository.AddClienteAsync(cliente);

            var dto = _mapper.Map<ClienteDto>(cliente);

            return dto;
        }

        public async Task<IList<ClienteDto>> GetAllAsync()
        {
            return _mapper.Map<IList<ClienteDto>>(await _repository.GetAllAsync());
        }

        public async Task<ClienteDto?> GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new Exception("Informa um e-mail");

            return _mapper.Map<ClienteDto?>(await _repository.GetByEmail(email));
        }

        public async Task<ClienteDto?> GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("Informe um ID."); 

            return _mapper.Map<ClienteDto?>(await _repository.GetById(id));
        }
    }
}
