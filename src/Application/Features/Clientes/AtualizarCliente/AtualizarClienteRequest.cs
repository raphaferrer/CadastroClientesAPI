using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.AtualizarCliente
{
    public class AtualizarClienteRequest : IRequest<bool>
    {
        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public IFormFile? Logotipo { get; set; }
    }
}
