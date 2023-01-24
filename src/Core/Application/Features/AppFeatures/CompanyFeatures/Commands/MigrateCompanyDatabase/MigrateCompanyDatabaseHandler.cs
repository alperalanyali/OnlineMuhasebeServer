using System;
using Application.Services.AppServices;
using MediatR;

namespace Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public sealed class MigrateCompanyDatabaseHandler : IRequestHandler<MigrateCompanyDatabaseRequest, MigrateCompanyDatabaseResponse>
    {

        private readonly ICompanyService _companyService;

        public MigrateCompanyDatabaseHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<MigrateCompanyDatabaseResponse> Handle(MigrateCompanyDatabaseRequest request, CancellationToken cancellationToken)
        {
            await _companyService.MigrateCompanyDatabases();
            return new();
        }
    }
}

