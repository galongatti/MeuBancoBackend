using MeuBancoBackend.Repository;
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

            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();

            services.AddScoped<IEmprestimoService, EmprestimoService>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();

            return services;
        }
    }
}
