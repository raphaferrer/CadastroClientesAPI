using Domain.Entities;
using MediatR;
using Domain.Interfaces;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Clientes.CadastrarCliente
{
    public class CadastrarClienteHandler : IRequestHandler<CadastrarClienteRequest, CadastrarClienteResponse>
    {
        private readonly IClienteRepository _clienteRepository;

        public CadastrarClienteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<CadastrarClienteResponse> Handle(CadastrarClienteRequest request, CancellationToken cancellationToken)
        {
            var clienteExistente = await _clienteRepository.ObterPorEmailAsync(request.Email);

            if (clienteExistente != null)
            {
                throw new InvalidOperationException("Já existe um cliente cadastrado com este e-mail.");
            }

            byte[]? logotipoBytes = null;

            if (request.Logotipo != null)
            {
                using var memoryStream = new MemoryStream();
                await request.Logotipo.CopyToAsync(memoryStream);
                logotipoBytes = memoryStream.ToArray();
            }

            var cliente = new Cliente(request.Nome, request.Email, logotipoBytes);

            var clienteId = await _clienteRepository.CriarAsync(cliente);

            return new CadastrarClienteResponse(clienteId, cliente.Nome, cliente.Email);
        }
    }
}
