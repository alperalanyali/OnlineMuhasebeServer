using System;
using Application.Messaging;
using MediatR;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
	public  sealed record CreateUCAFCommand(
		string Code,
		string Name,
		string Type,
		string CompanyId

		) : ICommand<CreateUCAFCommandResponse>;
}

