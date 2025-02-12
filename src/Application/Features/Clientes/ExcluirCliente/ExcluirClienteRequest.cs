using MediatR;
using System;

namespace Application.Features.ExcluirCliente
{
    public class ExcluirClienteRequest : IRequest<bool>
    {
        public string Email { get; set; }

        public ExcluirClienteRequest(string email)
        {
            Email = email;
        }
    }
}
