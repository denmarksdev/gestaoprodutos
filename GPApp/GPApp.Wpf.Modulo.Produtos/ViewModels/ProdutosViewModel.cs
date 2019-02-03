using System;
using GPApp.Shared.Constantes;
using GPApp.Wrapper;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace GPApp.Wpf.Modulo.Produtos.ViewModels
{
    public class ProdutosViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public ProdutosViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            IncluirCommand = new DelegateCommand(OnIncluir);

            var wrapper = new ProdutoWrapper(new Model.Produto
            {
                EstoqueAtual = new Model.ProdutoEstoque()
            });
        }

        #region Propriedades

        public DelegateCommand IncluirCommand { get; set; }

        #endregion

        #region Ações

        private void OnIncluir()
        {
            _regionManager.RequestNavigate(RegionNames.MAIN_REGION, RegionNames.EDIT_PRODUTO);
        }

        #endregion

    }
}
