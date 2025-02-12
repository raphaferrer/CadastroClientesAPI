using MediatR;

namespace Application.Features.Clientes.ConsultarCliente
{
    public class ConsultarClienteRequest : IRequest<ConsultarClienteResponse>
    {
        public string Email { get; }

        public ConsultarClienteRequest(string email)
        {
            Email = email;
        }
    }
}
