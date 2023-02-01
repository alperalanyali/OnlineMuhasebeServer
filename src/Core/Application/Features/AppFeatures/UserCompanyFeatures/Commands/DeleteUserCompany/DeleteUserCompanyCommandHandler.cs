using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.UserCompanyFeatures.Commands.DeleteUserCompany
{
    public class DeleteUserCompanyCommandHandler : ICommandHandler<DeleteUserCompanyCommand, DeleteUserCompanyCommandResponse>
    {
        private readonly IUserCompanyService _userCompanySerrvice;

        public DeleteUserCompanyCommandHandler(IUserCompanyService userCompanySerrvice)
        {
            _userCompanySerrvice = userCompanySerrvice;
        }

        public async Task<DeleteUserCompanyCommandResponse> Handle(DeleteUserCompanyCommand request, CancellationToken cancellationToken)
        {
            await _userCompanySerrvice.DeleteById(request.Id, cancellationToken);

            return new();
        }
    }
}

