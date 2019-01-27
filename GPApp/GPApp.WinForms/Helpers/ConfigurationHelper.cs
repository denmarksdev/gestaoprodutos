
using System.Configuration;

namespace GPApp.WinForms.Helpers
{
    public static class ConfigurationHelper
    {
        public const string CONEXAO_PRINCIPAL = "conexaoPrincipal";

        public static string GetConnectionString()
        {
            var conexaoDB = ConfigurationManager.ConnectionStrings[CONEXAO_PRINCIPAL];
            return conexaoDB.ConnectionString;
        }

    }
}
