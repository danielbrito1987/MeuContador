using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolicitacaoService.Application.DTO;
using SolicitacaoService.Application.Interfaces.Services;

namespace SolicitacaoService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Cliente")]
    public class SolicitacaoController : ControllerBase
    {
        private readonly ISolicitacaoService _service;

        public SolicitacaoController(ISolicitacaoService service)
        {
            _service = service;
        }

        private Guid GetClienteIdFromToken()
        {
            var linkedEntityId = User.FindFirst("linkedEntityId")?.Value;
            if (string.IsNullOrEmpty(linkedEntityId))
                throw new UnauthorizedAccessException("linkedEntityId não encontrado no token.");

            return Guid.Parse(linkedEntityId);
        }

        [HttpPost]
        public async Task<IActionResult> CriarSolicitacao([FromBody] SolicitacaoRequestDto request)
        {
            var clienteId = GetClienteIdFromToken();
            var solicitacao = await _service.CriarSolicitacaoAsync(clienteId, request);

            return Ok(solicitacao);
        }

        [HttpPost("GetByCliente")]
        public async Task<IActionResult> GetByCliente()
        {
            var clienteId = GetClienteIdFromToken();
            var lista = await _service.ObterPorCliente(clienteId);

            return Ok(lista);
        }
    }
}
