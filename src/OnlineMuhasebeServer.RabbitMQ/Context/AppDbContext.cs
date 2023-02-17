using System;
using Domain.Abstractions;
using Domain.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace OnlineMuhasebeServer.RabbitMQ.Context
{
	public class AppDbContext:DbContext
	{


        public DbSet<Company> Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
          optionsBuilder.UseSqlServer("Data Source=localhost;" +
                                      "Initial Catalog=MuhasebeMasterDb;" +
                                      "Integrated Security=True;" +
                                      "Connect Timeout=30;" +
                                      "Encrypt=False;" +
                                      "TrustServerCertificate=False;" +
                                      "ApplicationIntent=ReadWrite;" +
                                      "MultiSubnetFailover=False;" +
                                      "Trusted_Connection=False;" +
                                      "User ID=sa;" +
                                      "Password=metallica1;");            
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

       
	}
}

