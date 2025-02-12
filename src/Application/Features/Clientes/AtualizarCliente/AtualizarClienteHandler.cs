using Application.Features.AtualizarCliente;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Clientes.AtualizarCliente
{
    public class AtualizarClienteHandler : IRequestHandler<AtualizarClienteRequest, bool>
    {
        private readonly IClienteRepository _clienteRepository;

        public AtualizarClienteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Handle(AtualizarClienteRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.ObterPorEmailAsync(request.Email);

            if (cliente == null)
            {
                return false;
            }

            cliente.Nome = request.Nome;
            cliente.Email = request.Email;

            if (request.Logotipo != null)
            {
                using var memoryStream = new MemoryStream();
                await request.Logotipo.CopyToAsync(memoryStream);
                cliente.Logotipo = memoryStream.ToArray();
            }

            await _clienteRepository.AtualizarAsync(cliente);
            return true;
        }
    }
}