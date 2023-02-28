using System;
namespace Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry
{
	public sealed record CreateBookEntryCommandResponse(
		string Message = "Yevmiye fişi kaydı başarılıyla oluşturuldu."
		);
	
}

