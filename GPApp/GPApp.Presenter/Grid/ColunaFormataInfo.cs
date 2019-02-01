using System;

namespace GPApp.Presenter.Grid
{
    public class ColunaFormataInfo
    {
        public string NomePropriedade { get; set; }
        public Object Valor { get; set; }
        public string CoreFundo { get; set; }
        public string CorTexto { get; set; }
        public string CorFundoSelecao { get; set; }
        public string CorTextoSelecao { get; set; }
        public int IndexRow { get; set; }
    }

    public class ColunaFormataInfo<T> : ColunaFormataInfo
    {
        public ColunaFormataInfo(ColunaFormataInfo info)
        {
            NomePropriedade = info.NomePropriedade;
            Valor = info.Valor;
            CoreFundo = info.CoreFundo;
            CorTexto = info.CorTexto;
            CorFundoSelecao = info.CorFundoSelecao;
            CorTextoSelecao = info.CorTextoSelecao;
            IndexRow = info.IndexRow;
        }

        public T Model { get; set; }
    }
}
