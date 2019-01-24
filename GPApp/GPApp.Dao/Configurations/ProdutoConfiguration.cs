using GPApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPApp.Dal.Configurations
{
    class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> entity)
        {
            entity.ToTable(nameof(Produto));

            entity.Property(p => p.Codigo)
                  .HasMaxLength(15);

            entity.Property(p => p.Nome)
                  .HasMaxLength(80);

            entity.Ignore(nameof(Produto.EstoqueAtual));
        }
    }
}
