using System;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.Dtos;

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

            var userCompanies = await _userCompanyService.GetAllUserCompany("");
            var dtos = userCompanies.Select(s => new UserCompanyDto(s.Id,s.AppUserId,s.AppUser.UserName,s.CompanyId,s.Company.Name)).ToList();
            return new(userCompanies.Count(), dtos);
        }
    }
}

