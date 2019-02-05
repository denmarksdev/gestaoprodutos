using Prism.Mvvm;
using System.Windows;

namespace GPApp.Wpf.Dialog
{
    public class DialogViewModel: BindableBase
    {
        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set { SetProperty(ref _titulo, value); }
        }

        private string _mensagem;
        public string Mensagem
        {
            get { return _mensagem; }
            set { SetProperty(ref _mensagem, value); }
        }

        private Visibility _exibeBotaoCancelar;
        public Visibility ExibeBotaoCancelar
        {
            get { return _exibeBotaoCancelar; }
            set { SetProperty(ref _exibeBotaoCancelar, value); }
        }

        private string _textoBotaoConfirmar;
        public string TextoBotaoConfirmar
        {
            get { return _textoBotaoConfirmar; }
            set { SetProperty(ref _textoBotaoConfirmar, value); }
        }

        public void Inicia(string titulo, string mensagem, bool modoConfirmacao = true)
        {
            Titulo = titulo;
            Mensagem = mensagem;
            if (modoConfirmacao)
            {
                ExibeBotaoCancelar = Visibility.Visible;
            }
            else
            {
                ExibeBotaoCancelar = Visibility.Hidden;
                TextoBotaoConfirmar = "OK";
            }
        }
    }
}
