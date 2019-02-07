using System;
using System.Windows.Forms;
using GPApp.Shared.Services;
using GPApp.WinForms.Componentes;

namespace GPApp.WinForms.Services
{
    class DialogService : IDialogService
    {
        public void BuscaCamimhoImagem(Action<string> okAction)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            };
            openFileDialog.Title = "Buscar imagem";
            var resultado = openFileDialog.ShowDialog();
            if (resultado == DialogResult.OK)
                okAction?.Invoke(openFileDialog.FileName);
        }

        public void BuscaCamimhoImagem(Action<string, byte[]> okAction)
        {
            throw new NotImplementedException();
        }

        public void Confirmacao(string mensagem, Action okAction, string titulo = "Atenção")
        {
            var dialogWindow = new DialogView(titulo, mensagem);
            var result = dialogWindow.ShowDialog(Application.OpenForms[0]);
            if (result == DialogResult.OK)
                okAction?.Invoke();
        }

        public void Mensagem(string mensagem, Action okAction = null, string titulo = "Aviso")
        {
            var dialogWindow = new DialogView(titulo, mensagem);
            var result = dialogWindow.ShowDialog(Application.OpenForms[0]);
            if (result == DialogResult.OK)
                okAction?.Invoke();
        }
    }
}
