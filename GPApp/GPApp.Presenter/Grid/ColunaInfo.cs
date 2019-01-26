using System;

namespace GPApp.Presenter.Grid
{
    public class ColunaInfo
    {
        public string NomePropriedade { get; set; }
        public string Titulo { get; set; }
        public int Tamanho { get; set; }
        public Type Type { get; set; }
        public TipoAlinhamentoColuna TipoAlinhamento { get; set; }
        public ColunaTipoAjuste TipoAjuste { get; set; }
    }
}
