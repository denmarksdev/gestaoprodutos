using GPApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPApp.Dal.Configurations
{
    public class PropagandaClienteConfiguration : IEntityTypeConfiguration<PropagandaCliente>
    {
        public void Configure(EntityTypeBuilder<PropagandaCliente> builder)
        {
            builder.ToTable(nameof(PropagandaCliente));
            builder.Property(p => p.ChaveCliente)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
