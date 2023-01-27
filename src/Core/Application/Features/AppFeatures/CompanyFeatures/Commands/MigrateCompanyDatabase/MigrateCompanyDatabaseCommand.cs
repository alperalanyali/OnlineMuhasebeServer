using System;
using Application.Messaging;
using MediatR;

namespace Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
	public sealed record MigrateCompanyDatabaseCommand : ICommand<MigrateCompanyDatabaseResponse>
	{
		
	}
}

