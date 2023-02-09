using System;
using Application.Messaging;
using Application.Services.AppServices;

namespace Application.Features.AppFeatures.MainRoleUser.Queries.GetMainRoleUserByUserId
{
    public class GetMainRoleUserByUserIdQueryCommand : IQueryHandler<GetMainRoleUserByUserIdQuery, GetMainRoleUserByUserIdQueryResponse>
    {

        private readonly IMainRoleUserService _mainRoleUserService;

        public GetMainRoleUserByUserIdQueryCommand(IMainRoleUserService mainRoleUserService)
        {
            _mainRoleUserService = mainRoleUserService;
        }

        public async Task<GetMainRoleUserByUserIdQueryResponse> Handle(GetMainRoleUserByUserIdQuery request, CancellationToken cancellationToken)
        {            
            var mainRole = await _mainRoleUserService.GetMainRoleByUserId(request.UserId);

            return new(mainRole.MainRoleId);
        }


    }
}

