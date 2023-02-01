using System;
namespace Application.Features.AppFeatures.UserCompanyFeatures.Commands.CreateUserCompany
{
	public sealed record CreateUserCompanyCommandResponse(
		string Message = "Kullanıcıya şirket basarili sekilde olusturuldu."
		);
	
}

