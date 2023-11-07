using MeuBancoBackend.Configs;
using MeuBancoBackend.Context;
using MeuBancoBackend.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Services.AddDbContext<MeuBancoDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

IConfigurationSection AppMenssageriaSection = builder.Configuration.GetSection("ServicosMensagerias");
builder.Services.Configure<ServicosMensagerias>(AppMenssageriaSection);

builder.Services.AddIdentityConfig(builder.Configuration);
builder.Services.AddApiConfig();
builder.Services.AddSwaggerConfig();
builder.Services.ResolveDependencies();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiConfig(app.Environment);
app.UseSwaggerConfig();
app.Run();
