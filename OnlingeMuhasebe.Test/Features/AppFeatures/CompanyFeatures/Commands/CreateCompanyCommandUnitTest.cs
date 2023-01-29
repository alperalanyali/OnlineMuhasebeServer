using System;
using Application.Services.AppServices;
using Domain.AppEntities;
using Moq;

namespace OnlingeMuhasebe.Test.Features.AppFeatures.CompanyFeatures.Commands
{
	public class CreateCompanyCommandUnitTest
	{
		private readonly Mock<ICompanyService> _companyService;

        public CreateCompanyCommandUnitTest()
        {
            _companyService = new();
        }

        [Fact]
		public async Task CompanyShouldBeNull()
		{
			Company company = (await _companyService.Object.GetCompanyByName("Alanyali Lti. Şti"))!;
			company.ShouldBeNull();
		}
	}
}

