using System;
using Application.Messaging;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Queries.GetAllUcafs
{
	public record GetAllUcafsQuery(
		string companyId,
		string codeOrName,
		string type):IQuery<GetAllUcafsQueryResponse>;
	
}

