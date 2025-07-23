using AutoMapper;
using ClienteService.Application.DTO;
using ClienteService.Application.Interfaces.Services;
using ClienteService.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClienteService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();

            if (clientes == null || clientes.Count == 0)
                return NotFound();

            return Ok(clientes);
        }

        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var cliente = await _clienteService.GetByEmail(email);

            if (cliente == null) return NotFound();

            return Ok(cliente);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cliente = await _clienteService.GetById(id);

            if (cliente == null) return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteRequest request)
        {
            var cliente = await _clienteService.AddClienteAsync(request);

            var response = _mapper.Map<ClienteDto>(cliente);

            return Ok(response);
        }
    }
}
