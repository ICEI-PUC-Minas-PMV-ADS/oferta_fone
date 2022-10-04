using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfertaFone.Data;
using OfertaFone.Domain.Interfaces;
using OfertaFone.Infra.Data.Repository;
using OfertaFone.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace OfertaFone.Infra.IoC
{
    public static class DependencyInjection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfraEstructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("DataContextConnection"),
                            b => b.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));

            services.AddScoped<IRepository<Usuario>, Repository<Usuario>>();
            services.AddScoped<IRepository<MapPerfilUsuariosAcessos>, Repository<MapPerfilUsuariosAcessos>>();
            services.AddScoped<IRepository<Acesso>, Repository<Acesso>>();
            services.AddScoped<IRepository<PerfilUsuario>, Repository<PerfilUsuario>>();
            services.AddScoped<IRepository<ProdutoEntity>, Repository<ProdutoEntity>>();

            return services;
        }
    }
}
