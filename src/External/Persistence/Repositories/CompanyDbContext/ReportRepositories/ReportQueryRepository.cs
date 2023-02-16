using System;
using Domain.CompanyEntities;
using Domain.Repository.CompanyDbContext.ReportRepositories;
using Persistence.Repositories.GenericRepositories.CompanyDbContext;

namespace Persistence.Repositories.CompanyDbContext.ReportRepositories
{
	public class ReportQueryRepository: CompanyDbQueryRepository<Report>,IReportQueryRepository
    {
		
	}
}

