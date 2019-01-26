using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace GestaoEficaz.Infraestrutura.Paginacao
{
   public interface  IDataPageRetriever <T>
    {
        string Order { get; set; }
        string WhereFiltro { get; set; }
        string Pesquisa { get; set; }
        int NumeroRegistros { get;}
        int GetPosicaoLinha(object  id );
        List<T> SupplyPageOfData(int offset, int limit);
        List<Object> RegistrosMarcados { get; }

        IList<T> GetItens();
        IList<M> Getids<M>();

        Task<IList<T>> GetItensAsync();
    }

    public enum ETipoOrdenacao
    {
       [Description("ASC")] Ascendente,
       [Description("DESC")] Decendente
    }

}
