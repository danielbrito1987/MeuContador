using SolicitacaoService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitacaoService.Application.DTO
{
    public class SolicitacaoResponseDto
    {
        public Guid Id {  get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao {  get; set; } = string.Empty;
        public StatusSolicitacaoEnum Status {  get; set; }
        public Guid ClienteId {  get; set; }
        public Guid? ContadorId { get; set; }
        public DateTime CreatedAt {  get; set; }
    }
}
