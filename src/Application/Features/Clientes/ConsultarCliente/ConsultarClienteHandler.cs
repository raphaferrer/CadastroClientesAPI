using Domain.Interfaces;
using MediatR;

namespace Application.Features.Clientes.ConsultarCliente
{
    public class ConsultarClienteHandler : IRequestHandler<ConsultarClienteRequest, ConsultarClienteResponse>
    {
        private readonly IClienteRepository _clienteRepository;

        public ConsultarClienteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ConsultarClienteResponse> Handle(ConsultarClienteRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.ObterPorEmailAsync(request.Email);

            return cliente != null ? new ConsultarClienteResponse(cliente.Id, cliente.Nome, cliente.Email) : null;
        }
    }
}