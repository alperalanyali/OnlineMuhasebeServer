using System;
using Application.Messaging;

namespace Application.Features.AppFeatures.MainRoleUser.Queries.GetMainRoleUserByUserId
{
    public class GetMainRoleUserByUserIdQueryCommand : IQueryHandler<GetMainRoleUserByUserIdQuery, GetMainRoleUserByUserIdQueryResponse>
    {

        public Task<GetMainRoleUserByUserIdQueryResponse> Handle(GetMainRoleUserByUserIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

