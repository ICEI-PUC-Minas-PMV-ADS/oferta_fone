using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OfertaFone.WebUI.Identity.Hasher;
using OfertaFone.WebUI.Identity.Stores;
using OfertaFone.WebUI.Identity;
using AutoMapper;

namespace OfertaFone.WebUI.WebUIDependencys
{
    public static class DependencyInjection
    {
        public static void IncludeWebUIDependencys(this IServiceCollection services)
        {
            services
               .AddIdentity<ApplicationUser, ApplicationRole>()
               .AddRoles<ApplicationRole>()
               .AddDefaultTokenProviders();

            services.AddRazorPages();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToViewModelMappingProfile());
            });

            services.AddSingleton(mapperConfig.CreateMapper());
            services.AddTransient<IUserStore<ApplicationUser>, UserStore>();
            services.AddTransient<IRoleStore<ApplicationRole>, RoleStore>();
            services.AddScoped<IPasswordHasher<ApplicationUser>, NoPasswordHasher>();
        }
    }
}
