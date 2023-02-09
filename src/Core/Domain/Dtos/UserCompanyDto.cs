using System;
namespace Domain.Dtos
{
	public record UserCompanyDto(
		string Id,
		string UserId,
		string UserName,
		string CompanyId,
		string CompanyName
		);


}