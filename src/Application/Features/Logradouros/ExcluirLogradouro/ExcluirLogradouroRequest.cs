using MediatR;
using System;

namespace Application.Features.Logradouros.ExcluirLogradouro
{
    public class ExcluirLogradouroRequest : IRequest<bool>
    {
        public Guid Id { get; set; }

        public ExcluirLogradouroRequest(Guid id)
        {
            Id = id;
        }
    }
}
