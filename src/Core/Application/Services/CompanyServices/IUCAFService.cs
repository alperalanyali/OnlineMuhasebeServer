using System;
using Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using Domain.CompanyEntities;

namespace Application.Services.CompanyServices
{
	public interface IUCAFService
	{
		Task CreateUCAFAsync(CreateUCAFCommand request, CancellationToken cancellationToken);
		Task CreateCompanyMainUcafsToCompany(string companyId,CancellationToken cancellationToken);
		Task<IList<UCAF>> GetAllUCAFs(string companyId,string codeOrName, string type);
	}
}

