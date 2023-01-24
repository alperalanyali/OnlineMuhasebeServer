using System;
using Application.Services.AppServices;
using Domain.AppEntities;
using MediatR;

namespace Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
    public sealed class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
    {
        private readonly ICompanyService _companyService;

        public CreateCompanyHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
        {
            Company company =await _companyService.GetCompanyByName(request.Name);
            if(company != null)
            {
                throw new Exception("Bu şirket adı daha önce kullanılmıştır!");
            }
            await _companyService.CreateCompany(request);
            return new();
        }
    }
}

