using GPApp.Model.Database;
using GPApp.Model.Helpers;
using System;
using System.Threading.Tasks;

namespace GPApp.Dal.Dao
{
    public class DataBaseDao
    {
        public async Task<Resultado> InitAsync(BancoDadosConfig config)
        {
            try
            {
                if (config == null)
                    throw new ArgumentException("A configuração do banco de dados deve ser fornecida", nameof(config));


                DatabaseManager.SetDataBaseConfig(config);
                await DatabaseManager.MigrarDadoAsync();
                return new Resultado("Migração efetuada com sucesso");
            }
            catch (Exception ex)
            {
                return new Resultado("Falha ao executar a migração de dados", ex, false);
            }
        }
    }
}
