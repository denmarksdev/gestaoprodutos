using GPApp.Uwp.Logica.ViewModels;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Prism.Windows.Mvvm;
using System.Linq;

namespace GPApp.Uwp.Views
{
    public sealed partial class ProdutoEditPage : SessionStateAwarePage
    {

        #region Menbros privados

        private readonly Expander[] _expanders;

        #endregion

        #region Propriedades

        public ProdutoEditPageViewModel ViewModel { get; private set; }

        #endregion

        #region Contrutor

        public ProdutoEditPage()
        {
            InitializeComponent();

            ViewModel = DataContext as ProdutoEditPageViewModel;

            _expanders = new[]
            {
                ExpanderPrincipal,
                ExpanderImagens,
                ExpanderEspecificacoes
            };
            ExpanderPrincipal.Expanded += ExpanderExpanded;
            ExpanderImagens.Expanded += ExpanderExpanded;
            ExpanderEspecificacoes.Expanded += ExpanderExpanded;
        }

        #endregion

        #region Handlers

        private void ExpanderExpanded(object sender, System.EventArgs e)
        {
            var expander = sender as Expander;

            var expandersContrair = _expanders.Where(ex => ex.Name != expander.Name);
            foreach (var expand in expandersContrair)
            {
                expand.IsExpanded = false;
            }
        }

        #endregion
    }
}
