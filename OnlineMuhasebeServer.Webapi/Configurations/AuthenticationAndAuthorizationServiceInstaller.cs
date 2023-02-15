using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using OnlineMuhasebeServer.Webapi.OptionsSetup;

namespace OnlineMuhasebeServer.Webapi.Configurations
{
    public class AuthenticationAndAuthorizationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
            services.AddAuthentication();
            services.AddAuthorization();
        }
    }
}

