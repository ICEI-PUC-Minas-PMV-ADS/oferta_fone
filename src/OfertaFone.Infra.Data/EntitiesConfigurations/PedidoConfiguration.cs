using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfertaFone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfertaFone.Infra.Data.EntitiesConfigurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Total).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(u => u.Status).IsRequired();
            builder.Property(u => u.QuantidadeItens).IsRequired();
            builder.Property(u => u.Status).IsRequired();
            builder.HasOne(u => u.Usuario)
                .WithMany(u => u.Pedido)
                .HasForeignKey(a => a.UsuarioId);
        }
    }
}
