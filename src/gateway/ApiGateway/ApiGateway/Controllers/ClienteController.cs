using ApiGateway.DTOs;
using ApiGateway.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IServuceUrlResolver _urlResolver;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;

        public ClienteController(IHttpClientFactory clientFactory, IConfiguration config, IServuceUrlResolver urlResolver)
        {
            _clientFactory = clientFactory;
            _config = config;
            _urlResolver = urlResolver;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString();
            var clienteUrl = _urlResolver.GetUrl("ClienteService");
            var client = _clientFactory.CreateClient("ProxyCliente");

            var request = new HttpRequestMessage(HttpMethod.Get, clienteUrl);
            if (!string.IsNullOrWhiteSpace(token))
                request.Headers.Add("Authorization", token);

            try
            {
                var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return StatusCode((int)response.StatusCode, error);
                }

                var body = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var clientes = JsonSerializer.Deserialize<List<ClienteResponseDto>>(body, options);

                return StatusCode((int)response.StatusCode, clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, stack = ex.StackTrace });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDto clientRequest)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString();
            var clienteUrl = _urlResolver.GetUrl("ClienteService");
            var authUrl = _urlResolver.GetUrl("AuthService");
            var client = _clientFactory.CreateClient("ProxyCliente");

            var json = JsonSerializer.Serialize(clientRequest);
            using var request = new HttpRequestMessage(HttpMethod.Post, clienteUrl)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            if (!string.IsNullOrWhiteSpace(token))
                request.Headers.Add("Authorization", token);

            try
            {
                var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                if (!response.IsSuccessStatusCode)
                    return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

                var body = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var cliente = JsonSerializer.Deserialize<ClienteResponseDto>(body, options);

                var registerDto = new RegisterDto
                {
                    Nome = cliente!.Nome,
                    Email = cliente.Email,
                    Role = "Cliente",
                    Senha = clientRequest.Password,
                    LinkedEntityId = cliente.Id
                };

                var authResponse = await client.PostAsJsonAsync($"{authUrl}/register", registerDto);

                if (!authResponse.IsSuccessStatusCode)
                    return StatusCode((int)authResponse.StatusCode, await authResponse.Content.ReadAsStringAsync());

                var authResult = await authResponse.Content.ReadAsStringAsync();

                return Ok(new
                {
                    cliente,
                    auth = JsonSerializer.Deserialize<object>(authResult)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, stack = ex.StackTrace });
            }
        }
    }
}
