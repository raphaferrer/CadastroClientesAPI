using Domain.Interfaces;
using MediatR;

namespace Application.Features.Logradouros.AtualizarLogradouro
{
    public class AtualizarLogradouroHandler : IRequestHandler<AtualizarLogradouroRequest, bool>
    {
        private readonly ILogradouroRepository _logradouroRepository;

        public AtualizarLogradouroHandler(ILogradouroRepository logradouroRepository)
        {
            _logradouroRepository = logradouroRepository;
        }

        public async Task<bool> Handle(AtualizarLogradouroRequest request, CancellationToken cancellationToken)
        {
            await _logradouroRepository.AtualizarAsync(request.Id, request.Endereco);

            return true;
        }
    }
}
