using MediatR;

namespace Application.Features.Logradouros.ListarLogradouros
{
    public class ListarLogradourosRequest : IRequest<List<ListarLogradourosResponse>>
    {
        public string ClienteEmail { get; set; }

        public ListarLogradourosRequest(string clienteEmail)
        {
            clienteEmail = clienteEmail;
        }
    }
}
