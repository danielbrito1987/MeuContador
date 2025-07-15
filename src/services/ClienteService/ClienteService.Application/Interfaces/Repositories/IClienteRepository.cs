using ClienteService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteService.Application.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<IList<Cliente>> GetAllAsync();
        Task AddClienteAsync(Cliente cliente);
        Task<Cliente?> GetById(Guid id);
        Task<Cliente?> GetByEmail(string email);
    }
}
