using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.NavigationItemFeatures.Commands.DeleteNavigationItem
{
    public class DeleteNavigationItemCommandHandler : ICommandHandler<DeleteNavigationItemCommand, DeleteNavigationItemCommandResponse>
    {
        private readonly INavigationItemService _navigationItemService;

        public DeleteNavigationItemCommandHandler(INavigationItemService navigationItemService)
        {
            _navigationItemService = navigationItemService;
        }

        public async Task<DeleteNavigationItemCommandResponse> Handle(DeleteNavigationItemCommand request, CancellationToken cancellationToken)
        {
            await _navigationItemService.DeleteNavigationItem(request.Id, cancellationToken);

            return new();
        }
    }
}

