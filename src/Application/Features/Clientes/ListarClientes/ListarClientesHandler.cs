using Domain.Interfaces;
using MediatR;

namespace Application.Features.Clientes.ListarClientes
{
    public class ListarClientesHandler : IRequestHandler<ListarClientesRequest, List<ListarClientesResponse>>
    {
        private readonly IClienteRepository _clienteRepository;

        public ListarClientesHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ListarClientesResponse>> Handle(ListarClientesRequest request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository.ObterTodosAsync();

            return clientes.Select(c => new ListarClientesResponse
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Logotipo = c.Logotipo
            }).ToList();
        }
    }
}