using GPApp.Dal.Dao;
using GPApp.Model.Database;
using GPApp.Model.Helpers;
using GPApp.Shared.Dados;
using System.Threading.Tasks;

namespace GPApp.Repository
{
    public class DataBaseRepository : IDataBaseRepository
    {
        private readonly DataBaseDao _dao = new DataBaseDao();

        public Task<Resultado> IniciaAsync(BancoDadosConfig config)
        {
            return _dao.InitAsync(config);
        }
    }
}
