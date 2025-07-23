using ContadorService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContadorService.Application.Interfaces.Services
{
    public interface IContadorService
    {
        Task<List<ContadorResponseDto>> GetAllAsync();
        Task<ContadorResponseDto> CreateAsync(ContadorDto dto);
    }
}
