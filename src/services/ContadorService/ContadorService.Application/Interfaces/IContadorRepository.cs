using ContadorService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContadorService.Application.Interfaces
{
    public interface IContadorRepository
    {
        Task<List<Contador>> GetAllAsync();
        Task CreateAsync(Contador contador);
    }
}
