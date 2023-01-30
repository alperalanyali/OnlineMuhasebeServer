using System;
using Application.Services.AppServices;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.MainRoleRepository;
using Domain.UnitOfWork;

namespace Persistence.Services.AppServices
{
	public class MainRoleService:IMainRoleService
	{
        private readonly IMainRoleCommandRepository _mainRoleCommandTRepository;
        private readonly IMainRoleQueryRepository _mainRoleQueryRepository;
        private readonly IAppUnitOfWork _appUnitOfWork;
        public MainRoleService(IMainRoleCommandRepository mainRoleCommandRepository, IMainRoleQueryRepository mainRoleQueryRepository, IAppUnitOfWork appUnitOfWork)
        {
            _mainRoleCommandTRepository = mainRoleCommandRepository;
            _mainRoleQueryRepository = mainRoleQueryRepository;
            _appUnitOfWork = appUnitOfWork;
        }

        public async Task CreateAsync(MainRole mainRole,CancellationToken cancellation)
        {
            await _mainRoleCommandTRepository.AddAsync(mainRole, cancellation);
            _appUnitOfWork.SaveChangesAsync(cancellation);
        }

        public Task<IList<MainRole>> GetStaticMainRoleAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MainRole> GetByTitleAndCompany(string title, string companyId)
        {
            //if (companyId == null)
            //    return await _mainRoleQueryRepository.GetFirstByExpression(p => p.Title == title);
            return await _mainRoleQueryRepository.GetFirstByExpression(p => p.Title == title && p.CompanyId == companyId,false);
        }

        public async Task CreateRangeAsync(List<MainRole> mainRoles,CancellationToken cancellationToken)
        {
            await _mainRoleCommandTRepository.AddRangeAsnyc(mainRoles, cancellationToken);
            _appUnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

