using System.Collections.Generic;
using System.Linq;

namespace GPApp.Shared.Paginacao
{
    public class Cache<T>
    {
        #region Membros privados

        private static int RegistrosPorPagina;
        private IList<DataPage> _cachePages;
        private readonly IDataPageRetriever<T> _dataSupply;

        #endregion

        #region Construtor

        public Cache(IDataPageRetriever<T> dataSupplier, int rowsPerPage)
        {
            _dataSupply = dataSupplier;
            Cache<T>.RegistrosPorPagina = rowsPerPage;
        }

        #endregion

        #region Métodos

        public void CarregarDuasPaginas()
        {
          _cachePages?.Clear();
          _cachePages = new List<DataPage>
          {
             new DataPage(_dataSupply.SupplyPageOfData(DataPage.MapearLimiteInferior(0), RegistrosPorPagina), 0),
             new DataPage(_dataSupply.SupplyPageOfData(DataPage.MapearLimiteInferior(RegistrosPorPagina), RegistrosPorPagina ), RegistrosPorPagina)
          };
        } 

        public void LimparCache()
        {
            _cachePages.Clear();
        }

        private bool PaginaEmCacheSetValorItem(int rowIndex, string nomePropriedade, ref object elemento)
        {

            foreach (var cache in _cachePages)
            {
                if (ItemPertenceAoCachePagina(_cachePages.IndexOf(cache), rowIndex))
                {
                    if (cache.Itens.Count() == 0) return true;

                    elemento = GetValue(cache.Itens[rowIndex % RegistrosPorPagina], nomePropriedade);
                    return true;
                }
            }

            return false;
        }

        private bool PaginaEmCacheSetItem(int rowIndex, ref T elemento)
        {
            foreach (var cache in _cachePages)
            {
                if (ItemPertenceAoCachePagina(_cachePages.IndexOf(cache), rowIndex))
                {
                    if (cache.Itens.Count() == 0) return true;

                    elemento = cache.Itens[rowIndex % RegistrosPorPagina];
                    return true;
                }
            }

            return false;
        }

        public object RecuperarValorDoItem(int rowIndex, string nomepropriedade)
        {
            object elemento = null;

            if (PaginaEmCacheSetValorItem(rowIndex, nomepropriedade, ref elemento))
            {
                return elemento;
            }
            else
            {
                return RecuperarCacheRetornarValorDoItem(
                    rowIndex, nomepropriedade);
            }
        }

        public T RecuperarItem(int rowIndex)
        {
            T elemento = default(T);

            if (PaginaEmCacheSetItem(rowIndex, ref elemento))
            {
                return elemento;
            }
            else
            {
                return RecuperarCacheRetornarItem(rowIndex);
            }
        }

        private object RecuperarCacheRetornarValorDoItem(int rowIndex, string nomePropriedade)
        {
            var itens = _dataSupply.SupplyPageOfData(
                DataPage.MapearLimiteInferior(rowIndex), RegistrosPorPagina);

            _cachePages[GetIndicePaginaNaoUtilizada(rowIndex)] = new DataPage(itens, rowIndex);

            return RecuperarValorDoItem(rowIndex, nomePropriedade);
        }

        private T RecuperarCacheRetornarItem(int rowIndex)
        {
            var itens = _dataSupply.SupplyPageOfData(
                DataPage.MapearLimiteInferior(rowIndex), RegistrosPorPagina);

            _cachePages[GetIndicePaginaNaoUtilizada(rowIndex)] = new DataPage(itens, rowIndex);

            return RecuperarItem(rowIndex);
        }

        private int GetIndicePaginaNaoUtilizada(int rowIndex)
        {
            if (rowIndex > _cachePages[0].MaiorIndice &&
                rowIndex > _cachePages[1].MaiorIndice)
            {
                int offsetFromPage0 = rowIndex - _cachePages[0].MaiorIndice;
                int offsetFromPage1 = rowIndex - _cachePages[1].MaiorIndice;
                if (offsetFromPage0 < offsetFromPage1)
                {
                    return 1;
                }
                return 0;
            }
            else
            {
                int offsetFromPage0 = _cachePages[0].MenorIndice - rowIndex;
                int offsetFromPage1 = _cachePages[1].MenorIndice - rowIndex;
                if (offsetFromPage0 < offsetFromPage1)
                {
                    return 1;
                }
                return 0;
            }

        }

        private bool ItemPertenceAoCachePagina(int pageNumber, int rowIndex)
        {
            return rowIndex <= _cachePages[pageNumber].MaiorIndice &&
                rowIndex >= _cachePages[pageNumber].MenorIndice;
        }

        private object GetValue(T item, string nomePropriedade)
        {
            var propertyInfo = item.GetType().GetProperty(nomePropriedade);
            return propertyInfo.GetValue(item, null);
        }

        #endregion

        #region Auxiliares

        public struct DataPage
        {
            public List<T> Itens { get; set; }
            private readonly int _menorIndice;
            private readonly int _maiorIndicehighestIndexValue;

            public DataPage(List<T> itens, int rowIndex)
            {
                Itens = itens;
                _menorIndice = MapearLimiteInferior(rowIndex);
                _maiorIndicehighestIndexValue = MapearLimiteSuperior(rowIndex);
            }

            public int MenorIndice
            {
                get
                {
                    return _menorIndice;
                }
            }

            public int MaiorIndice
            {
                get
                {
                    return _maiorIndicehighestIndexValue;
                }
            }

            public static int MapearLimiteInferior(int rowIndex)
            {
                return (rowIndex / RegistrosPorPagina) * RegistrosPorPagina;
            }

            private static int MapearLimiteSuperior(int rowIndex)
            {
                return MapearLimiteInferior(rowIndex) + RegistrosPorPagina - 1;
            }
        }

        #endregion
    }
}