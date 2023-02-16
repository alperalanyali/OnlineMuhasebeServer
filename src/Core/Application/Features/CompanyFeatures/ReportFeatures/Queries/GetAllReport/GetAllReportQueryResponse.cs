using System;
using Domain.CompanyEntities;

namespace Application.Features.CompanyFeatures.ReportFeatures.Queries.GetAllReport
{
	public sealed record GetAllReportQueryResponse(
		 int Results ,
		 IList<Report> Data
		);
	
}

