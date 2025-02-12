using MediatR;

namespace Application.Features.Logradouros.AtualizarLogradouro
{
    public class AtualizarLogradouroRequest : IRequest<bool>
    {
        public Guid Id { get; set; }

        public string Endereco { get; set; }

        public AtualizarLogradouroRequest(Guid id, string endereco)
        {
            Id = id;

            Endereco = endereco;
        }
    }
}
