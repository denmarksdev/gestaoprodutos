using GPApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPApp.Dal.Configurations
{
    class ProdutoImagemConfiguration : IEntityTypeConfiguration<ProdutoImagem>
    {
        public void Configure(EntityTypeBuilder<ProdutoImagem> entity)
        {
            entity.ToTable(nameof(ProdutoImagem));

            entity.Property(i => i.Prefixo)
                .HasMaxLength(15);
            entity.Property(i => i.Sufixo)
                  .HasMaxLength(4);

            entity.Ignore(i => i.Preview);
        }
    }
}
