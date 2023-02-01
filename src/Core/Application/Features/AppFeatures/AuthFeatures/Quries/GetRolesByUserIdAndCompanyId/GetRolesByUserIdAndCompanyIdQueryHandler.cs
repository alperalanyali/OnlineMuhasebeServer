using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.AuthFeatures.Quries.GetRolesByUserIdAndCompanyId
{
    public class GetRolesByUserIdAndCompanyIdQueryHandler : IQueryHandler<GetRolesByUserIdAndCompanyIdQuery, GetRolesByUserIdAndCompanyIdQueryResponse>
    {
        private readonly IAuthService _authService;

        public GetRolesByUserIdAndCompanyIdQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GetRolesByUserIdAndCompanyIdQueryResponse> Handle(GetRolesByUserIdAndCompanyIdQuery request, CancellationToken cancellationToken)
        {
            IList<string> roles = await _authService.GetRolesByUserIdAndCompany(request.UserId, request.CompanyId);

            return new(roles.Count(), roles);
        }
    }
}

