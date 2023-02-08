using System;
using Application.Messaging;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Commands.UpdateUCAF
{
	public record UpdateUCAFCommand(
		string Id,
		string Code,
		string Name,
		string CompanyId
		) :ICommand<UpdateUCAFCommandResponse>;
	
}

