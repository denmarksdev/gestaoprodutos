using GPApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPApp.Dal.Configurations
{
    class ProdutoEspecificacaoConfiguration : IEntityTypeConfiguration<ProdutoEspecificacao>
    {
        public void Configure(EntityTypeBuilder<ProdutoEspecificacao> entity)
        {
            entity.ToTable( nameof(ProdutoEspecificacao));

            entity.Property(e => e.Nome)
                  .HasMaxLength(40);
        }
    }
}