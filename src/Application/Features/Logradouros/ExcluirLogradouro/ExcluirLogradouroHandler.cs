using Domain.Interfaces;
using MediatR;

namespace Application.Features.Logradouros.ExcluirLogradouro
{
    public class ExcluirLogradouroHandler : IRequestHandler<ExcluirLogradouroRequest, bool>
    {
        private readonly ILogradouroRepository _logradouroRepository;

        public ExcluirLogradouroHandler(ILogradouroRepository logradouroRepository)
        {
            _logradouroRepository = logradouroRepository;
        }

        public async Task<bool> Handle(ExcluirLogradouroRequest request, CancellationToken cancellationToken)
        {
            await _logradouroRepository.RemoverAsync(request.Id);

            return true;
        }
    }
}
