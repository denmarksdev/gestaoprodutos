using System;
using GPApp.Shared.Services;
using GPApp.Wpf.Dialog;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;

namespace GPApp.Wpf.Services
{
    public class DialogService: IDialogService
    {

        public void BuscaCamimhoImagem(Action<string> okAction)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            };
            openFileDialog.Title = "Buscar imagem";
            var resultado = openFileDialog.ShowDialog();

            if (resultado.HasValue && resultado.Value)
                okAction?.Invoke(openFileDialog.FileName);
        }

        public void BuscaCamimhoImagem(Action<string, byte[]> okAction)
        {
            throw new NotImplementedException();
        }

        public async void Confirmacao(string mensagem, Action okAction, string titulo = "Atenção")
        {
            var viewModel = new DialogViewModel();
            var view = new DialogView
            {
                DataContext = viewModel
            };

            viewModel.Inicia(titulo, mensagem);

            var result = (bool) await DialogHost.Show(view);
            if (result)
                okAction?.Invoke();
        }

        public void Mensagem(string mensagem, Action okAction = null, string titulo = "Aviso")
        {
        }
    }
}
