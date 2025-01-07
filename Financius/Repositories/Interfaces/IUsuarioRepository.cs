using Financius.Models;

namespace Financius.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> BuscaUsuariosAsync();
        Task<Usuario> BuscaUsuarioPorIdAsync(int id);
        Task<int> CriaUsuarioAsync(Usuario usuario);
        Task<int> AtualizaUsuarioAsync(Usuario usuario);
        Task<int> DeleteUsuarioAsync(int id);
    }
}
