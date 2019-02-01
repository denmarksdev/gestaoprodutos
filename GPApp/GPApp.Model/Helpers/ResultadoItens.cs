using System;
using System.Collections.Generic;

namespace GPApp.Model.Helpers
{
    public class ResultadoItens<T>
    {
        public DateTimeOffset DataAtualizacao { get; private set; } = DateTime.UtcNow;
        public List<T> ItensInvalidos { get; private set; } =  new List<T>();
        public List<string> Mensagens { get; private set; } = new List<string>();
        public bool Valido { get; private set; }

        public ResultadoItens()
        {
            Valido = true;
        }

        public ResultadoItens(params string[] mensagem)
        {
            Valido = false;
            Mensagens.AddRange(mensagem);
        }
        public void AdicionaItensIvalidos(params T[] itens)
        {
            Valido = false;
            ItensInvalidos.AddRange(itens);
        }

        public string GetMensagem()
        {
            return String.Join("\n", Mensagens);
        }
    }
}