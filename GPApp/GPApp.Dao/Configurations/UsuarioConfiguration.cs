using GPApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPApp.Dal.Configurations
{
    class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.ToTable(nameof(Usuario));
            entity.Property(p => p.Nome).IsRequired(true).HasMaxLength(80);
            entity.Property(p => p.Senha).IsRequired(true).HasMaxLength(200);
            entity.Property(p => p.Email).IsRequired(true).HasMaxLength(150);
            entity.Property(p => p.Celular).HasMaxLength(14);
        }
    }
}
