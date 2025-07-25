using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitacaoService.Application.DTO
{
    public class MensagemSolicitacaoRequestDto
    {
        public string Mensagem {  get; set; } = string.Empty;
        public string? Anexo { get; set; }
    }
}
