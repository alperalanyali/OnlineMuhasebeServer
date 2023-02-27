using System;
using Domain.CompanyEntities;
using Domain.Repository.CompanyDbContext.LogRepositories;
using Persistence.Repositories.GenericRepositories.CompanyDbContext;

namespace Persistence.Repositories.CompanyDbContext.LogRepositories
{
	public class LogCommandRepository: CompanyDbCommandRepository<Log>,ILogCommandRepository
    {
		
	}
}

