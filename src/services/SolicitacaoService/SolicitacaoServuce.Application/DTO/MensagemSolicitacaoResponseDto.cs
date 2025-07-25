using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitacaoService.Application.DTO
{
    public class MensagemSolicitacaoResponseDto
    {
        public Guid Id { get; set; }
        public Guid SolicitacaoId {  get; set; }
        public string AutorRole { get; set; } = string.Empty;
        public Guid AutorId {  get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public string? Anexo {  get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
