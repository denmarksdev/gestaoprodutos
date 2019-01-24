using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using GPApp.Shared.Dados;
using GPApp.Model;
using GPApp.Repository;
using GPApp.Model.Database;
using Microsoft.Extensions.Configuration;
using GPApp.Service;

namespace GPApp.Web
{
    public class Startup
    {
        #region Membros privados

        private IConfiguration _configuration { get; }

        #endregion

        #region Construtor

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region Métodos

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSpaStaticFiles(spa => spa.RootPath = "wwwroot/dist/client");
            services.AddMvc();
            services.AddTransient<IGenericRepository<Produto>, GenericRepository<Produto>>();
            services.AddTransient<IDataBaseRepository, DataBaseRepository>();
            services.AddTransient<IProdutoService, ProdutoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            await ConfiguraBaseDados(app);

            app.UseMvc();
            app.UseStaticFiles();
            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                {
                    spa.Options.SourcePath = "client";
                    spa.UseAngularCliServer("start");
                }
            });
        }

        private async System.Threading.Tasks.Task ConfiguraBaseDados(IApplicationBuilder app)
        {
            var dbRepo = app.ApplicationServices.GetService<IDataBaseRepository>();
            var strConexao = _configuration.GetValue<string>("ConnectionStrings:AppDataContext");
            await dbRepo.IniciaAsync(new BancoDadosConfig(BancoDados.Sqlite, strConexao));
        }

        #endregion

    }
}
