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
    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoEntity> builder)
        {
            builder.ToTable("ProdutoEntity")
                .HasKey(u => u.Id);
            builder.Property(u => u.Nome).IsRequired();
            builder.Property(u => u.Preco).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(u => u.Descricao).IsRequired();
            builder.Property(u => u.Image);
            builder.Property(u => u.Ativo);
            builder.HasOne(u => u.Usuario)
                .WithMany(u => u.ProdutoEntity)
                .HasForeignKey(a => a.UsuarioId);
        }
    }
}
