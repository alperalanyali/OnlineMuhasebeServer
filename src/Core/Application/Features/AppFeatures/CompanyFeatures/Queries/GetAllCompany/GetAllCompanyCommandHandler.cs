using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany
{
    public class GetAllCompanyCommandHandler : ICommandHandler<GetAllCompanyCommand, GetAllCompanyCommandResponse>
    {
        private readonly ICompanyService _companyService;

        public GetAllCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<GetAllCompanyCommandResponse> Handle(GetAllCompanyCommand request, CancellationToken cancellationToken)
        {
            var result = await _companyService.GetAlCompanies();
            return new(result.Count(), result);
        }
    }
}

