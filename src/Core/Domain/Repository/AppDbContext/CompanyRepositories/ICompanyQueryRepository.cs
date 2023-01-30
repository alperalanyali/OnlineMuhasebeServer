using System;
using Domain.AppEntities;
using Domain.Repository.GenericRepositories.AppDbContext;

namespace Domain.Repository.AppDbContext.CompanyRepositories
{
	public interface ICompanyQueryRepository: IAppQueryRepository<Company>
	{
		
	}
}

