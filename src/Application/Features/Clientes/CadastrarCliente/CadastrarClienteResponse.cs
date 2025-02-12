namespace Application.Features.Clientes.CadastrarCliente
{
    public class CadastrarClienteResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public CadastrarClienteResponse(Guid id, string nome, string email)
        {
            Id = id;

            Nome = nome;

            Email = email;
        }
    }
}
