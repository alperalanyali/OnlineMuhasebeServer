using System;
using Application.Messaging;

namespace Application.Features.CompanyFeatures.ReportFeatures.Queries.GetAllReport
{
	public record GetAllReportQuery(
		string CompanyId
		):IQuery<GetAllReportQueryResponse>;
	
}

