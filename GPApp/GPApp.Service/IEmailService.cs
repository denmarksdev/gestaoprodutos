using GPApp.Model;
using GPApp.Model.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPApp.Service
{
    public interface IEmailService
    {
        Task<Resultado> Envia(List<Cliente> clientes, string assunto, string from, string propaganda, string mensagem);
    }
}