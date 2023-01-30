using System;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.AppEntities;
namespace Application.Features.AppFeatures.MainRole.Commands.CreateMainRole
{
	public class CreateRoleCommandHandler:ICommandHandler<CreateMainRoleCommand,CreateRoleResponse>
	{
        private readonly IMainRoleService _mainRoleService;

        public CreateRoleCommandHandler(IMainRoleService mainRoleService)
        {
            _mainRoleService = mainRoleService;
        }

        public async Task<CreateRoleResponse> Handle(CreateMainRoleCommand request, CancellationToken cancellationToken)
        {

            Domain.AppEntities.MainRole checkMainRoleTitle = await _mainRoleService.GetByTitleAndCompany(request.Title,request.CompanyId);

            if(checkMainRoleTitle != null)
            {
                throw new Exception("Bu rol daha önce eklenmiştir!!");
            }
            Domain.AppEntities.MainRole mainRole = new(
                request.Title,
                request.CompanyId,
                request.IsRoleCreatedByAdmin
                );
            await _mainRoleService.CreateAsync(mainRole,cancellationToken);

            return new();
        }
    }
}

