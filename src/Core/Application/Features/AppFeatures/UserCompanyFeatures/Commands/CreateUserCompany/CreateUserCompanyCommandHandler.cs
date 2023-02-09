using System;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.AppEntities;

namespace Application.Features.AppFeatures.UserCompanyFeatures.Commands.CreateUserCompany
{
    public class CreateUserCompanyCommandHandler : ICommandHandler<CreateUserCompanyCommand, CreateUserCompanyCommandResponse>
    {
        private readonly IUserCompanyService _userCompanyService;

        public CreateUserCompanyCommandHandler(IUserCompanyService userCompanyService)
        {
            _userCompanyService = userCompanyService;
        }

        public async Task<CreateUserCompanyCommandResponse> Handle(CreateUserCompanyCommand request, CancellationToken cancellationToken)
        {
            var userCompany = new AppUserCompany(userId: request.UserId, companyId: request.CompanyId);
            var checkUserCompany = await _userCompanyService.GetUserCompanyByUserIdAndCompanyId(request.UserId, request.CompanyId);
            if (checkUserCompany != null)
                throw new Exception("Bu kullaniciya daha once bu sirket tanimlanmistir");
            userCompany.Id = Guid.NewGuid().ToString();
            await _userCompanyService.CreateAsync(userCompany, cancellationToken);
            return new();
           
        }
    }
}

