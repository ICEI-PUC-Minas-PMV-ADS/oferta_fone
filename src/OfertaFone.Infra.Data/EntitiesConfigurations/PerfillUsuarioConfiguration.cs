using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfertaFone.Domain.Entities;

namespace OfertaFone.Infra.Data.EntitiesConfigurations
{
    public class PerfillUsuarioConfiguration : IEntityTypeConfiguration<PerfilUsuario>
    {
        public void Configure(EntityTypeBuilder<PerfilUsuario> builder)
        {
            builder.ToTable("PerfilUsuario");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome).HasMaxLength(30).IsRequired();
            builder.Property(u => u.Situacao).IsRequired();
        }
    }
}
