using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.MainRoleUser.Queries.GetAllMainRoleUser
{
    public class GetAllMainRoleUserCommandHandler : ICommandHandler<GetAllMainRoleUserCommand, GetAllMainRoleUserCommandResponse>
    {
        private readonly IMainRoleUserService _mainRoleUserService;

        public GetAllMainRoleUserCommandHandler(IMainRoleUserService mainRoleUserService)
        {
            _mainRoleUserService = mainRoleUserService;
        }

        public async Task<GetAllMainRoleUserCommandResponse> Handle(GetAllMainRoleUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _mainRoleUserService.GetMainRolUsereAsync();

            return new(result.Count(), result);
        }
    }
}

