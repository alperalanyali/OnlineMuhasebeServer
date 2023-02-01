using System;
using Domain.AppEntities;
using Domain.Repository.GenericRepositories;

namespace Domain.Repository.AppDbContext.UserCompanyRepositories
{
	public interface IUserCompanyQueryRepository: IQueryGenericRepository<AppUserCompany>
    {
	}
}

