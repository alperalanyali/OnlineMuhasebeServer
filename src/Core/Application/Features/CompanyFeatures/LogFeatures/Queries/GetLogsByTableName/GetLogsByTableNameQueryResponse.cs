using System;
using Domain.CompanyEntities;
using Domain.Dtos;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace Application.Features.CompanyFeatures.LogFeatures.Queries.GetLogsByTableName
{
	public sealed record GetLogsByTableNameQueryResponse(
			PaginationResult<LogDto> Data
		);
	
}

