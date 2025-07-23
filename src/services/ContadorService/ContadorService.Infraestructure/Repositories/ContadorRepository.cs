using ContadorService.Application.Interfaces;
using ContadorService.Domain.Entities;
using ContadorService.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContadorService.Infraestructure.Repositories
{
    public class ContadorRepository : IContadorRepository
    {
        private readonly ContadorDbContext _context;

        public ContadorRepository(ContadorDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Contador contador)
        {
            _context.Contadores.Add(contador);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Contador>> GetAllAsync()
        {
            return await _context.Contadores.ToListAsync();
        }
    }
}
