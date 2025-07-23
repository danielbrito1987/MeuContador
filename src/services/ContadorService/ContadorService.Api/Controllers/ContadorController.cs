using AutoMapper;
using ContadorService.Application.DTOs;
using ContadorService.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContadorService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ContadorController : ControllerBase
    {
        private readonly IContadorService _service;
        private readonly IMapper _mapper;

        public ContadorController(IContadorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contadores = await _service.GetAllAsync();

            if(contadores == null || contadores.Count == 0)
                return NotFound();

            return Ok(contadores);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContadorDto dto)
        {
            var created = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }
    }
}
