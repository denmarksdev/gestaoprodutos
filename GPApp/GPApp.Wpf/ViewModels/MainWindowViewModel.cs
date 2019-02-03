using Prism.Mvvm;

namespace GPApp.Wpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Gestão de produtos";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
