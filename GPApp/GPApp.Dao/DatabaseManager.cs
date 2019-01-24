using GPApp.Dal.Dao;
using GPApp.Model.Database;
using GPApp.Shared.Dados;
using System;
using System.Threading.Tasks;

namespace GPApp.Dal
{
    class DatabaseManager
    {
        private static BancoDadosConfig _config { get; set; }

        public static GPDataContext GetContext()
        {
            DatabaseManager.VerificaConfiguracao();
            new GPDataContext().SetConfiguracao(DatabaseManager._config);
            return new GPDataContext();
        }

        public static IGenericDao<T> GetDal<T>() where T : class
        {
            DatabaseManager.VerificaConfiguracao();
            return (IGenericDao<T>) new GenericDao<T>();
        }

        public static void SetDataBaseConfig(BancoDadosConfig dataBaseConfig)
        {
            _config = dataBaseConfig;
        }

        private static void VerificaConfiguracao()
        {
            if (_config == null)
                throw new ArgumentException("A configuração do banco de dados deve ser fornecida");
        }

        public static async Task MigrarDadoAsync()
        {
            await GetContext().MigrarDadosAsync();
        }
    }
}