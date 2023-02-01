using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.UserCompanyFeatures.Commands.UpdateUserCompany
{
    public class UpdateUserCompanyCommandHandler : ICommandHandler<UpdateUserCompanyCommand, UpdateUserCompanyCommandResponse>
    {
        private readonly IUserCompanyService _userCompanyService;
        public UpdateUserCompanyCommandHandler(IUserCompanyService userCompanyService)
        {
            _userCompanyService = userCompanyService;
        }
        public async Task<UpdateUserCompanyCommandResponse> Handle(UpdateUserCompanyCommand request, CancellationToken cancellationToken)
        {
            var userCompany =await _userCompanyService.GetUserCompanyById(request.Id);
            userCompany.AppUserId = request.UserId;
            userCompany.CompanyId = request.CompanyId;
            await _userCompanyService.UpdateAsync(userCompany, cancellationToken);

            return new();
        }
    }
}

