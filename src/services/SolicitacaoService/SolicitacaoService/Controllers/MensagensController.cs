using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolicitacaoService.Application.DTO;
using SolicitacaoService.Application.Interfaces.Services;
using System.Security.Claims;

namespace SolicitacaoService.Api.Controllers
{
    [ApiController]
    [Route("api/solicitacoes/{solicitacaoId}/mensagens")]
    [Authorize]
    public class MensagensController : ControllerBase
    {
        private readonly IMensagemSolicitacaoService _service;

        public MensagensController(IMensagemSolicitacaoService service)
        {
            _service = service;
        }
        private (Guid autorId, string autorRole) GetUserInfoFromToken()
        {
            var linkedEntityId = User.FindFirst("linkedEntityId")?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(linkedEntityId) || string.IsNullOrEmpty(role))
                throw new UnauthorizedAccessException("linkedEntityId ou role não encontrado no token");

            return (Guid.Parse(linkedEntityId), role);
        }

        [HttpPost]
        public async Task<IActionResult> EnviarMensagem(Guid solicitacaoId, [FromBody] MensagemSolicitacaoRequestDto request)
        {
            var (autorId, autorRole) = GetUserInfoFromToken();

            var mensagem = await _service.AddMensagemAsync(solicitacaoId, autorId, autorRole, request);

            return Ok(mensagem);
        }

        [HttpGet]
        public async Task<IActionResult> ListarMensagens(Guid solicitacaoId)
        {
            var mensagens = await _service.GetAllAsync(solicitacaoId);
            return Ok(mensagens);
        }
    }
}
