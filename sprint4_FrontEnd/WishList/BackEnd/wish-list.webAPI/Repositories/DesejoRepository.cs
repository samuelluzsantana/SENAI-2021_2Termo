using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wish_list.webAPI.Contexts;
using wish_list.webAPI.Domains;
using wish_list.webAPI.Interfaces;

namespace wish_list.webAPI.Repositories
{
    public class DesejoRepository : IDesejoRepository
    {
            
            WishListContext ctx = new WishListContext();

            
            public void AtualizarDesejo(int id, Desejo desejoAtualizado)
            {
                Desejo desejoBuscado = ctx.Desejos.Find(id);

                if (desejoAtualizado.Descricao != null)
                {
                   desejoBuscado.Descricao = desejoAtualizado.Descricao;
                }

                
                ctx.Desejos.Update(desejoBuscado);

                ctx.SaveChanges();
            }

            
        public Desejo BuscarDesejoPorId(int id)
            {
                return ctx.Desejos.FirstOrDefault(te => te.IdDesejo == id);
            }

            
            public void CadastrarDesejo(Desejo novoDesejo)
            {
                ctx.Desejos.Add(novoDesejo);

                ctx.SaveChanges();
            }

            
            public void DeletarDesejo(int id)
            {
                Desejo desejoBuscado = ctx.Desejos.Find(id);

                ctx.Desejos.Remove(desejoBuscado);

                ctx.SaveChanges();
            }

            
            public List<Desejo> ListarDesejos()
            {
                return ctx.Desejos.ToList();
            }

            
        }
}
