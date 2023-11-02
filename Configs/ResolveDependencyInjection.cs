using MeuBancoBackend.Service;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MeuBancoBackend.Configs
{
    public static class ResolveDependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
