using System.Collections.Generic;
using wish_list.webAPI.Domains;

namespace wish_list.webAPI.Interfaces
{
    interface IDesejoRepository
    {
        
        List<Desejo> ListarDesejos();

        
        Desejo BuscarDesejoPorId(int id);

        
        void CadastrarDesejo(Desejo novoDesejo);

        
        void AtualizarDesejo(int id, Desejo desejoAtualizado);

        
        void DeletarDesejo(int id);
    }
}
