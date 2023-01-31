using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.MainRoleUser.Commands.UpdateMainRoleUser
{
    public class UpdateMainRoleUserCommandHandler : ICommandHandler<UpdateMainRoleUserCommand, UpdateMainRoleUserCommandResponse>
    {

        private readonly IMainRoleUserService _mainRoleUserService;

        public UpdateMainRoleUserCommandHandler(IMainRoleUserService mainRoleUserService)
        {
            _mainRoleUserService = mainRoleUserService;
        }

        public async Task<UpdateMainRoleUserCommandResponse> Handle(UpdateMainRoleUserCommand request, CancellationToken cancellationToken)
        {
            var mainRoleUser = await _mainRoleUserService.GetById(request.Id);

            mainRoleUser.MainRoleId = request.MainRoleId;
            mainRoleUser.UserId = request.UserId;
            mainRoleUser.CompanyId = request.CompanyId;

            await _mainRoleUserService.UpdateAsync(mainRoleUser, cancellationToken);
            return new();   
        }
    }
}

