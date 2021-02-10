using el.localiza.reservas.mvc.netcore.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace el.localiza.reservas.mvc.netcore.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<IList<UsuarioModel>> ObterTodosUsuariosPorPerfil(int perfil);
        Task<UsuarioModel> CriarNovoUsuario(UsuarioModel model);
        Task<UsuarioModel> AtualizarUsuario(UsuarioModel model);
        Task<string> AtualizarUsuario(string id);        
    }
}
