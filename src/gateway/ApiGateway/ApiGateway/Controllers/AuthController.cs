using ApiGateway.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public AuthController(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] object registerRequest)
        {
            var url = _config["Services:AuthService"] + "/register";
            var response = await _httpClient.PostAsJsonAsync(url, registerRequest);
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, content);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var authUrl = _config["Services:AuthService"] + "/login";
            var response = await _httpClient.PostAsJsonAsync(authUrl, login);
            var content = await response.Content.ReadAsStringAsync();

            return Content(content, "application/json");
        }
    }
}
