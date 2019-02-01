using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPApp.Presenter.Grid
{
    public interface IGridView
    {
        string ColunaChave { get; set; }
        bool ErroPaginacao { get; set; }

        Func<int, string, object> GetValue { get; set; }
        Action<string> OrderAction { get; set; }
        Action ConsultaAction { get; set; }
        Action ErroPagincaoAction { get; set; }
        Action<object> AlterarAction { get; set; }

        Func<ColunaFormataInfo, ColunaFormataInfo> FormataCelulaFunc { get; set; }

        void SetNumeroRegistros(int numero);
        void SetColunas(IList<ColunaInfo> colunas);
        void AtualizarDesign();
        void DefineColunaModoLeitura(bool permitir);
        void SetCores();

        T GetValorChaveDataRowAtual<T>(string nomePropriedade = null);

        Func<Task<bool>> Inicializa { get; set; }
    }
}