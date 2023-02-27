using System;
using Domain.CompanyEntities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace Application.Features.CompanyFeatures.ReportFeatures.Queries.GetAllReport
{
	public sealed record GetAllReportQueryResponse(
		// IList<Report> Data
		PaginationResult<Report> Data
		);
	
}

