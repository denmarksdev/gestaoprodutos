using GPApp.Wpf.Modulo.Produtos.ViewModels;
using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace GPApp.Wpf.Modulo.Produtos.Views
{
    /// <summary>
    /// Interaction logic for Produtos
    /// </summary>
    public partial class Produtos : UserControl
    {
        public Produtos()
        {
            InitializeComponent();

            var viewModel = DataContext as ProdutosViewModel;
            viewModel.AtualizarGrid = OnAtualizarGrid;

        }

        private void OnAtualizarGrid()
        {
            CollectionViewSource.GetDefaultView(DataGridProdutos.ItemsSource).Refresh();
        }
    }
}
