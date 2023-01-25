using System;
using Application.Services.AppServices;
using Application.Services.CompanyServices;
using Domain;
using Domain.Repository.UCAFRepositories;
using Persistence;
using Persistence.Repositories.UCAFRepositories;
using Persistence.Services.AppServices;
using Persistence.Services.CompanyServices;

namespace OnlineMuhasebeServer.Webapi.Configurations
{
    public class PersistenceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContextService, ContextService>();

            services.AddScoped<ICompanyService, CompanyService>();


            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            services.AddScoped<IUCAFService, UCAFService>();
        }
    }
}

