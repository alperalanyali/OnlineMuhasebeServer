using System;
using Application;
using Application.Behavior;
using FluentValidation;
using MediatR;

namespace OnlineMuhasebeServer.Webapi.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Application.AssemblyReference).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), (typeof(ValidationBehavior<,>)));

            services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
        }
    }
}

