using System;
using Application.Services.AppServices;
using MediatR;

namespace Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public sealed class MigrateCompanyDatabaseCommandHandler : IRequestHandler<MigrateCompanyDatabaseCommand, MigrateCompanyDatabaseResponse>
    {

        private readonly ICompanyService _companyService;

        public MigrateCompanyDatabaseCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<MigrateCompanyDatabaseResponse> Handle(MigrateCompanyDatabaseCommand request, CancellationToken cancellationToken)
        {
            await _companyService.MigrateCompanyDatabases();
            return new();
        }
    }
}

