using System;
using Domain.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence.Context
{
	public sealed class CompanyDbContext:DbContext
	{
        private string _connectionString { get; set; }
       
        public CompanyDbContext(Company company=null)
        {
            if(company != null)
            {
                if (!string.IsNullOrEmpty(company.ServerUserId))
                {
                    _connectionString = $"Data Source={company.ServerName};" +
                                 $"Initial Catalog={company.DatabaseName};" +
                                 $"User ID={company.ServerUserId};" +
                                 $"Password={company.ServerPassword};" +
                                 $"Integrated Security=True;" +
                                 $"Connect Timeout=30;" +
                                 $"Encrypt=False;" +
                                 $"TrustServerCertificate=False;" +
                                 $"ApplicationIntent=ReadWrite;" +
                                 $"MultiSubnetFailover=False;" +
                                 $"Trusted_Connection=False;";
                }
                else
                {
                    _connectionString = $"Data Source={company.ServerName};" +
                                 $"Initial Catalog={company.DatabaseName};" +
                                 // $"User ID={company.ServerUserId};" +
                                 //$"Password={company.ServerPassword};" +
                                 $"Integrated Security=True;" +
                                 $"Connect Timeout=30;" +
                                 $"Encrypt=False;" +
                                 $"TrustServerCertificate=False;" +
                                 $"ApplicationIntent=ReadWrite;" +
                                 $"MultiSubnetFailover=False;" +
                                 $"Trusted_Connection=False;";
                }
            }
           
         
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
        }

        public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
        {
            public CompanyDbContext CreateDbContext(string[] args)
            {
                return new CompanyDbContext();
            }
        }
    }
}

