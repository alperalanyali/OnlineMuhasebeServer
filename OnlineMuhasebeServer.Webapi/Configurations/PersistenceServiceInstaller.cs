using System;
using Domain.AppEntities.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace OnlineMuhasebeServer.Webapi.Configurations
{
    public class PersistenceServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });
           services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddAutoMapper(typeof(Persistence.AssemblyReference).Assembly);
        }
    }
}

