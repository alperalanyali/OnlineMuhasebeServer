using System;
using Application.Messaging;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Commands.DeleteUCAF
{
	public record DeleteUCAFCommand(
		string Id,
		string CompanyId
		):ICommand<DeleteUCAFCommandResponse>;
	
}

