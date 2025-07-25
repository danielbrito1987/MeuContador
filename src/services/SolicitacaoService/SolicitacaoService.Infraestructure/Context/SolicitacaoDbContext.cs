using Microsoft.EntityFrameworkCore;
using SolicitacaoService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitacaoService.Infraestructure.Context
{
    public class SolicitacaoDbContext : DbContext
    {
        public SolicitacaoDbContext(DbContextOptions<SolicitacaoDbContext> options) : base(options)
        {
        }

        public DbSet<Solicitacao> Solicitacoes {  get; set; }
        public DbSet<MensagemSolicitacao> MensagensSolicitacao {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Solicitacao>()
                .HasMany(s => s.Mensagens)
                .WithOne(m => m.Solicitacao)
                .HasForeignKey(m => m.SolicitacaoId);
        }
    }
}
