using ClienteService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteService.Infraestructure.Context
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Nome).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Email).HasMaxLength(150);
                entity.Property(c => c.Telefone).HasMaxLength(20);
            });
        }
    }
}
