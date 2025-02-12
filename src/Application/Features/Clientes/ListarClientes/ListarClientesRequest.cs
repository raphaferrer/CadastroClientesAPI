using MediatR;

namespace Application.Features.Clientes.ListarClientes
{
    public class ListarClientesRequest : IRequest<List<ListarClientesResponse>>
    {
    }
}
