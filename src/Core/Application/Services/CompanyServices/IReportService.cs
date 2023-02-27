using System;
using Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using Domain.CompanyEntities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace Application.Services.CompanyServices
{
	public interface IReportService
	{
		Task Request(RequestReportCommand request, CancellationToken cancellationToken);
		Task<PaginationResult<Report>> GetAllReportsByCompanyId(string companyId,int pageNumber=1,int pageSize=5);


    }
}

