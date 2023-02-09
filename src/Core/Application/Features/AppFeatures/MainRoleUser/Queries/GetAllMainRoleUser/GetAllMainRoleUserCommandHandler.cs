using System;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.Dtos;

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
            var result = await _mainRoleUserService.GetMainRolUsereAsync("");
            var dtos = result.Select(s => new MainRoleUserDto(s.Id,s.UserId,s.AppUser.UserName,s.MainRoleId,s.MainRole.Title)).ToList();
            return new(result.Count(), dtos);
        }
    }
}

