using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.MainRole.Commands.UpdateMainRole
{
    public class UpdateMainRoleCommandHandler : ICommandHandler<UpdateMainRoleCommand, UpdateMainRoleCommandResponse>
    {
        private readonly IMainRoleService _mainRoleService;

        public UpdateMainRoleCommandHandler(IMainRoleService mainRoleService)
        {
            _mainRoleService = mainRoleService;
        }

        public async Task<UpdateMainRoleCommandResponse> Handle(UpdateMainRoleCommand request, CancellationToken cancellationToken)
        {
            Domain.AppEntities.MainRole mainRole = await _mainRoleService.GetById(request.Id);

            if (mainRole.Title == request.Title) throw new Exception("Güncellemeye çalıştığınız ana rol adı eski adıyla aynı!!");
            if (mainRole.Title != request.Title)
            {
                Domain.AppEntities.MainRole checkMainRole = await _mainRoleService.GetByTitleAndCompany(request.Title, mainRole.CompanyId);
                if(checkMainRole != null)
                {
                    throw new Exception("Bu rol adı daha önce kullanılmıştır");
                }
                mainRole.Title = request.Title;
                await _mainRoleService.UpdateAsync(mainRole, cancellationToken);
            }

            return new();
        }
    }
}

