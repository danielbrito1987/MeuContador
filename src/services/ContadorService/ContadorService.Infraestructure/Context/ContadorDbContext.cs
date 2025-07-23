using ContadorService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContadorService.Infraestructure.Context
{
    public class ContadorDbContext : DbContext
    {
        public ContadorDbContext(DbContextOptions<ContadorDbContext> options) : base(options)
        {
        }

        public DbSet<Contador> Contadores {  get; set; }
    }
}
