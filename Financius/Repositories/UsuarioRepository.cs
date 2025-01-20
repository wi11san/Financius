using Dapper;
using Financius.Models;
using Financius.Repositories.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Financius.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuration;

        public UsuarioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<UsuarioModel>> BuscaUsuariosAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("FinanciusDB"));
            {
                var resultado = await connection.QueryAsync<UsuarioModel>(
                    "dbo.sp_BuscaUsuarios",
                    commandType: CommandType.StoredProcedure);

                return resultado;
            }
        }

        public async Task<UsuarioModel> BuscaUsuarioPorIdAsync(int id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("FinanciusDB"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var resultado = await connection.QuerySingleOrDefaultAsync<UsuarioModel>(
                    "dbo.sp_BuscaUsuarioPorId",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return resultado;
            }
        }

        public async Task<int> CriaUsuarioAsync(UsuarioModel usuario)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("FinanciusDB"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Nome", usuario.Nome);
                parameters.Add("@Email", usuario.Email);
                parameters.Add("@Senha", usuario.Senha);

                var resultado = await connection.ExecuteAsync(
                    "dbo.sp_CriaUsuario",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return resultado;
            }
        }

        public async Task<int> AtualizaUsuarioAsync(UsuarioModel usuario)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("FinanciusDB"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdUsuario", usuario.IdUsuario);
                parameters.Add("@Nome", usuario.Nome);
                parameters.Add("@Email", usuario.Email);
                parameters.Add("@Senha", usuario.Senha);

                var resultado = await connection.ExecuteAsync(
                    "dbo.sp_AtualizaUsuario",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return resultado;
            }
        }

        public async Task<int> DeleteUsuarioAsync(int id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("FinanciusDB"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var resultado = await connection.ExecuteAsync(
                    "dbo.sp_DeleteUsuario",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return resultado;
            }
        }
    }
}
