using System;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.AppEntities;
using MediatR;

namespace Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
    public sealed class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand,CreateCompanyResponse> // IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
    {
        private readonly ICompanyService _companyService;

        public CreateCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<CreateCompanyResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
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

