using Domain.Interfaces;
using MediatR;

namespace Application.Features.Logradouros.ListarLogradouros
{
    public class ListarLogradourosHandler : IRequestHandler<ListarLogradourosRequest, List<ListarLogradourosResponse>>
    {
        private readonly ILogradouroRepository _logradouroRepository;

        public ListarLogradourosHandler(ILogradouroRepository logradouroRepository)
        {
            _logradouroRepository = logradouroRepository;
        }

        public async Task<List<ListarLogradourosResponse>> Handle(ListarLogradourosRequest request, CancellationToken cancellationToken)
        {
            var logradouros = await _logradouroRepository.ObterPorClienteIdAsync(request.ClienteEmail);

            return logradouros.Select(l => new ListarLogradourosResponse(l.ClienteEmail, l.Endereco)).ToList();
        }
    }
}
