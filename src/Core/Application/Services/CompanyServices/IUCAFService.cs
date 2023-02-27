using System;
using Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using Domain.CompanyEntities;

namespace Application.Services.CompanyServices
{
	public interface IUCAFService
	{
		Task<UCAF> CreateUCAFAsync(CreateUCAFCommand request, CancellationToken cancellationToken);
		Task CreateCompanyMainUcafsToCompany(string companyId,CancellationToken cancellationToken);
        Task<UCAF> GetByCodeAsync(string companyId, string code, CancellationToken cancellationToken);
        Task<IList<UCAF>> GetAllUCAFs(string companyId,string codeOrName, string type);
		Task<UCAF> GetById(string companyId,string id);
		Task Update(UCAF ucaf,string companyId,CancellationToken cancellationToken);
		Task<UCAF> DeleteById(string companyId, string id,CancellationToken cancellationToken);
		Task<bool> CheckRemoveUcafByIdIsGroupAvailable(string id, string companyId);

        Task<UCAF> GetByIdAsync(string id, string companyId);
    }
}

