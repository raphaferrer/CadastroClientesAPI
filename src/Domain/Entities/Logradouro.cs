namespace Domain.Entities
{
    public class Logradouro
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ClienteEmail { get; set; }

        public string Endereco { get; set; } = string.Empty;
    }
}
