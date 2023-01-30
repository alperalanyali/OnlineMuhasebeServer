using System;
using Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using Application.Services.AppServices;
using AutoMapper;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.CompanyRepositories;
using Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.AppDbContext.CompanyRepositories;

namespace Persistence.Services.AppServices
{
    public class CompanyService : ICompanyService
    {

        //private readonly AppDbContext _dbContext;
        private readonly ICompanyCommandRepository _companyCommandRepository;
        private readonly ICompanyQueryRepository _companyQueryRepository;
        private readonly IAppUnitOfWork _appUnitOfWork;
        private readonly IMapper _mapper;
        public CompanyService(ICompanyCommandRepository companyCommandRepository, ICompanyQueryRepository companyQueryRepository, IAppUnitOfWork unitOfWork,IMapper mapper)
        {
            _companyCommandRepository = companyCommandRepository;
            _companyQueryRepository = companyQueryRepository;
            _appUnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateCompany(CreateCompanyCommand request,CancellationToken cancellationToken)
        {
            Company company = _mapper.Map<Company>(request);
            company.Id = Guid.NewGuid().ToString();
            await _companyCommandRepository.AddAsync(company, cancellationToken);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);
        }

    

        public async Task<Company?> GetCompanyByName(string name)
        {
            return await _companyQueryRepository.GetFirstByExpression(p => p.Name == name);
        }

        public async Task MigrateCompanyDatabases()
        {
            var companies = await _companyQueryRepository.GetAll().ToListAsync();
            foreach (var company in companies)
            {
                var db = new CompanyDbContext(company);
                db.Database.Migrate();
            }

        }
    }
}

