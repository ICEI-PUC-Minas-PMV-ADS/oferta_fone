using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfertaFone.Data;
using OfertaFone.Domain.Interfaces;
using OfertaFone.Infra.Data.Repository;
using OfertaFone.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Azure.Security.KeyVault.Secrets;
using System;
using Azure.Identity;

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
            var enviroment = services.BuildServiceProvider().GetRequiredService<IHostingEnvironment>();

            services.AddDbContext<DatabaseContext>(options =>
                            options.UseSqlServer(enviroment.IsDevelopment() ? configuration.GetConnectionString("DataContextConnection") : GetSecret(configuration),
                            b => b.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));

            var databaseContext = services.BuildServiceProvider().GetRequiredService<DatabaseContext>();
            databaseContext.Database.Migrate();

            services.AddScoped<IRepository<Usuario>, Repository<Usuario>>();
            services.AddScoped<IRepository<MapPerfilUsuariosAcessos>, Repository<MapPerfilUsuariosAcessos>>();
            services.AddScoped<IRepository<Acesso>, Repository<Acesso>>();
            services.AddScoped<IRepository<PerfilUsuario>, Repository<PerfilUsuario>>();
            services.AddScoped<IRepository<ProdutoEntity>, Repository<ProdutoEntity>>();

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetSecret(IConfiguration configuration)
        {
            var clienteKeyVault = new SecretClient(vaultUri: new Uri(configuration.GetSection("KeyVault").GetSection("URISecret").Value), credential: new DefaultAzureCredential());
            KeyVaultSecret secret = clienteKeyVault.GetSecret("DataContextConnection");
            return secret.Value;
        }
    }
}
