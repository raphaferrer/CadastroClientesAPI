using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILogradouroRepository
    {
        Task<Guid> CriarAsync(Logradouro logradouro);

        Task<List<Logradouro>> ObterPorClienteIdAsync(string clienteEmail);

        Task AtualizarAsync(Guid id, string endereco);

        Task RemoverAsync(Guid id);
    }
}
