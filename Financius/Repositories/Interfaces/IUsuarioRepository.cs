using Financius.Models;

namespace Financius.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioModel>> BuscaUsuariosAsync();
        Task<UsuarioModel> BuscaUsuarioPorIdAsync(int id);
        Task<int> CriaUsuarioAsync(UsuarioModel usuario);
        Task<int> AtualizaUsuarioAsync(UsuarioModel usuario);
        Task<int> DeleteUsuarioAsync(int id);
    }
}
