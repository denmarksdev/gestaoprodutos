using GPApp.Uwp.Logica.ViewModels;
using Prism.Windows.Mvvm;

namespace GPApp.Uwp.Views
{
    public sealed partial class ProdutosPage : SessionStateAwarePage
    {
        public ProdutosPage()
        {
            this.InitializeComponent();

            ViewModel = DataContext as ProdutosPageViewModel;
        }

        public  ProdutosPageViewModel ViewModel { get; }
    }
}
