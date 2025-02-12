namespace Application.Features.Logradouros.CadastrarLogradouro
{
    public class CadastrarLogradouroResponse
    {
        public Guid Id { get; set; }
        public string ClienteEmail { get; set; }
        public string Endereco { get; set; }

        public CadastrarLogradouroResponse(Guid id, string clienteEmail, string endereco)
        {
            Id = id;

            ClienteEmail = clienteEmail;

            Endereco = endereco;
        }
    }
}
