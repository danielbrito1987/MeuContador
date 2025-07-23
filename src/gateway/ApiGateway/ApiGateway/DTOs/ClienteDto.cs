namespace ApiGateway.DTOs
{
    public class ClienteDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Guid LinkedEntityId { get; set; } = Guid.Empty;
        public string Role { get; set; } = "Cliente";
    }
}
