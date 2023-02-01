using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.UserCompanyFeatures.Queries.GetAllUserCompany
{
    public class GetAllUserCompanyCommandHandler : ICommandHandler<GetAllUserCompanyCommand, GetAllUserCompanyCommandResponse>
    {
        private readonly IUserCompanyService _userCompanyService;

        public GetAllUserCompanyCommandHandler(IUserCompanyService userCompanyService)
        {
            _userCompanyService = userCompanyService;
        }

        public async Task<GetAllUserCompanyCommandResponse> Handle(GetAllUserCompanyCommand request, CancellationToken cancellationToken)
        {
            var userCompanies = await _userCompanyService.GetAllUserCompany();
            return new(userCompanies.Count(), userCompanies);
        }
    }
}

