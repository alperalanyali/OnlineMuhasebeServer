using System;
using Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;

namespace Application.Services.CompanyServices
{
	public interface IUCAFService
	{
		Task CreateUCAFAsync(CreateUCAFCommand request);
	}
}

