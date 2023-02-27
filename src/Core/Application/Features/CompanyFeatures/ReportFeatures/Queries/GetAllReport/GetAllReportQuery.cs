using System;
using Application.Messaging;

namespace Application.Features.CompanyFeatures.ReportFeatures.Queries.GetAllReport
{
	public record GetAllReportQuery(
		
		string CompanyId,

        int PageNumber = 1,
		int PageSize = 5
        ) :IQuery<GetAllReportQueryResponse>;
	
}

