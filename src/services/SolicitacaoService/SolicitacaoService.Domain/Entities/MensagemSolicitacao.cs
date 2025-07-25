using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitacaoService.Domain.Entities
{
    public class MensagemSolicitacao
    {
        public Guid Id {  get; set; } = Guid.NewGuid();
        public Guid SolicitacaoId { get; set; }
        public Solicitacao Solicitacao { get; set; } = null!;
        public string AutorRole { get; set; } = string.Empty;
        public Guid AutorId { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public string? Anexo {  get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
