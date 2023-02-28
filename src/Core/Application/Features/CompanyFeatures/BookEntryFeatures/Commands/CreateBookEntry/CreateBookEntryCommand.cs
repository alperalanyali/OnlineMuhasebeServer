using System;
using Application.Messaging;

namespace Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry
{
	public sealed record CreateBookEntryCommand(
			string CompanyId,			
			string Description,
			string Type,
			string Date
		):ICommand<CreateBookEntryCommandResponse>;
	
}

