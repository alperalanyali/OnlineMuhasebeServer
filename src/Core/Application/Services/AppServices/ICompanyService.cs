using System;
using Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using Domain.AppEntities;

namespace Application.Services.AppServices
{
	public interface ICompanyService
	{
		Task CreateCompany(CreateCompanyCommand request);
		Task<Company?> GetCompanyByName(string name);
		Task MigrateCompanyDatabases();
	}
}

