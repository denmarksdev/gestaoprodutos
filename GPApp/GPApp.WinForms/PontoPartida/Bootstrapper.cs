using GPApp.Model.Database;
using GPApp.Presenter.Modulos.Produtos;
using GPApp.Shared.Dados;
using GPApp.WinForms.Helpers;
using MetroFramework.Forms;
using Ninject;
using System.Windows.Forms;

namespace GPApp.WinForms.PontoPartida
{
    class Bootstrapper
    {
        private readonly IKernel _ioc;

        internal Bootstrapper(IKernel ioc)
        {
            _ioc = ioc;
        }

        public void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var database = _ioc.Get<IDataBaseRepository>();
            var resultado = database.IniciaAsync(new BancoDadosConfig(BancoDados.Sqlite, ConfigurationHelper.GetConnectionString())).Result;

            if (!resultado.Valido)
            {
                MessageBox.Show(resultado.Mensagem + "\n" + resultado.Exception.Message);
                return;
            }
                       
            var _presenter = _ioc.Get<ProdutosPresenter>();
            Application.Run(_presenter.GetUI<MetroForm>());
        }

        public void StartMock()
        {
        }
    }
}