using System.Data;
using Dapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnection _db;

        public ClienteRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<Cliente?> ObterPorEmailAsync(string email)
        {
            const string sql = "SELECT * FROM Clientes WHERE Email = @Email";
            return await _db.QueryFirstOrDefaultAsync<Cliente>(sql, new { Email = email });
        }

        public async Task<List<Cliente>> ObterTodosAsync()
        {
            const string sql = "SELECT * FROM Clientes"; 
            return (await _db.QueryAsync<Cliente>(sql)).AsList();
        }

        public async Task<Guid> CriarAsync(Cliente cliente)
        {
            const string sql = "EXEC sp_CriarCliente @Id, @Nome, @Email, @Logotipo";
            var parametros = new DynamicParameters();
            parametros.Add("@Id", cliente.Id);
            parametros.Add("@Nome", cliente.Nome);
            parametros.Add("@Email", cliente.Email);
            parametros.Add("@Logotipo", cliente.Logotipo, DbType.Binary);

            await _db.ExecuteAsync(sql, parametros);
            return cliente.Id;
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            const string sql = "EXEC sp_AtualizarCliente @Nome, @Email, @Logotipo";
            await _db.ExecuteAsync(sql, cliente);
        }

        public async Task RemoverAsync(string email)
        {
            const string sql = "EXEC sp_RemoverCliente @Email";
            await _db.ExecuteAsync(sql, new { Email = email });
        }
    }
}
