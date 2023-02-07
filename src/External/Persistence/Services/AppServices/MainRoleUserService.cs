using System;
using Application.Services.AppServices;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.MainRoleUserRepositories;
using Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services.AppServices
{
    public class MainRoleUserService : IMainRoleUserService
    {
        private readonly IMainRoleUserCommandRepository _mainRoleUserCommandRepository;
        private readonly IMainRoleUserQueryRepository _mainRoleUserQueryRepository;
        private readonly IAppUnitOfWork _appUnitOfWork;

        public MainRoleUserService(IMainRoleUserCommandRepository mainRoleUserCommandRepository, IMainRoleUserQueryRepository mainRoleUserQueryRepository, IAppUnitOfWork appUnitOfWork)
        {
            _mainRoleUserCommandRepository = mainRoleUserCommandRepository;
            _mainRoleUserQueryRepository = mainRoleUserQueryRepository;
            _appUnitOfWork = appUnitOfWork;
        }

        public async Task CreateAsync(MainRoleUser mainRole, CancellationToken cancellationToken)
        {
            await _mainRoleUserCommandRepository.AddAsync(mainRole, cancellationToken);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task CreateRangeAsync(List<MainRoleUser> mainRoles, CancellationToken cancellationToken)
        {
            await _mainRoleUserCommandRepository.AddRangeAsnyc(mainRoles, cancellationToken);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteMainRoleUser(string id, CancellationToken cancellationToken)
        {
            await _mainRoleUserCommandRepository.RemoveById(id);
          //  _appUnitOfWork.SaveChangesAsync();
        }

        public async Task<MainRoleUser> GetById(string Id)
        {
            return await _mainRoleUserQueryRepository.GetById(Id);
        }

        public async Task<string> GetMainRoleByUserId(string userId)
        {
            return await _mainRoleUserQueryRepository.GetMainRoleUserByUserId(userId);
        }

        public async Task<IList<MainRoleUser>> GetMainRolUsereAsync()
        {
            return await _mainRoleUserQueryRepository.GetAll().ToListAsync();
        }

        public async Task<MainRoleUser> GetRolesByUserIdAndCompany(string userId, string companyId)
        {
            return await _mainRoleUserQueryRepository.GetFirstByExpression(p => p.UserId == userId && p.CompanyId == companyId);
        }

        public async Task UpdateAsync(MainRoleUser mainRole, CancellationToken cancellationToken)
        {
            _mainRoleUserCommandRepository.Update(mainRole);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

