using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfertaFone.Data;
using OfertaFone.Domain.Interfaces;
using OfertaFone.Infra.Data.Repository;
using OfertaFone.Domain.Entities; 
using Microsoft.AspNetCore.Hosting;
using Azure.Security.KeyVault.Secrets;
using System;
using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.DataProtection;
using OfertaFone.Utils.Service;
using OfertaFone.Utils.Extensions;

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
            var enviroment = services.BuildServiceProvider().GetRequiredService<IWebHostEnvironment>();

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(enviroment.IsDevelopment() ? configuration.GetConnectionString("DataContextConnection") : configuration.GetSecret("ConnectionStrings--DataContextConnection"),
                b => b.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
            
            if (!enviroment.IsDevelopment())
            {
                services.AddSingleton(svc =>
                    new BlobServiceClient(configuration.GetSecret("ofertafoneblobstorage")));

                services.AddScoped<IFileStorage, BlobStorageServiceAzure>();
            }
            else
            {
                services.AddScoped<IFileStorage, BlobStorageServiceLocal>();
            }

            var databaseContext = services.BuildServiceProvider().GetRequiredService<DatabaseContext>();
            databaseContext.Database.Migrate();

            services.AddScoped<IRepository<Usuario>, Repository<Usuario>>();
            services.AddScoped<IRepository<MapPerfilUsuariosAcessos>, Repository<MapPerfilUsuariosAcessos>>();
            services.AddScoped<IRepository<Acesso>, Repository<Acesso>>();
            services.AddScoped<IRepository<PerfilUsuario>, Repository<PerfilUsuario>>();
            services.AddScoped<IRepository<ProdutoEntity>, Repository<ProdutoEntity>>();
            services.AddScoped<IRepository<Pedido>, Repository<Pedido>>();
            services.AddScoped<IRepository<ItemPedido>, Repository<ItemPedido>>();

            return services;
        }
    }
}
