using System;
using System.Reflection.Emit;
using Domain.Abstractions;
using Domain.AppEntities;
using Domain.AppEntities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence.Context
{
	public class AppDbContext:IdentityDbContext<AppUser,AppRole,string>
	{
        public AppDbContext()
        {

        }

        public DbSet<Company> Company { get; set; }
		public DbSet<AppUserCompany> UserCompany { get; set; }
        public DbSet<MainRole> MainRole { get; set; }
        public DbSet<MainRoleRole> MainRoleRole { get; set; }
        public DbSet<MainRoleUser> MainRoleUser { get; set; }
        public DbSet<NavigationItem> NavigationItem { get; set; }
        public DbSet<NavigationItemMainRole> NavigationItemMainRole { get; set; }
        public AppDbContext(DbContextOptions options) :base(options)
		{

		}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=MuhasebeMasterDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Trusted_Connection=False;User ID=sa;Password=metallica1;");
            }

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserRole<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();


        }

        public override ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();
            foreach (var entry in entries)
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property(p => p.CreatedDate).CurrentValue = Convert.ToDateTime(DateTimeOffset.Now);
                }
                if(entry.State == EntityState.Modified)
                {
                    entry.Property(p => p.UpdatedDate).CurrentValue = Convert.ToDateTime(DateTimeOffset.Now);
                }
            }
            return base.AddAsync(entity, cancellationToken);
        }

        public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder();
                var connectionString = "Data Source=localhost;Initial Catalog=MuhasebeMasterDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Trusted_Connection=False;User ID=sa;Password=metallica1;";
                optionsBuilder.UseSqlServer(connectionString);

                return new AppDbContext(optionsBuilder.Options);
            }
        }
    }
}

