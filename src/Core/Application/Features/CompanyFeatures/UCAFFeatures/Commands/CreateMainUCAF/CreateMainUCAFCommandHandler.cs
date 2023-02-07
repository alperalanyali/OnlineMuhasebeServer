using System;
using Application.Messaging;
using Application.Services.CompanyServices;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateMainUCAF
{
    public class CreateMainUCAFCommandHandler : ICommandHandler<CreateMainUCAFCommand, CreateMainUCAFCommandResponse>
    {
        private readonly IUCAFService _ucafService;

        public CreateMainUCAFCommandHandler(IUCAFService ucafService)
        {
            _ucafService = ucafService;
        }

        public async Task<CreateMainUCAFCommandResponse> Handle(CreateMainUCAFCommand request, CancellationToken cancellationToken)
        {
            await _ucafService.CreateCompanyMainUcafsToCompany(request.companyId,cancellationToken);
            return new();
        }
    }
}

