using System;

namespace GPApp.Shared.Services
{
    public interface IDialogService
    {
        void BuscaCamimhoImagem(Action<string> okAction);

        void BuscaCamimhoImagem(Action<string,byte[]> okAction);

           void Confirmacao(string mensagem, Action okAction,string titulo = "Atenção");
        void Mensagem(string mensagem, Action okAction = null, string titulo = "Aviso");
    }
}
