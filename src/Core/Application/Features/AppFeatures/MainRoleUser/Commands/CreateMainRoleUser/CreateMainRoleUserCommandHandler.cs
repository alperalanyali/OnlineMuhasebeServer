using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.MainRoleUser.Commands.CreateMainRoleUser
{
    public class CreateMainRoleUserCommandHandler : ICommandHandler<CreateMainRoleUserCommand, CreateMainRoleUserCommandResponse>
    {
        private readonly IMainRoleUserService _mainRoleUserService;

        public CreateMainRoleUserCommandHandler(IMainRoleUserService mainRoleUserService)
        {
            _mainRoleUserService = mainRoleUserService;
        }

        public async Task<CreateMainRoleUserCommandResponse> Handle(CreateMainRoleUserCommand request, CancellationToken cancellationToken)
        {
            Domain.AppEntities.MainRoleUser mainRoleUser = new Domain.AppEntities.MainRoleUser(
                userId: request.UserId,
                mainRoleId: request.MainRoleId,
                companyId:request.CompanyId
                );
            await _mainRoleUserService.CreateAsync(mainRoleUser, cancellationToken);

            return new();
        }
    }
}

