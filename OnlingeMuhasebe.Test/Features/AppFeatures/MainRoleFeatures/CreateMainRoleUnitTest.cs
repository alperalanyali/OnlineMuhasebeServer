using System;
using Application.Features.AppFeatures.MainRole.Commands.CreateMainRole;
using Application.Services.AppServices;
using Domain.AppEntities;
using Moq;
using Shouldly;

namespace OnlingeMuhasebe.Test.Features.AppFeatures.MainRoleFeatures
{
	public sealed class CreateMainRoleUnitTest
	{
		private Mock<IMainRoleService> _mainRoleService;

		public CreateMainRoleUnitTest(Mock<IMainRoleService> mainRoleService)
		{
			_mainRoleService = mainRoleService;
		}

		[Fact]
		public async Task MainRoleShouldBeNull()
		{
			MainRole mainRole =await _mainRoleService.Object.GetByTitleAndCompany(title:"Admin", companyId:"c8eabb42-0474-43fc-8b97-6fefb2041a67");

			mainRole.ShouldBeNull();
		}

		[Fact]
		public async Task CreateMainRoleCommandResponseShouldNotBeNull()
		{
			var command = new CreateMainRoleCommand(
					Title: "Admin",
					CompanyId: "c8eabb42-0474-43fc-8b97-6fefb2041a67",
					IsRoleCreatedByAdmin: false
				);

			var handler = new CreateRoleCommandHandler(_mainRoleService.Object);

			CreateRoleResponse response = await handler.Handle(command, default);
			response.ShouldBeNull();
			response.Message.ShouldNotBeEmpty();

        }
	}
}

