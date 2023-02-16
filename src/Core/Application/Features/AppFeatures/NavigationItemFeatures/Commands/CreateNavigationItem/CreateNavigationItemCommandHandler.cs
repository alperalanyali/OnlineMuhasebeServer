using System;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.AppEntities;

namespace Application.Features.AppFeatures.NavigationItemFeatures.Commands.CreateNavigationItem
{
    public class CreateNavigationItemCommandHandler : ICommandHandler<CreateNavigationItemCommand, CreateNavigationItemCommandResponse>
    {
        private readonly INavigationItemService _navItemService;

        public CreateNavigationItemCommandHandler(INavigationItemService navItemService)
        {
            _navItemService = navItemService;
        }

        public async Task<CreateNavigationItemCommandResponse> Handle(CreateNavigationItemCommand request, CancellationToken cancellationToken)
        {
            var navigationItem = new NavigationItem(

                navigationName: request.NavigationName,
                navigationPath : request.NavigationPath,
                topNavigationId: request.TopNavigationId,
                priority: 0
              );
            await _navItemService.CreateAsync(navigationItem, cancellationToken);
            return new();
        }
    }
}

