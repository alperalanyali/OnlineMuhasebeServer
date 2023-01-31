using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.MainRoleUser.Commands.DeleteMainRoleUser
{
    public class DeleteMainRoleUserCommandHandler : ICommandHandler<DeleteMainRoleUserCommand, DeleteMainRoleUserCommandResponse>
    {
        private readonly IMainRoleUserService _mainRoleUserService;

        public DeleteMainRoleUserCommandHandler(IMainRoleUserService mainRoleUserService)
        {
            _mainRoleUserService = mainRoleUserService;
        }

        public async Task<DeleteMainRoleUserCommandResponse> Handle(DeleteMainRoleUserCommand request, CancellationToken cancellationToken)
        {
            await _mainRoleUserService.DeleteMainRoleUser(request.Id, cancellationToken);
            return new();
        }
    }
}

