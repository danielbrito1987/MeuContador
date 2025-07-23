using ApiGateway.DTOs;
using ApiGateway.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("contador")]
    public class ContadorController : ControllerBase
    {
        private readonly IServuceUrlResolver _urlResolver;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;

        public ContadorController(IHttpClientFactory clientFactory, IConfiguration config, IServuceUrlResolver urlResolver)
        {
            _clientFactory = clientFactory;
            _config = config;
            _urlResolver = urlResolver;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString();
            var url = _urlResolver.GetUrl("ContadorService");
            var client = _clientFactory.CreateClient("ProxyCliente");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
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
                var clientes = JsonSerializer.Deserialize<List<ContadorResponseDto>>(body, options);

                return StatusCode((int)response.StatusCode, clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, stack = ex.StackTrace });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContadorDto clientRequest)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString();
            var url = _urlResolver.GetUrl("ContadorService");
            var client = _clientFactory.CreateClient("ProxyCliente");

            var json = JsonSerializer.Serialize(clientRequest);
            using var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            if (!string.IsNullOrWhiteSpace(token))
                request.Headers.Add("Authorization", token);

            try
            {
                var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                var body = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var cliente = JsonSerializer.Deserialize<ContadorResponseDto>(body, options);

                return StatusCode((int)response.StatusCode, cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, stack = ex.StackTrace });
            }
        }
    }
}
