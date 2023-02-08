using System;
using Domain.CompanyEntities;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Queries.GetAllUcafs
{
	public record GetAllUcafsQueryResponse(
        int results,
        IList<UCAF> data
		);
	
}

