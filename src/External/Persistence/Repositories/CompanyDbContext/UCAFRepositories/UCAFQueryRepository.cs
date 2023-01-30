using System;
using Domain.CompanyEntities;
using Domain.Repository.CompanyDbContext.UCAFRepositories;
using Persistence.Repositories.GenericRepositories.CompanyDbContext;

namespace Persistence.Repositories.CompanyDbContext.UCAFRepositories
{
	public sealed class UCAFQueryRepository:CompanyDbQueryRepository<UCAF>,IUCAFQueryRepository
	{
		
	}
}

