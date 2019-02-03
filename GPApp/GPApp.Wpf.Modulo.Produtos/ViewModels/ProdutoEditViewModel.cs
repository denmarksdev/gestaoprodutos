using GPApp.Shared.Constantes;
using GPApp.Wrapper;
using Prism.Mvvm;
using Prism.Regions;

namespace GPApp.Wpf.Modulo.Produtos.ViewModels
{
    public class ProdutoEditViewModel : BindableBase , INavigationAware
    {
        public ProdutoEditViewModel()
        {
        }

        #region Propriedades


        public ProdutoWrapper Wrapper { get; set; }

        private string _operacao;
        public string Operacao
        {
            get { return _operacao; }
            set { SetProperty(ref _operacao, value); }
        }

        #endregion


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
           return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey(ContantesGlobais.OPERACAO_ALTERACAO))
            {
                Operacao = "Alerar produto";
            }
            else
            {
                Operacao = "Novo produto";
            }
        }
    }
}
