using System;

namespace GPApp.Presenter.Grid
{
    public class ColunaInfo
    {
        public const string COLUNA_ALTERACAO = "colAlt";

        public bool ChavePrimaria { get; set; }
        public string NomePropriedade { get; set; }
        public string Titulo { get; set; }
        public int Tamanho { get; set; }
        public Type Type { get; set; }
        public TipoAlinhamentoColuna TipoAlinhamento { get; set; }
        public ColunaTipoAjuste TipoAjuste { get; set; }
        public bool PermitirOrdenar { get; set; }
        public bool Exibir { get; set; } = true;

        public static ColunaInfo BuildColunaAlteracao(string titulo = "")
        {
            return new ColunaInfo
            {
                NomePropriedade = COLUNA_ALTERACAO,
                Titulo = titulo,
                TipoAlinhamento = TipoAlinhamentoColuna.Centro,
                Tamanho = 50,
                TipoAjuste = ColunaTipoAjuste.Nenhum,
                Exibir = true,
                PermitirOrdenar = false
            };
        }
    }
}