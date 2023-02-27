using System;
using Domain.CompanyEntities;
using Domain.Repository.AppDbContext.CompanyRepositories;

namespace Domain.Repository.CompanyDbContext.LogRepositories
{
	public interface ILogQueryRepository: ICompanyDbQueryRepository<Log>
    {
	}
}

