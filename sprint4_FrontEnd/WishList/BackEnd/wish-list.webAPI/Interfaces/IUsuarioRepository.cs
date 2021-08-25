using System.Collections.Generic;
using wish_list.webAPI.Domains;

namespace wish_list.webAPI.Interfaces
{
    interface IUsuarioRepository
    {

        List<Usuario> ListarUsuarios();


        Usuario BuscarUsuarioPorId(int id);


        void CadastrarUsuario(Usuario novoUsuario);


        void AtualizarUsuario(int id, Usuario usuarioAtualizado);


        void DeletarUsuario(int id);
    }
}