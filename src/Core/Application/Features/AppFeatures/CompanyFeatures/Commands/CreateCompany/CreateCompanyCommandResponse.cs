using System;
namespace Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
	public sealed record CreateCompanyResponse(
		string Message = "Şirket başarılı şekilde oluşturuldu");
	
}

