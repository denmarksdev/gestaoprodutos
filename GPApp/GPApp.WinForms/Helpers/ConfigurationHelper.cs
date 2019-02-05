
using System.Configuration;
using GPApp.Shared.Constantes;

namespace GPApp.WinForms.Helpers
{
    public static class ConfigurationHelper
    {
        public static string GetConnectionString()
        {
            var conexaoDB = ConfigurationManager.ConnectionStrings[ContantesGlobais.CONEXAO_PRINCIPAL];
            return conexaoDB.ConnectionString;
        }

    }
}
