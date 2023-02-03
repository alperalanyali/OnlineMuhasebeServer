using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.NavigationItemFeatures.Queries.GetNavigationItems
{
    public class GetNavigationItemsQueryHandler : IQueryHandler<GetNavigationItemsQuery, GetNavigationItemsQueryResponse>
    {
        private readonly INavigationItemService _navigationItemService;

        public GetNavigationItemsQueryHandler(INavigationItemService navigationItemService)
        {
            _navigationItemService = navigationItemService;
        }

        public async Task<GetNavigationItemsQueryResponse> Handle(GetNavigationItemsQuery request, CancellationToken cancellationToken)
        {
            var results =await _navigationItemService.GetNavigationItems();

            return new(results.Count(),results);
        }
    }
}

