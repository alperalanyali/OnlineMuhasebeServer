using System;
using Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using Domain.CompanyEntities;

namespace Application.Services.CompanyServices
{
	public interface IReportService
	{
		Task Request(RequestReportCommand request, CancellationToken cancellationToken);
		Task<IList<Report>> GetAllReportsByCompanyId(string companyId);

	}
}

