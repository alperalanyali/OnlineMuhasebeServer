using System;
using Application.Features.CompanyFeatures.LogFeatures.Queries.GetLogsByTableName;
using Domain.CompanyEntities;
using Domain.Dtos;
using EntityFrameworkCorePagination.Nuget.Pagination;
namespace Application.Services.CompanyServices
{
	public interface ILogService
	{
		Task AddAsync(Log log,string companyId);
		Task<PaginationResult<LogDto>> GetLogsByTableNameQuery(GetLogsByTableNameQuery request);

    }
}

