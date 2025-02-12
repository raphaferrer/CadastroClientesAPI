using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Logradouros.CadastrarLogradouro
{
    public class CadastrarLogradouroHandler : IRequestHandler<CadastrarLogradouroRequest, CadastrarLogradouroResponse>
    {
        private readonly ILogradouroRepository _logradouroRepository;

        public CadastrarLogradouroHandler(ILogradouroRepository logradouroRepository)
        {
            _logradouroRepository = logradouroRepository;
        }

        public async Task<CadastrarLogradouroResponse> Handle(CadastrarLogradouroRequest request, CancellationToken cancellationToken)
        {
            var logradouro = new Logradouro
            {
                ClienteEmail = request.ClienteEmail,
                Endereco = request.Endereco
            };

            var logradouroId = await _logradouroRepository.CriarAsync(logradouro);

            return new CadastrarLogradouroResponse(logradouroId, logradouro.ClienteEmail, logradouro.Endereco);
        }
    }
}