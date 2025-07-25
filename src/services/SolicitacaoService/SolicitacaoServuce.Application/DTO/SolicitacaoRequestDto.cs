using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitacaoService.Application.DTO
{
    public class SolicitacaoRequestDto
    {
        public string Titulo {  get; set; } = string.Empty;
        public string Descricao {  get; set; } = string.Empty;
    }
}
