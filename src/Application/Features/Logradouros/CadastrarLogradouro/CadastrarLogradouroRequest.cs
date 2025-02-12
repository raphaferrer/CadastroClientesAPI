using MediatR;

namespace Application.Features.Logradouros.CadastrarLogradouro
{
    public class CadastrarLogradouroRequest : IRequest<CadastrarLogradouroResponse>
    {
        public string ClienteEmail { get; set; }

        public string Endereco { get; set; }

        public CadastrarLogradouroRequest(string clienteEmail, string endereco)
        {
            ClienteEmail = ClienteEmail;

            Endereco = endereco;
        }
    }
}
