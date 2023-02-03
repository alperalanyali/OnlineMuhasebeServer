using System;
using Application.Services.AppServices;
using Application.Services.CompanyServices;
using Domain;
using Domain.Repository.AppDbContext.CompanyRepositories;
using Domain.Repository.AppDbContext.MainRoleRepository;
using Domain.Repository.AppDbContext.MainRoleRoleRepositories;
using Domain.Repository.AppDbContext.MainRoleUserRepositories;
using Domain.Repository.AppDbContext.NavigationItemMainRoleRepositories;
using Domain.Repository.AppDbContext.NavigationItemRepositories;
using Domain.Repository.AppDbContext.UserCompanyRepositories;
using Domain.Repository.CompanyDbContext.UCAFRepositories;
using Domain.UnitOfWork;
using Persistence;
using Persistence.Repositories.AppDbContext.CompanyRepositories;
using Persistence.Repositories.AppDbContext.MainRoleRepository;
using Persistence.Repositories.AppDbContext.MainRoleRoleRepositories;
using Persistence.Repositories.AppDbContext.MainRoleUserRepositories;
using Persistence.Repositories.AppDbContext.NavigationItemMainRoleRepositories;
using Persistence.Repositories.AppDbContext.NavigationItemRepository;
using Persistence.Repositories.AppDbContext.UserCompanyRepositories;
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
            services.AddScoped<IMainRoleService, MainRoleService>();
            services.AddScoped<IMainRoleRoleService, MainRoleRoleService>();
            services.AddScoped<IMainRoleUserService, MainRoleUserService>();
            services.AddScoped<IUserCompanyService, UserCompanyService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<INavigationItemService, NavigationItemService>();
            services.AddScoped<INavigationItemMainRoleService, NavigationItemMainRoleService>();
            #endregion
            #region CompanDbContext
            services.AddScoped<IUCAFService, UCAFService>();
            #endregion
            #endregion

            #region Repositories

            #region AppDbContext
            services.AddScoped<ICompanyCommandRepository, CompanyCommandRepository>();
            services.AddScoped<ICompanyQueryRepository, CompanyQueryRepository>();
            services.AddScoped<IMainRoleCommandRepository, MainRoleCommandRepository>();
            services.AddScoped<IMainRoleQueryRepository, MainRoleQueryRepository>();
            services.AddScoped<IMainRoleRoleCommand, MainRoleRoleCommandRepository>();
            services.AddScoped<IMainRoleRoleQueryRepository, MainRoleRoleQueryRepository>();
            services.AddScoped<IMainRoleUserCommandRepository, MainRoleUserCommandRepository>();
            services.AddScoped<IMainRoleUserQueryRepository, MainRoleUserQueryRepository>();
            services.AddScoped<IUserCompanyCommandRepository, UserCompanyCommandRepository>();
            services.AddScoped<IUserCompanyQueryRepository, UserCompanyQueryRepository>();
            services.AddScoped<INavigationItemCommandRepository, NavigationItemCommandRepository>();
            services.AddScoped<INavigationItemQueryRepository, NavigationItemQueryRepository>();
            services.AddScoped<INavigationItemCommandRepository, NavigationItemCommandRepository>();
            services.AddScoped<INavigationItemMainRoleCommandRepository, NavigationItemMainRoleCommandRepository>();
            services.AddScoped<INavigationItemMainRoleQueryRepository, NavigationItemMainRoleQueryRepository>();
            #endregion

            #region CompanyDbContext
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            #endregion
           
            #endregion
        }
    }
}

