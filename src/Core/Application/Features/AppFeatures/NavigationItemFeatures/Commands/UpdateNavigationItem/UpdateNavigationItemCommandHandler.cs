using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.NavigationItemFeatures.Commands.UpdateNavigationItem
{
    public class UpdateNavigationItemCommandHandler : ICommandHandler<UpdateNavigationItemCommand, UpdateNavigationItemCommandResponse>
    {

        private readonly INavigationItemService _navigationItemService;

        public UpdateNavigationItemCommandHandler(INavigationItemService navigationItemService)
        {
            _navigationItemService = navigationItemService;
        }

        public async Task<UpdateNavigationItemCommandResponse> Handle(UpdateNavigationItemCommand request, CancellationToken cancellationToken)
        {
            var navItem = await _navigationItemService.GetById(request.Id);
            navItem.NavigationName = request.NavigationName;
            navItem.NavigationPath = request.NavigationPath;
            navItem.TopNavigationId = request.TopNavigationId;
            navItem.Priority = request.Priority;
            await _navigationItemService.UpdateAsync(navItem, cancellationToken);
            return new();
        }
    }
}

