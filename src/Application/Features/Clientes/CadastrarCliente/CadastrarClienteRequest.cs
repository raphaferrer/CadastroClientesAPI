using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Clientes.CadastrarCliente
{
    public class CadastrarClienteRequest : IRequest<CadastrarClienteResponse>
    {
        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public IFormFile? Logotipo { get; set; }
    }
}
