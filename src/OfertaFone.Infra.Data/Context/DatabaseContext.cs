using Microsoft.EntityFrameworkCore;
using OfertaFone.Domain.Entities;

namespace OfertaFone.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public DbSet<ProdutoEntity> ProdutoEntity { get; set; }
        public DbSet<Usuario> Users { get; set; }
        public DbSet<Acesso> Acessos { get; set; }
        public DbSet<MapPerfilUsuariosAcessos> MapPerfilUsuariosAcessos { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }
    }
}
