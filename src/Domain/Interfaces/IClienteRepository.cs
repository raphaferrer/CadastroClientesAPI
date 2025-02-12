using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente?> ObterPorEmailAsync(string email);

        Task<List<Cliente>> ObterTodosAsync(); 

        Task<Guid> CriarAsync(Cliente cliente);

        Task AtualizarAsync(Cliente cliente);

        Task RemoverAsync(string email);
    }
}
