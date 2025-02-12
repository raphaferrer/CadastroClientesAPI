namespace Application.Features.Clientes.ListarClientes
{
    public class ListarClientesResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public byte[]? Logotipo { get; set; }
    }
}
