namespace Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public byte[]? Logotipo { get; set; }

        public List<Logradouro> Logradouros { get; set; } = new List<Logradouro>();

        public Cliente() { }

        public Cliente(string nome, string email, byte[]? logotipo = null)
        {
            Nome = nome;

            Email = email;

            Logotipo = logotipo;
        }
    }
}
