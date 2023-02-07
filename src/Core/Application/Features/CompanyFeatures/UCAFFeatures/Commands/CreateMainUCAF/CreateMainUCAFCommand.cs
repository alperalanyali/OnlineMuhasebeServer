using System;
using Application.Messaging;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateMainUCAF
{
	public record CreateMainUCAFCommand(string companyId):ICommand<CreateMainUCAFCommandResponse>;
	
}

