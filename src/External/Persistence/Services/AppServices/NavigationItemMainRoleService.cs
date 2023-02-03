﻿using System;
using Application.Services.AppServices;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.NavigationItemMainRoleRepositories;
using Domain.Repository.AppDbContext.NavigationItemRepositories;
using Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services.AppServices
{
    public class NavigationItemMainRoleService : INavigationItemMainRoleService
    {
        private readonly INavigationItemMainRoleCommandRepository _navigationItemMainRoleCommand;
        private readonly INavigationItemMainRoleQueryRepository _navigationItemMainRoleQuery;
        private readonly IAppUnitOfWork _appUnitOfWork;

        public NavigationItemMainRoleService(INavigationItemMainRoleCommandRepository navigationItemCommandRepository, INavigationItemMainRoleQueryRepository navigationItemMainRoleQueryRepository, IAppUnitOfWork appUnitOfWork)
        {
            _navigationItemMainRoleCommand = navigationItemCommandRepository;
            _navigationItemMainRoleQuery = navigationItemMainRoleQueryRepository;
            _appUnitOfWork = appUnitOfWork;
        }

        public async Task CreateAsync(NavigationItemMainRole navigationItemMainRole, CancellationToken cancellationToken)
        {
            await _navigationItemMainRoleCommand.AddAsync(navigationItemMainRole, cancellationToken);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteNavigationItemMainRoleById(string id, CancellationToken cancellationToken)
        {
            _navigationItemMainRoleCommand.RemoveById(id);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<NavigationItemMainRole> GetById(string Id)
        {
            return await _navigationItemMainRoleQuery.GetById(Id);
        }

        public async Task<IList<NavigationItemMainRole>> GetNavigationItemMainRoles()
        {
            return await _navigationItemMainRoleQuery.GetAll().ToListAsync();
        }

        public async Task<IList<NavigationItemMainRole>> GetNavigationItemMainRolesByMainRoleId(string mainRoleId)
        {
            return await _navigationItemMainRoleQuery.GetWhere(p => p.MainRoleId == mainRoleId).Include("NavigationItem").ToListAsync();
        }

        public Task UpdateAsync(NavigationItemMainRole navigationItemMainRole, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

