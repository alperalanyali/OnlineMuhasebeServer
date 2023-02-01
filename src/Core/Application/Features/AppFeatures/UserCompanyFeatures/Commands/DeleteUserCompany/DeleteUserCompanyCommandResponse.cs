using System;
namespace Application.Features.AppFeatures.UserCompanyFeatures.Commands.DeleteUserCompany
{
	public sealed record DeleteUserCompanyCommandResponse(
		string Message = "Kayit basarili sekilde silinmistir."
		);
	
}

