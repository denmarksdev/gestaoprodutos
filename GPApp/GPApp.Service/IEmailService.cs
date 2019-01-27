using GPApp.Model.Helpers;
using System.Threading.Tasks;

namespace GPApp.Service
{
    public interface IEmailService
    {
        Task<Resultado> Envia(string mensagem);
    }
}