using MeuBancoBackend.Context;
using MeuBancoBackend.NovaPasta;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MeuBancoBackend.Configs
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services,
          IConfiguration configuration)
        {
            services.AddDbContext<UsuarioDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<UsuarioDBContext>()
                .AddDefaultTokenProviders();

            // JWT
            IConfigurationSection AppSettingSection = configuration.GetSection("AppSettings");
            services.Configure<AppSetting>(AppSettingSection);

            AppSetting appSetting = AppSettingSection.Get<AppSetting>();
            byte[] key = Encoding.ASCII.GetBytes(appSetting.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSetting.ValidoEm,
                    ValidIssuer = appSetting.Emissor
                };
            });

            return services;
        }
    }
}
