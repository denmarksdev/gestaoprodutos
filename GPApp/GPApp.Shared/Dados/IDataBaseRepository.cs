using GPApp.Model.Database;
using GPApp.Model.Helpers;
using System.Threading.Tasks;

namespace GPApp.Shared.Dados
{
    public interface IDataBaseRepository
    {
        Task<Resultado> IniciaAsync(BancoDadosConfig config);
    }
}