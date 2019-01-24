using System;

namespace GPApp.Model.Helpers
{
    public class Resultado
    {
        public string Mensagem { get; }
        public bool Valido { get; }
        public Exception Exception { get; }

        public Resultado(): this("Sem mensagem", true)
        {
        }

        public Resultado(string mensagem)
          : this(mensagem, (Exception)null, true)
        {
        }

        public Resultado(string mensagem, bool valido)
          : this(mensagem, (Exception)null, valido)
        {
        }

        public Resultado(string mensagem, Exception exception, bool valido = false)
        {
            this.Mensagem = mensagem;
            this.Valido = valido;
            this.Exception = exception;
        }
    }

    public class Resultado<T> : Resultado
    {
        public T Valor { get; }

        public Resultado()
          : base(string.Empty)
        {
        }

        public Resultado(T valor)
        {
            this.Valor = valor;
        }

        public Resultado(string mensagem, Exception exception = null)
          : this(mensagem, false, exception)
        {
        }

        public Resultado(string mensagem, T valor)
          : this(mensagem, true, (Exception)null)
        {
            this.Valor = valor;
        }

        public Resultado(string mensagem, bool valido)
          : this(mensagem, valido, (Exception)null)
        {
        }

        public Resultado(string mensagem, bool valido, Exception exception)
          : base(mensagem, exception, valido)
        {
        }
    }
}
