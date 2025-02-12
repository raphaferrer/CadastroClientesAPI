using Domain.Interfaces;
using MediatR;

namespace Application.Features.ExcluirCliente
{
    public class ExcluirClienteHandler : IRequestHandler<ExcluirClienteRequest, bool>
    {
        private readonly IClienteRepository _clienteRepository;

        public ExcluirClienteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Handle(ExcluirClienteRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.ObterPorEmailAsync(request.Email);

            if (cliente == null)
            {
                return false; 
            }

            await _clienteRepository.RemoverAsync(request.Email);
            return true;
        }
    }
}
