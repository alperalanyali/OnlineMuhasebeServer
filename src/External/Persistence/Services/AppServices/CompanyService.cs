using System;
using Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using Application.Services.AppServices;
using AutoMapper;
using Domain.AppEntities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Services.AppServices
{
    public class CompanyService : ICompanyService
    {

        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public CompanyService(AppDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateCompany(CreateCompanyRequest request)
        {
            Company company = _mapper.Map<Company>(request);
            company.Id = Guid.NewGuid().ToString();
            await _dbContext.Set<Company>().AddAsync(company);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Company?> GetCompanyByName(string name)
        {
            return await _dbContext.Set<Company>().FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task MigrateCompanyDatabases()
        {
            var companies = await _dbContext.Set<Company>().ToListAsync();
            foreach (var company in companies)
            {
                var db = new CompanyDbContext(company);
                db.Database.Migrate();
            }

        }
    }
}

