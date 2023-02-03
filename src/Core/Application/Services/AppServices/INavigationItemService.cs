using System;
using Domain.AppEntities;

namespace Application.Services.AppServices
{
	public interface INavigationItemService
	{
        Task<NavigationItem> GetById(string Id);
        Task<IList<NavigationItem>> GetNavigationItems();
        Task CreateAsync(NavigationItem navigationItem, CancellationToken cancellationToken);        
        Task DeleteNavigationItem(string id, CancellationToken cancellationToken);
        Task UpdateAsync(NavigationItem navigationItem, CancellationToken cancellationToken);
    }
}

