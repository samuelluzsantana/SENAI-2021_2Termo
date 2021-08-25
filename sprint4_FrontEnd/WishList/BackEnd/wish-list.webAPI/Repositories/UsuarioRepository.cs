using System.Collections.Generic;
using System.Linq;
using wish_list.webAPI.Contexts;
using wish_list.webAPI.Domains;
using wish_list.webAPI.Interfaces;

namespace wish_list.webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        WishListContext ctx = new WishListContext();


        public void AtualizarUsuario(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            if (usuarioAtualizado.NomeUsuario != null)
            {
                usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
            }

            if (usuarioAtualizado.Email != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }


        public Usuario BuscarUsuarioPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(te => te.IdUsuario == id);
        }


        public void CadastrarUsuario(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }


        public void DeletarUsuario(int id)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }


        public List<Usuario> ListarUsuarios()
        {
            return ctx.Usuarios.ToList();
        }


    }
}
