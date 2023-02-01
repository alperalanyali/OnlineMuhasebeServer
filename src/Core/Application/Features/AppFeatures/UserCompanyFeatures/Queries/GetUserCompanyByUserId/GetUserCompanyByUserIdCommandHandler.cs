using System;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.AppEntities;

namespace Application.Features.AppFeatures.UserCompanyFeatures.Queries.GetUserCompanyByUserId
{
    public sealed class GetUserCompanyByUserIdCommandHandler : ICommandHandler<GetUserCompanyByUserIdCommand, GetUserCompanyByUserIdCommandResponse>
    {
        private readonly IUserCompanyService _userCompanyService;
        public GetUserCompanyByUserIdCommandHandler(IUserCompanyService userCompanyService)
        {
            _userCompanyService = userCompanyService;
        }
        public async Task<GetUserCompanyByUserIdCommandResponse> Handle(GetUserCompanyByUserIdCommand request, CancellationToken cancellationToken)
        {
            var results = await _userCompanyService.GetCompanyListByUserId(request.UserId);
            return new(results.Count,results);
        }
    }
}

