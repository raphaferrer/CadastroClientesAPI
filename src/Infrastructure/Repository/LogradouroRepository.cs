using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Data;

namespace Infrastructure.Repository
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private readonly IDbConnection _db;

        public LogradouroRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<Guid> CriarAsync(Logradouro logradouro)
        {
            const string sql = "EXEC sp_CriarLogradouro @ClienteEmail, @Endereco, @Id OUTPUT";
            var parametros = new DynamicParameters();
            parametros.Add("@ClienteEmail", logradouro.ClienteEmail);
            parametros.Add("@Endereco", logradouro.Endereco);
            parametros.Add("@Id", dbType: DbType.Guid, direction: ParameterDirection.Output);

            await _db.ExecuteAsync(sql, parametros);
            return parametros.Get<Guid>("@Id");
        }

        public async Task<List<Logradouro>> ObterPorClienteIdAsync(string clienteEmail)
        {
            const string sql = "SELECT Id, ClienteEmail, Endereco FROM Logradouros WHERE ClienteEmail = @ClienteEmail";
            return (await _db.QueryAsync<Logradouro>(sql, new { ClienteEmail = clienteEmail })).AsList();
        }

        public async Task AtualizarAsync(Guid id, string endereco)
        {
            const string sql = "EXEC sp_AtualizarLogradouro @Id, @Endereco";
            await _db.ExecuteAsync(sql, new { Id = id, Endereco = endereco });
        }

        public async Task RemoverAsync(Guid id)
        {
            const string sql = "EXEC sp_RemoverLogradouro @Id";
            await _db.ExecuteAsync(sql, new { Id = id });
        }
    }
}
