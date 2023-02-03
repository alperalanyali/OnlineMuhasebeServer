using System;
using Application.Services.AppServices;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.NavigationItemRepositories;
using Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services.AppServices
{
    public class NavigationItemService : INavigationItemService
    {
        private readonly INavigationItemCommandRepository _navigationItemCommand;
        private readonly INavigationItemQueryRepository _navigationItemQuery;
        private readonly IAppUnitOfWork _appIUnitOfWork;


        public NavigationItemService(INavigationItemCommandRepository navigationItemCommandRepository, INavigationItemQueryRepository navigationItemQueryRepository, IAppUnitOfWork appUnitOfWork)
        {
            _navigationItemCommand = navigationItemCommandRepository;
            _navigationItemQuery = navigationItemQueryRepository;
            _appIUnitOfWork = appUnitOfWork;
        }

        public async Task CreateAsync(NavigationItem navigationItem, CancellationToken cancellationToken)
        {
            await _navigationItemCommand.AddAsync(navigationItem, cancellationToken);
            await _appIUnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteNavigationItem(string id, CancellationToken cancellationToken)
        {
            await _navigationItemCommand.RemoveById(id);
            await _appIUnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<NavigationItem> GetById(string Id)
        {
            return await _navigationItemQuery.GetById(Id);
        }

        public async Task<IList<NavigationItem>> GetNavigationItems()
        {
            return await _navigationItemQuery.GetAll().ToListAsync();
        }

        public async Task UpdateAsync(NavigationItem navigationItem, CancellationToken cancellationToken)
        {
            _navigationItemCommand.Update(navigationItem);
            await _appIUnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

