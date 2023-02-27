using System;
using Application.Abstractions;
using Application.Services;
using Infrastructure.Authentication;
using Infrastructure.Services;

namespace OnlineMuhasebeServer.Webapi.Configurations
{
    public class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IRabbitMQService, RabbitMQService>();
            services.AddScoped<IApiService, ApiService>();
        }
    }
}

