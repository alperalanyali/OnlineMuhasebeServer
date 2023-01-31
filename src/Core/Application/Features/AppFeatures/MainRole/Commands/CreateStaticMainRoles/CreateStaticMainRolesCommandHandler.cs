using System;
using Application.Messaging;
using Application.Roles;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.MainRole.Commands.CreateStaticMainRoles
{
	public class CreateStaticMainRolesCommandHandler: ICommandHandler<CreateStaticMainRolesCommand,CreateStaticMainRolesResponse>
	{

        private readonly IMainRoleService _mainRoleService;

        public CreateStaticMainRolesCommandHandler(IMainRoleService mainRoleService)
        {
            _mainRoleService = mainRoleService;
        }

        public async Task<CreateStaticMainRolesResponse> Handle(CreateStaticMainRolesCommand request, CancellationToken cancellationToken)
        {
            List<Domain.AppEntities.MainRole> mainRoles = RoleList.GetStaticMainRole();
            List<Domain.AppEntities.MainRole> newRoles = new List<Domain.AppEntities.MainRole>();
            foreach (var mainRole in mainRoles)
            {
                Domain.AppEntities.MainRole checkMainRole = await _mainRoleService.GetByTitleAndCompany(mainRole.Title, mainRole.CompanyId);
                if (checkMainRole == null)
                    newRoles.Add(mainRole);
            }

            await _mainRoleService.CreateRangeAsync(newRoles,cancellationToken);

            return new();

        }
    }
}

