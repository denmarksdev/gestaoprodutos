using System.Linq;
using System.Windows.Controls;

namespace GPApp.Wpf.Modulo.Produtos.Views
{
    /// <summary>
    /// Interaction logic for ProdutoEdit
    /// </summary>
    public partial class ProdutoEdit : UserControl
    {
        private Expander[] _expanders;

        public ProdutoEdit()
        {
            InitializeComponent();

            ExpanderPrincipal.Expanded += ExpanderExpanded;
            ExpanderImagens.Expanded += ExpanderExpanded;
            ExpanderEspecificacoes.Expanded += ExpanderExpanded;

            _expanders = new[]
            {
                ExpanderPrincipal,
                ExpanderImagens,
                ExpanderEspecificacoes
            };
        }

        private void ExpanderExpanded(object sender, System.Windows.RoutedEventArgs e)
        {
            var expander = sender as Expander;
            var expandersCollapse = _expanders.Where(ex => ex.Name != expander.Name);
            foreach (var expand in expandersCollapse)
            {
                expand.IsExpanded = false;
            }
        }
    }
}
