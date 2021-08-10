using System.Collections.Generic;

namespace Cadastro_Serie.Interfaces
{
    public interface IRepositorio<T> // onde T é um tipo generico
    {
        List<T> Lista();
        T RetornaPorId(int id); 
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}