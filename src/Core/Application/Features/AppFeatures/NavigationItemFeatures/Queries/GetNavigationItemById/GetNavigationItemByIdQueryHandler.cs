using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.NavigationItemFeatures.Queries.GetNavigationItemById
{
    public class GetNavigationItemByIdQueryHandler : IQueryHandler<GetNavigationItemByIdQuery, GetNavigationItemByIdQueryResponse>
    {
        private readonly INavigationItemService _navItemService;

        public GetNavigationItemByIdQueryHandler(INavigationItemService navItemService)
        {
            _navItemService = navItemService;
        }

        public async Task<GetNavigationItemByIdQueryResponse> Handle(GetNavigationItemByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _navItemService.GetById(request.Id);

            return new(result);
        }
    }
}

