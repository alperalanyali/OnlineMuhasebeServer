using System;
namespace Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
	public sealed record MigrateCompanyDatabaseResponse(
		string Message = "Şirketlerin database bilgileri migrate edildi");
	
}

