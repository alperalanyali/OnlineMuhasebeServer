using System;
using Domain.Abstractions;
using Domain.AppEntities;
using Domain.AppEntities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Persistence.Context
{
	public class AppDbContext:IdentityDbContext<AppUser,AppRole,string>
	{
        public AppDbContext()
        {

        }

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
        public DbSet<Company> Company { get; set; }
		public DbSet<AppUserCompany> UserCompany { get; set; }

        public override ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();
            foreach (var entry in entries)
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property(p => p.CreatedDate).CurrentValue = DateTime.Now;
                }
                if(entry.State == EntityState.Modified)
                {
                    entry.Property(p => p.UpdatedDate).CurrentValue = DateTime.Now;
                }
            }
            return base.AddAsync(entity, cancellationToken);
        }
    }
}

