namespace Application.Features.Clientes.ConsultarCliente
{
    public class ConsultarClienteResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public ConsultarClienteResponse(Guid id, string nome, string email)
        {
            Id = id;

            Nome = nome;

            Email = email;
        }
    }
}
