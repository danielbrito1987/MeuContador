using SolicitacaoService.Domain.Enums;

namespace SolicitacaoService.Domain.Entities
{
    public class Solicitacao
    {
        public Guid Id {  get; set; } = Guid.NewGuid();
        public string Titulo {  get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public StatusSolicitacaoEnum Status { get; set; } = StatusSolicitacaoEnum.Aberta;
        public Guid ClienteId {  get; set; }
        public Guid? ContadorId {  get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<MensagemSolicitacao>? Mensagens {  get; set; }
    }
}
