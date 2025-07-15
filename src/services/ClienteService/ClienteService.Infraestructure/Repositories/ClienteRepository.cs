using ClienteService.Application.Interfaces.Repositories;
using ClienteService.Domain.Entities;
using ClienteService.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteService.Infraestructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDbContext _context;

        public ClienteRepository(ClienteDbContext context)
        {
            _context = context;
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetByEmail(string email)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Cliente?> GetById(Guid id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
