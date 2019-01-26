using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEficaz.Infraestrutura.Paginacao
{
    public interface IPaginacaoRepository<T>
    {
        string Pesquisa { get; set; }
        string Order { get; set; }
        int Count { get; }

        IEnumerable<T> GetItens(int limit, int offset);
        IEnumerable<T> GetItens(Object[] ids);
        IEnumerable<T> GetItens();
        int GetPosicaoLinha(Object id);
    }
}
