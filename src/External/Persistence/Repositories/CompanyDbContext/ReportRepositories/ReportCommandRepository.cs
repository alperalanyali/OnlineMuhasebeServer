using System;
using Domain.CompanyEntities;
using Domain.Repository.CompanyDbContext.ReportRepositories;
using Persistence.Repositories.GenericRepositories.CompanyDbContext;

namespace Persistence.Repositories.CompanyDbContext.ReportRepositories
{
	public sealed class ReportCommandRepository: CompanyDbCommandRepository<Report>,IReportCommandRepository
    {
		
	}
}

