using System;
using Domain.CompanyEntities;
using Domain.Repository.AppDbContext.CompanyRepositories;

namespace Domain.Repository.CompanyDbContext.ReportRepositories
{
	public interface IReportQueryRepository: ICompanyDbQueryRepository<Report>
    {
	}
}

