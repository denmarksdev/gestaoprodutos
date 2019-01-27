using GPApp.Shared.Paginacao;
using System.Collections.Generic;

namespace GPApp.Presenter.Grid
{
    public class GridConfig<T>
    {
        public Cache<T> Cache { get; }
        public IDataPageRetriever<T> DataRetriever { get; }
        public IList<ColunaInfo> ColumnsInfo { get; }
        public bool ModoLeitura { get; set; } = true;
        public string ColunaChave { get; set; }


        public GridConfig(
            IPaginacaoRepository<T> paginacaoRepository,
            IList<ColunaInfo> colunasInfo,
            int numeroLinhaPorPagina = 30)
        {
            DataRetriever = new DataRetriever<T>(paginacaoRepository);
            Cache = new Cache<T>(DataRetriever, numeroLinhaPorPagina);
            ColumnsInfo = colunasInfo;
        }
    }
}