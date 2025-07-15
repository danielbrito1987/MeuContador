using AuthService.Application.DTO;
using AuthService.Application.Helper;
using AuthService.Application.Interfaces.Services;
using AuthService.Domain.Entities;
using AuthService.Infraestructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var token = await _service.RegisterAsync(request.Name, request.Email, request.Password);
            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var token = await _service.LoginAsync(request.Email, request.Password);
            if (token == null)
                return Unauthorized("Credenciais inválidas.");

            return Ok(new { Token = token });
        }
    }
}
