using Dapper;
using Financius.Data;
using Financius.Models;
using Financius.Repositories.Interfaces;
using System.Data;

namespace Financius.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbContext _dbContext;

        public UsuarioRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Usuario>> BuscaUsuariosAsync()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var resultado = await connection.QueryAsync<Usuario>(
                    "dbo.sp_GetUsuarios",
                    CommandType.StoredProcedure);

                return resultado;
            }
        }

        public async Task<Usuario> BuscaUsuarioPorIdAsync(int id)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var resultado = await connection.QuerySingleOrDefaultAsync<Usuario>(
                    "dbo.sp_BuscaUsuarioPorId",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return resultado;
            }
        }

        public async Task<int> CriaUsuarioAsync(Usuario usuario)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Nome", usuario.Nome);
                parameters.Add("@Email", usuario.Email);
                parameters.Add("@SenhaHash", usuario.SenhaHash);

                var resultado = await connection.ExecuteAsync(
                    "dbo.sp_CriaUsuario",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return resultado;
            }
        }

        public async Task<int> AtualizaUsuarioAsync(Usuario usuario)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdUsuario", usuario.IdUsuario);
                parameters.Add("@Nome", usuario.Nome);
                parameters.Add("@Email", usuario.Email);
                parameters.Add("@SenhaHash", usuario.SenhaHash);

                var resultado = await connection.ExecuteAsync(
                    "dbo.sp_AtualizaUsuario",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return resultado;
            }
        }

        public async Task<int> DeleteUsuarioAsync(int id)
        {
            using (var connection = _dbContext.CreateConnection())
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
