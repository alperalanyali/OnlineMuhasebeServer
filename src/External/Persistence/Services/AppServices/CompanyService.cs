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

        private static readonly Func<AppDbContext, string, Task<Company?>> GetCompanyByNameCompiled =
            EF.CompileAsyncQuery(AppDbContext context,string name) =>
            {
                await _dbContext.Set<Company>().FirstOrDefault(p => p.Name == name)
            };
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

        public async Task<Company> GetCompanyByName(string name)
        {
            return ;
        }
    }
}

