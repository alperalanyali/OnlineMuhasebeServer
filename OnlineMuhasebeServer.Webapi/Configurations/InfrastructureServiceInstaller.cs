using System;
using Application.Abstractions;
using Infrastructure.Authentication;

namespace OnlineMuhasebeServer.Webapi.Configurations
{
    public class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();
        }
    }
}

