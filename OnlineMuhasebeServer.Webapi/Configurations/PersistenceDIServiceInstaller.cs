using System;
using Application.Services.AppServices;
using Application.Services.CompanyServices;
using Domain;
using Domain.Repository.AppDbContext.CompanyRepositories;
using Domain.Repository.CompanyDbContext.UCAFRepositories;
using Domain.UnitOfWork;
using Persistence;
using Persistence.Repositories.AppDbContext.CompanyRepositories;
using Persistence.Repositories.CompanyDbContext.UCAFRepositories;
using Persistence.Services.AppServices;
using Persistence.Services.CompanyServices;
using Persistence.UnitOfWorks;

namespace OnlineMuhasebeServer.Webapi.Configurations
{
    public class PersistenceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICompanyDbUnitOfWork, CompanyDbUnitOfWork>();
            services.AddScoped<IAppUnitOfWork, AppDbUnitOfWork>();
            services.AddScoped<IContextService, ContextService>();

            #region Services
            #region AppDbContext
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IRoleService, RoleServices>();
            #endregion
            #region CompanDbContext
            services.AddScoped<IUCAFService, UCAFService>();
            #endregion
            #endregion

            #region Repositories

            #region AppDbContext
            services.AddScoped<ICompanyCommandRepository, CompanyCommandRepository>();
            services.AddScoped<ICompanyQueryRepository, CompanyQueryRepository>();
            #endregion

            #region CompanyDbContext
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            #endregion
           
            #endregion
        }
    }
}

