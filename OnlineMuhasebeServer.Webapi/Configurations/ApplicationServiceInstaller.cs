using System;
using MediatR;

namespace OnlineMuhasebeServer.Webapi.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Application.AssemblyReference).Assembly);
        }
    }
}

