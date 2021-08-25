using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int id, TiposUsuario tipoAtualizado)
        {
            // Busca um tipo de usuário pelo id
            TiposUsuario tipoBuscado = ctx.TiposUsuarios.Find(id);

            // Verifica se o tipo de usuário foi informado
            if (tipoAtualizado.Tipo != null)
            {
                // Atribui os novos valores aos campos existentes
                tipoBuscado.Tipo = tipoAtualizado.Tipo;
            }

            // Atualiza o personagem que foi buscado
            ctx.TiposUsuarios.Update(tipoBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            // Retorna o primeiro tipo de usuário encontrado para o ID informado
            return ctx.TiposUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        public void Cadastrar(TiposUsuario novoTipo)
        {
            // Adiciona este novoTipo
            ctx.TiposUsuarios.Add(novoTipo);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um personagem através do seu Id
            TiposUsuario tipoBuscado = ctx.TiposUsuarios.Find(id);

            // Remove o personagem que foi buscado
            ctx.TiposUsuarios.Remove(tipoBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuarios.ToList();
        }
    }
}
