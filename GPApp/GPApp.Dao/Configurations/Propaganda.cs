using GPApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPApp.Dal.Configurations
{
    internal class PropagandaConfiguration : IEntityTypeConfiguration<Propaganda>
    {
        public void Configure(EntityTypeBuilder<Propaganda> builder)
        {
            builder.ToTable(nameof(Propaganda));

            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(p => p.Chave)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
