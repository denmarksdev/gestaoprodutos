using GPApp.Dal.Configurations;
using GPApp.Dal.Logs;
using GPApp.Model;
using GPApp.Model.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GPApp.Dal
{
    public class GPDataContext : DbContext
    {
        private static BancoDadosConfig _config = new BancoDadosConfig(BancoDados.SqlServer, "Server=DESKTOP/QCRBJD0\\SQLEXPRESS;Database=gpapp;Trusted_Connection=True;");

        #region Propriedades

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoImagem> Imagens { get; set; }
        public DbSet<ProdutoEspecificacao> Especificacoes { get; set; }
        public DbSet<ProdutoEstoque> Estoques { get; set; }

        #endregion

        #region Métodos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfiguraProvedor(optionsBuilder);
            optionsBuilder.UseLoggerFactory(DbContextExtensions.GetProvider());
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoImagemConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoEspecificacaoConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoEstoqueConfiguration());
        }

        private static void ConfiguraProvedor(DbContextOptionsBuilder optionsBuilder)
        {
            switch (GPDataContext._config.Tipo)
            {
                case BancoDados.SqlServer:
                    optionsBuilder.UseSqlServer(GPDataContext._config.StringConexao);
                    break;
                case BancoDados.PostgreSql:
                    optionsBuilder.UseNpgsql(GPDataContext._config.StringConexao);
                    break;
                case BancoDados.Sqlite:
                    optionsBuilder.UseSqlite(GPDataContext._config.StringConexao);
                    break;
                case BancoDados.MySql:
                    throw new NotImplementedException(BancoDados.MySql.ToString());
                default:
                    throw new NotImplementedException(GPDataContext._config.Tipo.ToString());
            }
        }

        public void SetConfiguracao(BancoDadosConfig baseConfig)
        {
            _config = baseConfig;
        }

        internal async Task MigrarDadosAsync()
        {
           await Database.MigrateAsync();
        }

        #endregion
    }
}