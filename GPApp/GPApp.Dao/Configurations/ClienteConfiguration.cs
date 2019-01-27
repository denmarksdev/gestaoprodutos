using GPApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPApp.Dal.Configurations
{
    internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(nameof(Cliente));

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(c => c.Email)
                .IsRequired();

            builder.Property(c => c.DataCadastro)
                .IsRequired();
        }
    }
}
