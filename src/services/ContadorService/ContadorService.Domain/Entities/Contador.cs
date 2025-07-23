using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContadorService.Domain.Entities
{
    public class Contador
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome {  get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone {  get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
