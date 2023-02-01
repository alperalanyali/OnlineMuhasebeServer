using System;
using Application.Services.AppServices;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.MainRoleRoleRepositories;
using Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.AppDbContext.MainRoleRoleRepositories;

namespace Persistence.Services.AppServices
{
    public class MainRoleRoleService : IMainRoleRoleService
    {
        private readonly IMainRoleRoleCommand _mainRoleRoleCommandRepository;
        private readonly IMainRoleRoleQueryRepository _mainRoleRoleQueryRepository;
        private readonly IAppUnitOfWork _appUnitOfWork;

        public MainRoleRoleService(IMainRoleRoleCommand mainRoleRoleCommand, IMainRoleRoleQueryRepository mainRoleRoleQueryRepository, IAppUnitOfWork appUnitOfWork)
        {
            _mainRoleRoleCommandRepository = mainRoleRoleCommand;
            _mainRoleRoleQueryRepository = mainRoleRoleQueryRepository;
            _appUnitOfWork = appUnitOfWork;
        }
        public async Task CreateAsync(MainRoleRole mainRole, CancellationToken cancellationToken)
        {
            await _mainRoleRoleCommandRepository.AddAsync(mainRole, cancellationToken);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task CreateRangeAsync(List<MainRoleRole> mainRoles, CancellationToken cancellationToken)
        {
            await _mainRoleRoleCommandRepository.AddRangeAsnyc(mainRoles, cancellationToken);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteMainRoleRole(string id, CancellationToken cancellationToken)
        {
            await _mainRoleRoleCommandRepository.RemoveById(id);
        }

        public async Task<MainRoleRole> GetById(string Id)
        {
            return await _mainRoleRoleQueryRepository.GetById(Id, false);
        }

        public async Task<IList<MainRoleRole>> GetMainRoleRoleAsync()
        {
            return await _mainRoleRoleQueryRepository.GetAll().ToListAsync();
        }

        public async Task<IList<MainRoleRole>> GetMainRoleRoleByMainRoleId(string mainRoleId)
        {
            return await _mainRoleRoleQueryRepository.GetWhere(p => p.MainRoleId == mainRoleId).Include("AppRole").ToListAsync();             
        }

        public async Task UpdateAsync(MainRoleRole mainRole, CancellationToken cancellationToken)
        {
           _mainRoleRoleCommandRepository.Update(mainRole);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}

